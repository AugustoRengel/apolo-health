using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApoloHealth.Domain.Entities;

public class Appointment : BaseEntity
{
    public string? Title { get; set; }
    public string? Description { get; set; }
    public int? RoomNumber { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public bool? WasDone { get; set; }
    public bool? RequiresTechnician { get; set; }

    public bool HasNotification { get; set; } = false;
    public bool NeedsRescheduling {  get; set; } = false;
    public string? Notification {  get; set; }

    public Guid? EquipmentId { get; set; }
    public Guid? EmployeeId { get; set; }
    public Guid? TechnicianId {  get; set; }
    public Guid? ExamId { get; set; }
    public Guid? CustomerId { get; set; }
}
