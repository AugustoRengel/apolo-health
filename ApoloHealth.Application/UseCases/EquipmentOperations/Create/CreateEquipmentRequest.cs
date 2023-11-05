using ApoloHealth.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApoloHealth.Application.UseCases.EquipmentOperations.Create;

public sealed record CreateEquipmentRequest(
    string Name,
    string Description,
    EquipmentType Type,
    EquipmentStatus Status,
    string Maker,
    DateTime FabricationDate,
    EquipmentSector Sector,
    int MonthsBetweenPreventive,
    DateTime? LastPreventiveDate,
    int MinutesOfPreventive
    ) : IRequest<CreateEquipmentResponse>;
