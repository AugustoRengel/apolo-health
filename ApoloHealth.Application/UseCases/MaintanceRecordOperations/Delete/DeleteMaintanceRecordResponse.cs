using ApoloHealth.Domain.Entities;

namespace ApoloHealth.Application.UseCases.MaintanceRecordOperations.Delete;

public sealed record DeleteMaintanceRecordResponse
{
    public Guid Id { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public string? Technician { get; set; }
    public EquipmentStatus? InitialState { get; set; }
    public EquipmentStatus? FinalState { get; set; }
    public string? ProblemDescription { get; set; }
    public string? SolutionDescription { get; set; }
    public bool? WasDone { get; set; }
    public MaintanceType? Type { get; set; }

    public Guid EquipmentId { get; set; }
}
