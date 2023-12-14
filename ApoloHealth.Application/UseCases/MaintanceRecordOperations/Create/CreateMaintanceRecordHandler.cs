using ApoloHealth.Application.UseCases.ExamOperations.Create;
using ApoloHealth.Domain.Entities;
using ApoloHealth.Domain.Interfaces;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApoloHealth.Application.UseCases.MaintanceRecordOperations.Create;

internal class CreateMaintanceRecordHandler : IRequestHandler<CreateMaintanceRecordRequest, CreateMaintanceRecordResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMaintanceRecordRepository _maintanceRecordRepository;
    private readonly IEquipmentRepository _equipmentRepository;
    private readonly IAppointmentRepository _appointmentRepository;
    private readonly IMapper _mapper;
    public CreateMaintanceRecordHandler(
        IUnitOfWork unitOfWork, 
        IMaintanceRecordRepository maintanceRecordRepository, 
        IEquipmentRepository equipmentRepository, 
        IAppointmentRepository appointmentRepository,
        IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _maintanceRecordRepository = maintanceRecordRepository;
        _equipmentRepository = equipmentRepository;
        _appointmentRepository = appointmentRepository;
        _mapper = mapper;
    }
    public async Task<CreateMaintanceRecordResponse> Handle(CreateMaintanceRecordRequest request, CancellationToken cancellationToken)
    {
        var maintanceRecord = _mapper.Map<MaintanceRecord>(request);
        var equipment = await _equipmentRepository.Get(maintanceRecord.EquipmentId, cancellationToken);
        if (equipment != null)
        {
            if (equipment.MaintanceRecords.Count == 0 || equipment.MaintanceRecords.OrderByDescending(m => m.StartDate).FirstOrDefault()?.StartDate < maintanceRecord.StartDate)
            {
                equipment.Status = maintanceRecord.InitialState;
                equipment.LastPreventiveDate = maintanceRecord.EndDate;
                equipment.DateUpdated = DateTime.UtcNow;

                var appointmentsWithConflict = equipment.Appointments
                    .Where(a => 
                    (maintanceRecord.StartDate >= a.StartDate && maintanceRecord.StartDate <= a.EndDate) || 
                    (maintanceRecord.EndDate >= a.StartDate && maintanceRecord.EndDate <= a.EndDate) ||
                    (maintanceRecord.StartDate <= a.StartDate && maintanceRecord.EndDate >= a.EndDate)
                    ).ToList();
                if (appointmentsWithConflict.Any())
                {
                    List<Equipment> equipmentsOfType = await _equipmentRepository.GetAllOfType(equipment.Type, cancellationToken);
                    foreach (var appointment in appointmentsWithConflict)
                    {
                        List<Equipment> replaceEquipments = equipmentsOfType.Where(equips =>
                        equips.Status == EquipmentStatus.Operative &&
                        equips.Appointments.All(ap =>
                        appointment.StartDate > ap.EndDate ||
                        appointment.EndDate < ap.StartDate
                        )).ToList();
                        if (replaceEquipments.Any())
                        {
                            Equipment replaceEquipment = replaceEquipments.First();
                            appointment.EquipmentId = replaceEquipment.Id;
                            appointment.Description += $"\n Equipment of Id: {equipment.Id} was replaced by equipment of Id: {replaceEquipment.Id}";
                            appointment.DateUpdated = DateTime.UtcNow;
                        }
                        else
                        {
                            appointment.NeedsRescheduling = true;
                            appointment.DateUpdated = DateTime.UtcNow;
                        }
                        _appointmentRepository.Update(appointment);
                    }
                }
                _equipmentRepository.Update(equipment);
            }
        }
        _maintanceRecordRepository.Create(maintanceRecord);
        await _unitOfWork.Commit(cancellationToken);
        return _mapper.Map<CreateMaintanceRecordResponse>(maintanceRecord);
    }
}
