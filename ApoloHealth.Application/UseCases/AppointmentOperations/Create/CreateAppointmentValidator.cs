using FluentValidation;

namespace ApoloHealth.Application.UseCases.AppointmentOperations.Create
{
    public sealed class CreateAppointmentValidator : AbstractValidator<CreateAppointmentRequest>
    {
        public CreateAppointmentValidator()
        {
            RuleFor(x => x.Title).NotEmpty();
            RuleFor(x => x.Description).NotEmpty();
            RuleFor(x => x.RoomNumber).NotEmpty();
            RuleFor(x => x.StartDate).NotEmpty();
            RuleFor(x => x.EndDate).NotEmpty();
            RuleFor(x => x.EmployeeId).NotEmpty();
            RuleFor(x => x.ExamId).NotEmpty();
            RuleFor(x => x.CustomerId).NotEmpty();
        }
    }
}