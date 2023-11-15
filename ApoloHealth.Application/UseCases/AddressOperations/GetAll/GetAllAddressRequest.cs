using MediatR;

namespace ApoloHealth.Application.UseCases.AddressOperations.GetAll
{
    public sealed record GetAllAddressRequest : IRequest<List<GetAllAddressResponse>>;
}
