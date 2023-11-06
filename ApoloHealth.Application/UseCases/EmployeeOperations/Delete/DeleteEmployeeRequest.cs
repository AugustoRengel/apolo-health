using MediatR;

namespace ApoloHealth.Application.UseCases.EmployeeOperations.Delete;

public sealed record DeleteEmployeeRequest(Guid Id) :
        IRequest<DeleteEmployeeResponse>;
