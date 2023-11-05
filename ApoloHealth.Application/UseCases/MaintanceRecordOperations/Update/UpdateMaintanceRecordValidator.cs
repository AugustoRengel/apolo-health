using ApoloHealth.Application.UseCases.ExamOperations.Update;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApoloHealth.Application.UseCases.MaintanceRecordOperations.Update;

public class UpdateMaintanceRecordValidator : AbstractValidator<UpdateMaintanceRecordRequest>
{
    public UpdateMaintanceRecordValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}
