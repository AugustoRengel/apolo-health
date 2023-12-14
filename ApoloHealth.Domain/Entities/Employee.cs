namespace ApoloHealth.Domain.Entities;

public class Employee : Person
{
    public RoleType? Role { get; set; }
    public decimal? Wage { get; set; }

    public List<Appointment> Appointments { get; set; } = new();
    public List<Equipment> Equipments { get; set; } = new();
    public List<MaintanceRecord> MaintanceRecords { get; set; } = new();
}

public enum RoleType
{
    Doctor = 1,
    Technician = 2,
    Attendant = 3,
    Nurse = 4
}