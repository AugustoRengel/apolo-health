using ApoloHealth.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApoloHealth.Application.UseCases.ExamOperations.Update;

public sealed record UpdateExamRequest(
    Guid Id,
    string? Title,
    string? Description,
    int? DurationInMinutes,
    RoleType? RequiredEmployeeRole,
    EquipmentType? RequiredEquipmentType
    ) : IRequest<UpdateExamResponse>;