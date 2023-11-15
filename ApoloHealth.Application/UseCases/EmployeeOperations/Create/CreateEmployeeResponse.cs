using ApoloHealth.Domain.Entities;

namespace ApoloHealth.Application.UseCases.EmployeeOperations.Create;

public sealed record CreateEmployeeResponse
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
}

