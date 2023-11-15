using FluentValidation;

namespace ApoloHealth.Application.UseCases.AppointmentOperations.GetAll;

public class GetAllAppointmentValidator : AbstractValidator<GetAllAppointmentRequest>
{
    public GetAllAppointmentValidator()
    {
        // without validation
    }

}
