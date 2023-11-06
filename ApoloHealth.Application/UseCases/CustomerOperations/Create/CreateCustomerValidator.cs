using FluentValidation;

namespace ApoloHealth.Application.UseCases.CustomerOperations.Create
{
    public sealed class CreateCustomerValidator : AbstractValidator<CreateCustomerRequest>
    {
        public CreateCustomerValidator()
        {
            RuleFor(x => x.LastAppointment).NotEmpty();
            RuleFor(x => x.HealthInsurance).NotEmpty();
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.CPF).NotEmpty();
            RuleFor(x => x.BirthDate).NotEmpty();
            RuleFor(x => x.Email).NotEmpty();
            RuleFor(x => x.Phone).NotEmpty();
            RuleFor(x => x.Gender).NotEmpty();
            RuleFor(x => x.Nationality).NotEmpty();
            RuleFor(x => x.MaritalStatus).NotEmpty();
        }
    }
}
