using ApoloHealth.Application.UseCases.UpdateEquipment;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApoloHealth.Application.UseCases.DeleteEquipment;

public class DeleteEquipmentValidator : AbstractValidator<DeleteEquipmentRequest>
{
    public DeleteEquipmentValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}
