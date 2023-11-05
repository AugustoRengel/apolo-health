using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApoloHealth.Application.UseCases.MaintanceRecordOperations.Create;

public sealed class ClassValidator : AbstractValidator<CreateMaintanceRecordRequest>
{
    public ClassValidator()
    {
        RuleFor(x => x.StartDate).NotEmpty();
        RuleFor(x => x.EndDate).NotEmpty();
        RuleFor(x => x.Technician).NotEmpty();
        RuleFor(x => x.InitialState).NotEmpty();
        RuleFor(x => x.FinalState).NotEmpty();
        RuleFor(x => x.ProblemDescription).NotEmpty();
        RuleFor(x => x.SolutionDescription).NotEmpty();
        RuleFor(x => x.Type).NotEmpty();
        RuleFor(x => x.EquipmentId).NotEmpty();
    }
}
