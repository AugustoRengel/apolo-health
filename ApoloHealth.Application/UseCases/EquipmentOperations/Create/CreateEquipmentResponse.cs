using ApoloHealth.Domain.Entities;

namespace ApoloHealth.Application.UseCases.EquipmentOperations.Create;

public sealed record CreateEquipmentResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public EquipmentStatus Status { get; set; }
    public string Maker { get; set; }
    public DateTime FabricationDate { get; set; }
    public List<MaintanceRecord>? MaintanceRecords { get; set; }
}

