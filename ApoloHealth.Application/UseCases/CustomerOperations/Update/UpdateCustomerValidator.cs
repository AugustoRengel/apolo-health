using FluentValidation;

namespace ApoloHealth.Application.UseCases.CustomerOperations.Update;

public class UpdateCustomerValidator : AbstractValidator<UpdateCustomerRequest>
{
    public UpdateCustomerValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}
