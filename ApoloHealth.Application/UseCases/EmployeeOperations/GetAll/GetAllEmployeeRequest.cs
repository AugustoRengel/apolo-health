using MediatR;

namespace ApoloHealth.Application.UseCases.EmployeeOperations.GetAll
{
    public sealed record GetAllEmployeeRequest : IRequest<List<GetAllEmployeeResponse>>;
}
