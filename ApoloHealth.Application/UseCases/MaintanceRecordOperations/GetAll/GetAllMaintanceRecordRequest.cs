using ApoloHealth.Application.UseCases.ExamOperations.GetAll;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApoloHealth.Application.UseCases.MaintanceRecordOperations.GetAll;

public sealed record GetAllMaintanceRecordRequest : IRequest<List<GetAllMaintanceRecordResponse>>;
