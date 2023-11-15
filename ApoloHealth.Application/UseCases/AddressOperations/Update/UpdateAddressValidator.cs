using FluentValidation;

namespace ApoloHealth.Application.UseCases.AddressOperations.Update;

public class UpdateAddressValidator : AbstractValidator<UpdateAddressRequest>
{
    public UpdateAddressValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}
