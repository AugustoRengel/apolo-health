﻿using ApoloHealth.Domain.Entities;

namespace ApoloHealth.Application.UseCases.CustomerOperations.Update;

public sealed record UpdateCustomerResponse
{
    public Guid Id { get; set; }

    public DateTime? LastAppointment { get; set; }
    public string? HealthInsurance { get; set; }

    public string? Name { get; set; }
    public string? CPF { get; set; }
    public DateTime? BirthDate { get; set; }
    public string? Email { get; set; }
    public string? Phone { get; set; }
    public GenderType? Gender { get; set; }
    public string? Nationality { get; set; }
    public MaritalStatusType? MaritalStatus { get; set; }

    public List<Address> Addresses { get; set; }
}
