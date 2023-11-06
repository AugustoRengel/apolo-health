using FluentValidation;

namespace ApoloHealth.Application.UseCases.EmployeeOperations.Delete;

public class DeleteEmployeeValidator : AbstractValidator<DeleteEmployeeRequest>
{
    public DeleteEmployeeValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}
