using ApoloHealth.Domain.Entities;
using ApoloHealth.Domain.Interfaces;
using AutoMapper;
using MediatR;

namespace ApoloHealth.Application.UseCases.AppointmentOperations.Create;

internal class CreateAppointmentHandler : IRequestHandler<CreateAppointmentRequest, CreateAppointmentResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IAppointmentRepository _appointmentRepository;
    private readonly IEquipmentRepository _equipmentRepository;
    private readonly IMapper _mapper;
    public CreateAppointmentHandler(IUnitOfWork unitOfWork, IAppointmentRepository appointmentRepository, IEquipmentRepository equipmentRepository, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _appointmentRepository = appointmentRepository;
        _equipmentRepository = equipmentRepository;
        _mapper = mapper;
    }
    public async Task<CreateAppointmentResponse> Handle(CreateAppointmentRequest request, CancellationToken cancellationToken)
    {
        var appointment = _mapper.Map<Appointment>(request);
        if (appointment.EquipmentId != null)
        {
            if (appointment.RequiresTechnician == true && appointment.EquipmentId != Guid.Empty)
            {
                var equipment = await _equipmentRepository.Get(appointment.EquipmentId ?? Guid.Empty, cancellationToken);
                appointment.TechnicianId = equipment?.Technicians?.First().Id;
            }
        }
        _appointmentRepository.Create(appointment);
        await _unitOfWork.Commit(cancellationToken);
        return _mapper.Map<CreateAppointmentResponse>(appointment);
    }
}
