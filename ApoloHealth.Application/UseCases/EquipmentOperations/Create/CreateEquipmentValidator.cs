using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApoloHealth.Application.UseCases.EquipmentOperations.Create
{
    public sealed class CreateEquipmentValidator : AbstractValidator<CreateEquipmentRequest>
    {
        public CreateEquipmentValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Description).NotEmpty();
            RuleFor(x => x.Status).NotEmpty();
            RuleFor(x => x.Maker).NotEmpty();
            RuleFor(x => x.FabricationDate).NotEmpty();
        }
    }
}
