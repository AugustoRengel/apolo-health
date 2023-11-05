using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApoloHealth.Application.UseCases.ExamOperations.GetAll
{
    public class GetAllEquipmentValidator : AbstractValidator<GetAllEquipmentRequest>
    {
        public GetAllEquipmentValidator()
        {
            // without validation
        }

    }
}
