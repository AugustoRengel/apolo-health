using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApoloHealth.Application.UseCases.CreateEquipment
{
    public sealed class CreateEquipmentValidator : AbstractValidator<CreateEquipmentRequest>
    {
        public CreateEquipmentValidator() 
        { 
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Description).NotEmpty();
        }
    }
}
