using ApoloHealth.Domain.Entities;
using MediatR;

namespace ApoloHealth.Application.UseCases.AddressOperations.Create;

public sealed record CreateAddressRequest(
    string Street,
    string City,
    string State,
    string PostalCode,
    string Country,
    Guid PersonId
    ) : IRequest<CreateAddressResponse>;
