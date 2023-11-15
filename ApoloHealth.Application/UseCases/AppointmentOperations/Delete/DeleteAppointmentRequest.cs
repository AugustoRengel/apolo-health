using MediatR;

namespace ApoloHealth.Application.UseCases.AppointmentOperations.Delete;

public sealed record DeleteAppointmentRequest(Guid Id) :
        IRequest<DeleteAppointmentResponse>;
