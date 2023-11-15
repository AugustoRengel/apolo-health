using ApoloHealth.Domain.Entities;

namespace ApoloHealth.Application.UseCases.AppointmentOperations.Create;

public sealed record CreateAppointmentResponse
{
    public Guid Id { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    public int? RoomNumber { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public bool WasDone { get; set; }
    public bool RequiresTechnician { get; set; }

    public Guid? EquipmentId { get; set; }
    public Guid? EmployeeId { get; set; }
    public Guid? Technician { get; set; }
    public Guid? ExamId { get; set; }
    public Guid? CustomerId { get; set; }
}

