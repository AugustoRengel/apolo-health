using ApoloHealth.Domain.Entities;
using MediatR;

namespace ApoloHealth.Application.UseCases.AppointmentOperations.Create;

public sealed record CreateAppointmentRequest(
    string Title,
    string Description,
    int RoomNumber,
    DateTime StartDate,
    DateTime EndDate,
    bool WasDone,
    bool RequiresTechnician,
    Guid? EquipmentId,
    Guid EmployeeId,
    Guid ExamId,
    Guid CustomerId
    ) : IRequest<CreateAppointmentResponse>;
