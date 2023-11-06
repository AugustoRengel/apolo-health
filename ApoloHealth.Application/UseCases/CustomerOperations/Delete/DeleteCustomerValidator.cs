using FluentValidation;

namespace ApoloHealth.Application.UseCases.CustomerOperations.Delete;

public class DeleteCustomerValidator : AbstractValidator<DeleteCustomerRequest>
{
    public DeleteCustomerValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}
