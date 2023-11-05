using ApoloHealth.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApoloHealth.Application.UseCases.MaintanceRecordOperations.Delete;

public sealed record DeleteMaintanceRecordResponse
{
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public string? Technician { get; set; }
    public EquipmentStatus? InitialState { get; set; }
    public EquipmentStatus? FinalState { get; set; }
    public string? ProblemDescription { get; set; }
    public string? SolutionDescription { get; set; }

    public Guid EquipmentId { get; set; }
}
