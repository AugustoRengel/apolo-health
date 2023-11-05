using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApoloHealth.Domain.Entities;

public class Person : BaseEntity
{
    public string? Name { get; set; }
    public string? CPF {  get; set; }
    public DateTime? BirthDate { get; set; }
    public string? Email { get; set; }
    public string? Phone { get; set; }
    public bool? Gender { get; set; }
    public string? Nationality { get; set; }
    public string? MaritalStatus { get; set; }

    public List<Address> Addresses { get; set; } = new List<Address>();

}
