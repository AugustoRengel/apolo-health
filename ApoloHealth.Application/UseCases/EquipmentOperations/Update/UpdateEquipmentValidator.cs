﻿using FluentValidation;

namespace ApoloHealth.Application.UseCases.ExamOperations.Update;

public class UpdateEquipmentValidator : AbstractValidator<UpdateEquipmentRequest>
{
    public UpdateEquipmentValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}
