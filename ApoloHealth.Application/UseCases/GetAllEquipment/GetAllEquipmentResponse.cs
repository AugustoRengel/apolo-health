namespace ApoloHealth.Application.UseCases.GetAllEquipment;

public sealed record GetAllEquipmentResponse
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
}
