using FluentValidation;

namespace ApoloHealth.Application.UseCases.ExamOperations.Update;

public class UpdateExamValidator : AbstractValidator<UpdateExamRequest>
{
    public UpdateExamValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}
