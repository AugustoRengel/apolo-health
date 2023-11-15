using FluentValidation;

namespace ApoloHealth.Application.UseCases.AddressOperations.Create
{
    public sealed class CreateAddressValidator : AbstractValidator<CreateAddressRequest>
    {
        public CreateAddressValidator()
        {
            RuleFor(x => x.Street).NotEmpty();
            RuleFor(x => x.City).NotEmpty();
            RuleFor(x => x.State).NotEmpty();
            RuleFor(x => x.PostalCode).NotEmpty();
            RuleFor(x => x.Country).NotEmpty();
            RuleFor(x => x.PersonId).NotEmpty();
        }
    }
}