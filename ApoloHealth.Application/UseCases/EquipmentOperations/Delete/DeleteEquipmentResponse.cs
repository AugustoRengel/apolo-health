using ApoloHealth.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApoloHealth.Application.UseCases.ExamOperations.Delete;

public sealed record DeleteEquipmentResponse
{
    public Guid Id { get; set; }

    public string? Code { get; set; }
    public string? Description { get; set; }
    public EquipmentType? Type { get; set; }
    public EquipmentStatus? Status { get; set; }
    public string? Maker { get; set; }
    public DateTime? FabricationDate { get; set; }
    public EquipmentSector? Sector { get; set; }
    public int? MonthsBetweenPreventive { get; set; }
    public DateTime? LastPreventiveDate { get; set; }
    public int? MinutesOfPreventive { get; set; }

    public List<Employee>? Technicians { get; set; }
    public List<MaintanceRecord>? MaintanceRecords { get; set; }
    public List<Appointment>? Appointments { get; set; }
}
