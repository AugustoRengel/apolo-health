using ApoloHealth.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApoloHealth.Application.UseCases.MaintanceRecordOperations.Create;

public sealed record CreateMaintanceRecordRequest(
    DateTime StartDate,
    DateTime EndDate,
    string Technician,
    EquipmentStatus InitialState,
    EquipmentStatus FinalState,
    string ProblemDescription,
    string SolutionDescription,
    bool? WasDone,
    MaintanceType Type,
    Guid EquipmentId
    ) : IRequest<CreateMaintanceRecordResponse>;
