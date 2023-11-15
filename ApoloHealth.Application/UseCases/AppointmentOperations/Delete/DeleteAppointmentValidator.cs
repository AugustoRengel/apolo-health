using FluentValidation;

namespace ApoloHealth.Application.UseCases.AppointmentOperations.Delete;

public class DeleteAppointmentValidator : AbstractValidator<DeleteAppointmentRequest>
{
    public DeleteAppointmentValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}
