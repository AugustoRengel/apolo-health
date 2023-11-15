using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApoloHealth.Domain.Entities;

public class Customer : Person
{
    public DateTime? LastAppointment {  get; set; }
    public string? HealthInsurance { get; set; }
    public List<Appointment> Appointments { get; set; } = new();
}
