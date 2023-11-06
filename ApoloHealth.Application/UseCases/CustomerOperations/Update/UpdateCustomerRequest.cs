using ApoloHealth.Domain.Entities;
using MediatR;

namespace ApoloHealth.Application.UseCases.CustomerOperations.Update;

public sealed record UpdateCustomerRequest(
    Guid Id,
    DateTime? LastAppointment,
    string? HealthInsurance,
    string? Name,
    string? CPF,
    DateTime? BirthDate,
    string? Email,
    string? Phone,
    GenderType? Gender,
    string? Nationality,
    MaritalStatusType? MaritalStatus,
    List<Address>? Addresses
    ) : IRequest<UpdateCustomerResponse>;