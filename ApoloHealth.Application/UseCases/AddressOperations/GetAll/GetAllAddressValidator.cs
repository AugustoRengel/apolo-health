using FluentValidation;

namespace ApoloHealth.Application.UseCases.AddressOperations.GetAll;

public class GetAllAddressValidator : AbstractValidator<GetAllAddressRequest>
{
    public GetAllAddressValidator()
    {
        // without validation
    }

}
