using ApoloHealth.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApoloHealth.Application.UseCases.MaintanceRecordOperations.GetAll;

public sealed record GetAllMaintanceRecordResponse
{
    public Guid Id { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public EquipmentStatus? InitialState { get; set; }
    public EquipmentStatus? FinalState { get; set; }
    public string? ProblemDescription { get; set; }
    public string? SolutionDescription { get; set; }
    public bool? WasDone { get; set; }
    public MaintanceType? Type { get; set; }

    public Guid EquipmentId { get; set; }
    public Guid EmployeeId { get; set; }
}
