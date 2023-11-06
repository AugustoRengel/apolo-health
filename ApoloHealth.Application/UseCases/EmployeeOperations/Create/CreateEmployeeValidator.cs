using FluentValidation;

namespace ApoloHealth.Application.UseCases.EmployeeOperations.Create
{
    public sealed class CreateEmployeeValidator : AbstractValidator<CreateEmployeeRequest>
    {
        public CreateEmployeeValidator()
        {
            RuleFor(x => x.Role).NotEmpty();
            RuleFor(x => x.Wage).NotEmpty();
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
