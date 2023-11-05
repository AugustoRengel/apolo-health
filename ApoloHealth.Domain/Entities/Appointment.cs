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

    public List<Equipment> Equipments { get; set; } = new();
    public List<Employee> Employees { get; set; } = new();

    public Guid? ExamId { get; set; }
    public Guid? CustomerId { get; set; }
}
