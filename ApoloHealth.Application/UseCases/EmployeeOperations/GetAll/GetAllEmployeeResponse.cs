using ApoloHealth.Domain.Entities;

namespace ApoloHealth.Application.UseCases.EmployeeOperations.GetAll;

public sealed record GetAllEmployeeResponse
{
    public Guid Id { get; set; }

    public RoleType? Role { get; set; }
    public decimal? Wage { get; set; }

    public string? Name { get; set; }
    public string? CPF { get; set; }
    public DateTime? BirthDate { get; set; }
    public string? Email { get; set; }
    public string? Phone { get; set; }
    public GenderType? Gender { get; set; }
    public string? Nationality { get; set; }
    public MaritalStatusType? MaritalStatus { get; set; }

    public List<Address>? Addresses { get; set; }
    public List<EquipmentDTO>? EquipmentsDTO { get; set; }
}
public sealed record EquipmentDTO
{
    public Guid Id { get; set; }

    public string? Name { get; set; }
    public string? Description { get; set; }
    public EquipmentType? Type { get; set; }
    public EquipmentStatus? Status { get; set; }
    public string? Maker { get; set; }
    public DateTime? FabricationDate { get; set; }
    public EquipmentSector? Sector { get; set; }
    public int? MonthsBetweenPreventive { get; set; }
    public DateTime? LastPreventiveDate { get; set; }
    public int? MinutesOfPreventive { get; set; }

    public bool RequiresTechnician { get; set; }
}
