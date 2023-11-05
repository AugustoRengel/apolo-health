using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApoloHealth.Domain.Entities;

public class Exam : BaseEntity
{
    public string? Title {  get; set; }
    public string? Description { get; set; }
    public int? DurationInMinutes { get; set; }
    public RoleType? RequiredEmployeeRole { get; set; }
    public EquipmentType? RequiredEquipmentType { get; set; }
}
