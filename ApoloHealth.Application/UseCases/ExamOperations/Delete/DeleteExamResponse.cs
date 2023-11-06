using ApoloHealth.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApoloHealth.Application.UseCases.ExamOperations.Delete;

public sealed record DeleteExamResponse
{
    public Guid Id { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    public int? DurationInMinutes { get; set; }
    public RoleType? RequiredEmployeeRole { get; set; }
    public EquipmentType? RequiredEquipmentType { get; set; }
}
