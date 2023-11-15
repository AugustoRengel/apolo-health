using ApoloHealth.Domain.Entities;
using ApoloHealth.Domain.Interfaces;
using AutoMapper;
using MediatR;

namespace ApoloHealth.Application.UseCases.AppointmentOperations.Update;

public class UpdateAppointmentHandler : IRequestHandler<UpdateAppointmentRequest, UpdateAppointmentResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IAppointmentRepository _appointmentRepository;
    private readonly IEquipmentRepository _equipmentRepository;
    private readonly IMapper _mapper;
    public UpdateAppointmentHandler(IUnitOfWork unitOfWork, IAppointmentRepository appointmentRepository, IEquipmentRepository equipmentRepository, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _appointmentRepository = appointmentRepository;
        _equipmentRepository = equipmentRepository;
        _mapper = mapper;
    }
    public async Task<UpdateAppointmentResponse> Handle(UpdateAppointmentRequest command, CancellationToken cancellationToken)
    {
        var appointment = await _appointmentRepository.Get(command.Id, cancellationToken);

        if (appointment == null) { return default; }
        var appointmentUpdate = _mapper.Map<Appointment>(command);

        if (!string.IsNullOrEmpty(appointmentUpdate.Title)) { appointment.Title = appointmentUpdate.Title; }
        if (!string.IsNullOrEmpty(appointmentUpdate.Description)) { appointment.Description = appointmentUpdate.Description; }
        if (appointmentUpdate.RoomNumber != null) { appointment.RoomNumber = appointmentUpdate.RoomNumber; }
        if (appointmentUpdate.StartDate != null) { appointment.StartDate = appointmentUpdate.StartDate; }
        if (appointmentUpdate.EndDate != null) { appointment.EndDate = appointmentUpdate.EndDate; }
        if (appointmentUpdate.WasDone != null) { appointment.WasDone = appointmentUpdate.WasDone; }
        if (appointmentUpdate.RequiresTechnician != null) { appointment.RequiresTechnician = appointmentUpdate.RequiresTechnician; }
        if (appointmentUpdate.EquipmentId != null)
        {
            appointment.EquipmentId = appointmentUpdate.EquipmentId;
            if (appointment.RequiresTechnician == true && appointment.EquipmentId != Guid.Empty)
            {
                var equipment = await _equipmentRepository.Get(appointment.EquipmentId ?? Guid.Empty, cancellationToken);
                appointment.TechnicianId = equipment?.Technicians?.First().Id;
            }
        }
        if (appointmentUpdate.EmployeeId != null) { appointment.EmployeeId = appointmentUpdate.EmployeeId; }
        if (appointmentUpdate.TechnicianId != null) { appointment.TechnicianId = appointmentUpdate.TechnicianId; }
        if (appointmentUpdate.ExamId != null) { appointment.ExamId = appointmentUpdate.ExamId; }
        if (appointmentUpdate.CustomerId != null) { appointment.CustomerId = appointmentUpdate.CustomerId; }

        _appointmentRepository.Update(appointment);

        await _unitOfWork.Commit(cancellationToken);

        return _mapper.Map<UpdateAppointmentResponse>(appointment);
    }
}
