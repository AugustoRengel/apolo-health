using ApoloHealth.Application.UseCases.CreateEquipment;
using ApoloHealth.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApoloHealth.Application.UseCases.UpdateEquipment;

public sealed record UpdateEquipmentRequest(
    Guid Id, 
    string? Name, 
    string? Description, 
    EquipmentStatus? Status, 
    string? Maker, 
    DateTime? FabricationDate,
    List<MaintanceRecordDTO>? MaintanceRecordsDTO
    ) : IRequest<UpdateEquipmentResponse>;

public sealed record MaintanceRecordDTO(
    DateTime StartDate,
    DateTime EndDate,
    string Technician,
    EquipmentStatus InitialState,
    EquipmentStatus FinalState,
    string ProblemDescription,
    string SolutionDescription,
    Guid EquipmentId
    );