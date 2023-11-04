using ApoloHealth.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApoloHealth.Application.UseCases.CreateEquipment;

public sealed record CreateEquipmentRequest(
    string Name, 
    string Description,
    EquipmentStatus Status,
    string Maker,
    DateTime FabricationDate
    ) : IRequest<CreateEquipmentResponse>;
