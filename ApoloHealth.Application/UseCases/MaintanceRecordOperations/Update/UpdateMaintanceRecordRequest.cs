﻿using ApoloHealth.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApoloHealth.Application.UseCases.MaintanceRecordOperations.Update;

public sealed record UpdateMaintanceRecordRequest(
    Guid Id,
    DateTime? StartDate,
    DateTime? EndDate,
    EquipmentStatus? InitialState,
    EquipmentStatus? FinalState,
    string? ProblemDescription,
    string? SolutionDescription,
    bool? WasDone,
    MaintanceType? Type
    ) : IRequest<UpdateMaintanceRecordResponse>;
