using FluentValidation;

namespace ApoloHealth.Application.UseCases.EmployeeOperations.Update;

public class UpdateEmployeeValidator : AbstractValidator<UpdateEmployeeRequest>
{
    public UpdateEmployeeValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}
