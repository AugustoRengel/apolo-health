using MediatR;

namespace ApoloHealth.Application.UseCases.AddressOperations.Delete;

public sealed record DeleteAddressRequest(Guid Id) :
        IRequest<DeleteAddressResponse>;
