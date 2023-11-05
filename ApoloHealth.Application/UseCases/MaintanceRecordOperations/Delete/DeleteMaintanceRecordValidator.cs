using FluentValidation;

namespace ApoloHealth.Application.UseCases.MaintanceRecordOperations.Delete;

public class DeleteMaintanceRecordValidator : AbstractValidator<DeleteMaintanceRecordRequest>
{
    public DeleteMaintanceRecordValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}
