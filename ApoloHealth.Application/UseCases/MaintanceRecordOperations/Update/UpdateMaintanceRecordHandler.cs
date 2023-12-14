using ApoloHealth.Domain.Entities;
using ApoloHealth.Domain.Interfaces;
using AutoMapper;
using MediatR;

namespace ApoloHealth.Application.UseCases.MaintanceRecordOperations.Update;

public class UpdateMaintanceRecordHandler : IRequestHandler<UpdateMaintanceRecordRequest, UpdateMaintanceRecordResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMaintanceRecordRepository _maintanceRecordRepository;
    private readonly IEquipmentRepository _equipmentRepository;
    private readonly IAppointmentRepository _appointmentRepository;
    private readonly IMapper _mapper;

    public UpdateMaintanceRecordHandler(
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
    public async Task<UpdateMaintanceRecordResponse> Handle(UpdateMaintanceRecordRequest command, CancellationToken cancellationToken)
    {
        var maintanceRecord = await _maintanceRecordRepository.Get(command.Id, cancellationToken);

        if (maintanceRecord == null) { return default; }

        var maintanceRecordUpdate = _mapper.Map<MaintanceRecord>(command);

        if (maintanceRecordUpdate.StartDate != default) { maintanceRecord.StartDate = maintanceRecordUpdate.StartDate; }
        if (maintanceRecordUpdate.EndDate != default) { maintanceRecord.EndDate = maintanceRecordUpdate.EndDate; }
        if (maintanceRecordUpdate.InitialState != default) { maintanceRecord.InitialState = maintanceRecordUpdate.InitialState; }
        if (maintanceRecordUpdate.FinalState != default) { maintanceRecord.FinalState = maintanceRecordUpdate.FinalState; }
        if (!string.IsNullOrEmpty(maintanceRecordUpdate.ProblemDescription)) { maintanceRecord.ProblemDescription = maintanceRecordUpdate.ProblemDescription; }
        if (!string.IsNullOrEmpty(maintanceRecordUpdate.SolutionDescription)) { maintanceRecord.SolutionDescription = maintanceRecordUpdate.SolutionDescription; }
        if (maintanceRecordUpdate.WasDone != default) { maintanceRecord.WasDone = maintanceRecordUpdate.WasDone; }
        if (maintanceRecord.WasDone)
        {
            var equipment = await _equipmentRepository.Get(maintanceRecord.EquipmentId, cancellationToken);
            if (equipment != null)
            {
                if (equipment.MaintanceRecords.OrderByDescending(m => m.StartDate).FirstOrDefault()?.StartDate < maintanceRecord.StartDate)
                {
                    equipment.Status = (EquipmentStatus) maintanceRecord.FinalState;
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
        }

        if (maintanceRecordUpdate.Type != default) { maintanceRecord.Type = maintanceRecordUpdate.Type; }

        _maintanceRecordRepository.Update(maintanceRecord);

        await _unitOfWork.Commit(cancellationToken);

        return _mapper.Map<UpdateMaintanceRecordResponse>(maintanceRecord);
    }
}
