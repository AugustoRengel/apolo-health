using FluentValidation;

namespace ApoloHealth.Application.UseCases.CustomerOperations.GetAll;

public class GetAllCustomerValidator : AbstractValidator<GetAllCustomerRequest>
{
    public GetAllCustomerValidator()
    {
        // without validation
    }

}
