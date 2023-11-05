using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApoloHealth.Application.UseCases.EquipmentOperations.Delete;

public sealed record DeleteEquipmentRequest(Guid Id) :
        IRequest<DeleteEquipmentResponse>;
