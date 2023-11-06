using ApoloHealth.Domain.Entities;
using MediatR;

namespace ApoloHealth.Application.UseCases.ExamOperations.Create;

public sealed record CreateExamRequest(
    string Title,
    string Description,
    int DurationInMinutes,
    RoleType? RequiredEmployeeRole,
    EquipmentType? RequiredEquipmentType
    ) : IRequest<CreateExamResponse>;
