using ApoloHealth.Application.UseCases.EquipmentOperations.Delete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApoloHealth.Application.UseCases.MaintanceRecordOperations.Delete;

public class DeleteMaintanceRecordValidator : AbstractValidator<DeleteMaintanceRecordRequest>
{
    public DeleteMaintanceRecordValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}
