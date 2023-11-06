using FluentValidation;

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
