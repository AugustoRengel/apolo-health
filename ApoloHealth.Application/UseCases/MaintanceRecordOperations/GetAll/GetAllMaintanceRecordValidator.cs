using ApoloHealth.Application.UseCases.EquipmentOperations.GetAll;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApoloHealth.Application.UseCases.MaintanceRecordOperations.GetAll;

public class GetAllMaintanceRecordValidator : AbstractValidator<GetAllMaintanceRecordRequest>
{
    public GetAllMaintanceRecordValidator()
    {
        // without validation
    }

}
