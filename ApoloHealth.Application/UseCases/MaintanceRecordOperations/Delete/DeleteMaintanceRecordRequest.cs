using ApoloHealth.Application.UseCases.EquipmentOperations.Delete;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApoloHealth.Application.UseCases.MaintanceRecordOperations.Delete;

public sealed record DeleteMaintanceRecordRequest(Guid Id) :
        IRequest<DeleteMaintanceRecordResponse>;
