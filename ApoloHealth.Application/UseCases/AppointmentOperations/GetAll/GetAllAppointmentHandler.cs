using ApoloHealth.Domain.Interfaces;
using AutoMapper;
using MediatR;

namespace ApoloHealth.Application.UseCases.AppointmentOperations.GetAll;

public sealed class GetAllAppointmentHandler : IRequestHandler<GetAllAppointmentRequest, List<GetAllAppointmentResponse>>
{
    private readonly IAppointmentRepository _appointmentRepository;
    private readonly IMapper _mapper;
    public GetAllAppointmentHandler(IAppointmentRepository appointmentRepository, IMapper mapper)
    {
        _appointmentRepository = appointmentRepository;
        _mapper = mapper;
    }
    public async Task<List<GetAllAppointmentResponse>> Handle(GetAllAppointmentRequest request, CancellationToken cancellationToken)
    {
        var appointments = await _appointmentRepository.GetAll(cancellationToken);
        return _mapper.Map<List<GetAllAppointmentResponse>>(appointments);
    }
}