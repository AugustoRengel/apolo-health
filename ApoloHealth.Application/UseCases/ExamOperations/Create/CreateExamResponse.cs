using ApoloHealth.Domain.Entities;

namespace ApoloHealth.Application.UseCases.ExamOperations.Create;

public sealed record CreateExamResponse
{
    public Guid Id { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    public int? DurationInMinutes { get; set; }
    public RoleType? RequiredEmployeeRole { get; set; }
    public EquipmentType? RequiredEquipmentType { get; set; }
}

