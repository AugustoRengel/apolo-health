using ApoloHealth.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApoloHealth.Application.UseCases.AppointmentOperations.Update;

public sealed record UpdateAppointmentRequest(
    Guid Id,
    string? Title,
    string? Description,
    int? RoomNumber,
    DateTime? StartDate,
    DateTime? EndDate,
    bool? WasDone,
    bool? RequiresTechnician,
    Guid? EquipmentId,
    Guid? EmployeeId,
    Guid? TechnicianId,
    Guid? ExamId,
    Guid? CustomerId
    ) : IRequest<UpdateAppointmentResponse>;