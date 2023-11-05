using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApoloHealth.Domain.Entities;

public class Equipment : BaseEntity
{
    public string? Name { get; set; }
    public string? Description { get; set; }
    public EquipmentType? Type { get; set; }
    public EquipmentStatus? Status { get; set; }
    public string? Maker {  get; set; }
    public DateTime? FabricationDate { get; set; }
    public EquipmentSector? Sector { get; set; }
    public int? MonthsBetweenPreventive {  get; set; }
    public DateTime? LastPreventiveDate { get; set; }
    public int? MinutesOfPreventive { get; set; }

    public List<MaintanceRecord> MaintanceRecords { get; set; } = new();
}

public enum EquipmentStatus
{
    Operative = 1,
    Malfunctioning = 2,
    Inoperative = 3
}

public enum EquipmentSector
{
    AD = 1,  //Setor de Apoio Diagnóstico
    CC = 2,  //Centro Cirurgico
    DI = 3,  //Diagnóstico por Imagem
    PD = 4,  //Serviço de Pediatria
    AB = 5,  //Ambulatorio
    UT = 6,  //Unidade de Terapia Intensiva
    AT = 7,  //Setor de Apoio Terapêutico
    SS = 8   //Setor de Suprimentos
}

public enum EquipmentType
{
    Electrocardiograph = 1,
    Xray = 2
}