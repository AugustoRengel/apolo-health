using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ApoloHealth.Domain.Entities;

public abstract class Person : BaseEntity
{
    public string? Name { get; set; }
    public string? CPF {  get; set; }
    public DateTime? BirthDate { get; set; }
    public string? Email { get; set; }
    public string? Phone { get; set; }
    public GenderType? Gender { get; set; }
    public string? Nationality { get; set; }
    public MaritalStatusType? MaritalStatus { get; set; }

    [JsonIgnore]
    public List<Address>? Addresses { get; set; } = new();

}

public enum GenderType
{
    Male = 1,
    Female = 2
}

public enum MaritalStatusType
{
    Single = 1,
    Married = 2,
    Divorced = 3,
    Widowed = 4,
    Separated = 5,
    Other = 6
}
