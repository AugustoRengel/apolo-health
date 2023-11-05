using ApoloHealth.Application.UseCases.ExamOperations.Create;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApoloHealth.Application.UseCases.ExamOperations.Create
{
    public sealed class CreateExamValidator : AbstractValidator<CreateExamRequest>
    {
        public CreateExamValidator()
        {
            RuleFor(x => x.Title).NotEmpty();
            RuleFor(x => x.Description).NotEmpty();
            RuleFor(x => x.DurationInMinutes).NotEmpty();
        }
    }
}
