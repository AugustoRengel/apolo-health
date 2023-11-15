using MediatR;

namespace ApoloHealth.Application.UseCases.AppointmentOperations.GetAll
{
    public sealed record GetAllAppointmentRequest : IRequest<List<GetAllAppointmentResponse>>;
}
