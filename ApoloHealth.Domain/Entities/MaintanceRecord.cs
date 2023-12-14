using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApoloHealth.Domain.Entities;

[Owned]
public class MaintanceRecord : BaseEntity
{
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set;}
    public EquipmentStatus InitialState { get; set; }
    public EquipmentStatus? FinalState { get; set; }
    public string ProblemDescription { get; set; }
    public string? SolutionDescription { get; set; }
    public bool WasDone { get; set; } = false;
    public MaintanceType Type { get; set; }

    public Guid EquipmentId { get; set; }
    public Guid EmployeeId { get; set; }
}

public enum MaintanceType
{
    Preventive = 1,
    Corrective = 2,
    Update = 3
}

