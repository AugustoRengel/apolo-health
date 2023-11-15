using System.Text.Json.Serialization;

namespace ApoloHealth.Domain.Entities;

public class Address : BaseEntity
{
    public string? Street { get; set; }
    public string? City { get; set; }
    public string? State { get; set; }
    public string? PostalCode { get; set; }
    public string? Country { get; set; }

    [JsonIgnore]
    public Guid? PersonId { get; set; }
    [JsonIgnore]
    public Person? Person { get; set; }
}
