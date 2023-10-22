namespace ApoloHealth.Application.UseCases.CreateEquipment;

public sealed record CreateEquipmentResponse
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
}

