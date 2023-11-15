using FluentValidation;

namespace ApoloHealth.Application.UseCases.AddressOperations.Delete;

public class DeleteAddressValidator : AbstractValidator<DeleteAddressRequest>
{
    public DeleteAddressValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}
