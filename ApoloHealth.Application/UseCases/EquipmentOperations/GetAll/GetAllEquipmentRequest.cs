using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApoloHealth.Application.UseCases.ExamOperations.GetAll
{
    public sealed record GetAllEquipmentRequest : IRequest<List<GetAllEquipmentResponse>>;
}
