using ApoloHealth.Domain.Entities;

namespace ApoloHealth.Application.UseCases.CustomerOperations.GetAll;

public sealed record GetAllCustomerResponse
{
    public Guid Id { get; set; }

    public DateTime? LastAppointment { get; set; }
    public string? HealthInsurance { get; set; }

    public string? Name { get; set; }
    public string? CPF { get; set; }
    public DateTime? BirthDate { get; set; }
    public string? Email { get; set; }
    public string? Phone { get; set; }
    public GenderType? Gender { get; set; }
    public string? Nationality { get; set; }
    public MaritalStatusType? MaritalStatus { get; set; }

    public List<Address> Addresses { get; set; }
    public List<AppointmentDTO> AppointmentsDTO { get; set; }
}
public sealed record AppointmentDTO
{
    public Guid Id { get; set; }

    public string? Title { get; set; }
    public string? Description { get; set; }
    public int? RoomNumber { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public bool? WasDone { get; set; }
    public Guid? ExamId { get; set; }
    public Guid? CustomerId { get; set; }
}
