using ApoloHealth.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApoloHealth.Application.UseCases.DeleteEquipment;

public sealed record DeleteEquipmentResponse
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public EquipmentStatus? Status { get; set; }
    public string? Maker { get; set; }
    public DateTime? FabricationDate { get; set; }
    public List<MaintanceRecord>? MaintanceRecords { get; set; }
}
