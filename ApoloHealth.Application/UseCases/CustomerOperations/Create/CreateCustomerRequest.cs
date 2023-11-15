using ApoloHealth.Domain.Entities;
using MediatR;

namespace ApoloHealth.Application.UseCases.CustomerOperations.Create;

public sealed record CreateCustomerRequest(
    DateTime LastAppointment,
    string HealthInsurance,
    string Name,
    string CPF,
    DateTime BirthDate,
    string Email,
    string Phone,
    GenderType Gender,
    string Nationality,
    MaritalStatusType MaritalStatus
    ) : IRequest<CreateCustomerResponse>;
