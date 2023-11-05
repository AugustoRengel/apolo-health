﻿using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApoloHealth.Application.UseCases.ExamOperations.Create
{
    public sealed class CreateEquipmentValidator : AbstractValidator<CreateEquipmentRequest>
    {
        public CreateEquipmentValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Description).NotEmpty();
            RuleFor(x => x.Type).NotEmpty();
            RuleFor(x => x.Status).NotEmpty();
            RuleFor(x => x.Maker).NotEmpty();
            RuleFor(x => x.FabricationDate).NotEmpty();
            RuleFor(x => x.Sector).NotEmpty();
            RuleFor(x => x.MonthsBetweenPreventive).NotEmpty();
            RuleFor(x => x.MinutesOfPreventive).NotEmpty();
            RuleFor(x => x.RequiresTechnician).NotEmpty();
        }
    }
}
