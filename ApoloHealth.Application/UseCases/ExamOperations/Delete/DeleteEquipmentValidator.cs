using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApoloHealth.Application.UseCases.ExamOperations.Delete;

public class DeleteExamValidator : AbstractValidator<DeleteExamRequest>
{
    public DeleteExamValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}
