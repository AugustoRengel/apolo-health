using FluentValidation;

namespace ApoloHealth.Application.UseCases.UpdateEquipment;

public class UpdateEquipmentValidator : AbstractValidator<UpdateEquipmentRequest>
{
    public UpdateEquipmentValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}
