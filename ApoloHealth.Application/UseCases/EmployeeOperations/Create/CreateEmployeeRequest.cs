using ApoloHealth.Domain.Entities;
using MediatR;

namespace ApoloHealth.Application.UseCases.EmployeeOperations.Create;

public sealed record CreateEmployeeRequest(
    RoleType Role,
    decimal Wage,
    string Name,
    string CPF,
    DateTime BirthDate,
    string Email,
    string Phone,
    GenderType Gender,
    string Nationality,
    MaritalStatusType MaritalStatus,
    List<Address> Addresses
    ) : IRequest<CreateEmployeeResponse>;
