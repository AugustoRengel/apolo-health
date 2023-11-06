using ApoloHealth.Domain.Entities;
using MediatR;

namespace ApoloHealth.Application.UseCases.EmployeeOperations.Update;

public sealed record UpdateEmployeeRequest(
    Guid Id,
    RoleType? Role,
    decimal? Wage,
    string? Name,
    string? CPF,
    DateTime? BirthDate,
    string? Email,
    string? Phone,
    GenderType? Gender,
    string? Nationality,
    MaritalStatusType? MaritalStatus,
    List<Address>? Addresses
    ) : IRequest<UpdateEmployeeResponse>;