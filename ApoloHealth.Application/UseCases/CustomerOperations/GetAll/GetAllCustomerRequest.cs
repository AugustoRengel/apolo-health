using MediatR;

namespace ApoloHealth.Application.UseCases.CustomerOperations.GetAll
{
    public sealed record GetAllCustomerRequest : IRequest<List<GetAllCustomerResponse>>;
}
