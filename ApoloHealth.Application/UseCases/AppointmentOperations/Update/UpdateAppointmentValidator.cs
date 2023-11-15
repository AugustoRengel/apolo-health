using FluentValidation;

namespace ApoloHealth.Application.UseCases.AppointmentOperations.Update;

public class UpdateAppointmentValidator : AbstractValidator<UpdateAppointmentRequest>
{
    public UpdateAppointmentValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}
