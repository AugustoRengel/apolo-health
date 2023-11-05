using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApoloHealth.Domain.Entities;

public class Employee : Person
{
    public RoleType? Role { get; set; }
    public decimal? Wage { get; set; }

    public List<Appointment> Appointments { get; set; } = new List<Appointment>();
}

public enum RoleType
{
    Doctor = 1,
    Technician = 2,
    Attendant = 3
}