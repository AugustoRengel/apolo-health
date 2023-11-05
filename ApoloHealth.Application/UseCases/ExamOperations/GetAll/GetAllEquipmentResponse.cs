using ApoloHealth.Domain.Entities;

namespace ApoloHealth.Application.UseCases.ExamOperations.GetAll;

public sealed record GetAllExamResponse
{
    public Guid Id { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    public int? DurationInMinutes { get; set; }
    public RoleType? RequiredEmployeeRole { get; set; }
    public EquipmentType? RequiredEquipmentType { get; set; }
}
