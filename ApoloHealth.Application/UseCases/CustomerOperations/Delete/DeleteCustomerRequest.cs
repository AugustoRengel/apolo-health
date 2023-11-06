using MediatR;

namespace ApoloHealth.Application.UseCases.CustomerOperations.Delete;

public sealed record DeleteCustomerRequest(Guid Id) :
        IRequest<DeleteCustomerResponse>;
