using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApoloHealth.Domain.Entities
{
    public class Equipment : BaseEntity
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public EquipmentStatus? Status { get; set; }
        public string? Maker {  get; set; }
        public DateTime? FabricationDate { get; set; }

        public List<MaintanceRecord> MaintanceRecords { get; set; } = new();
    }

    public enum EquipmentStatus
    {
        Operative = 1,
        Malfunctioning = 2,
        Inoperative = 3
    }
}
