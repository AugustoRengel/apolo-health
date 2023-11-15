using ApoloHealth.Domain.Entities;
using System.Text.Json.Serialization;

namespace ApoloHealth.Application.UseCases.AddressOperations.Create;

public sealed record CreateAddressResponse
{
    public Guid Id { get; set; }
    public string Street { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string PostalCode { get; set; }
    public string Country { get; set; }

    public Guid PersonId { get; set; }
}

