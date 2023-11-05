using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApoloHealth.Domain.Entities;

public class Exam : BaseEntity
{
    public int? DurationInMinutes { get; set; }
    public List<EquipmentType>? RequiredEquipmentsTypes { get; set; }
    public List<RoleType>? RequiredEmployeesRoles { get; set; }
}
