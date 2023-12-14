using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApoloHealth.Domain.Entities;

public class Equipment : BaseEntity
{
    public string Code { get; set; }
    public string Description { get; set; }
    public EquipmentType Type { get; set; }
    public EquipmentStatus Status { get; set; }
    public string Maker {  get; set; }
    public DateTime FabricationDate { get; set; }
    public EquipmentSector Sector { get; set; }
    public int MonthsBetweenPreventive {  get; set; }
    public DateTime LastPreventiveDate { get; set; }
    public int MinutesOfPreventive { get; set; }

    public List<Employee> Technicians { get; set; } = new();
    public List<MaintanceRecord> MaintanceRecords { get; set; } = new();
    public List<Appointment> Appointments { get; set; } = new();
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
    [Description("EB")]
    ElectricScalpel = 1,
    [Description("BV")]
    VacuumPump = 2,
    [Description("CD")]
    Defibrillator = 3,
    [Description("EC")]
    Electrocardiograph = 4,
    [Description("EE")]
    Electroencephalograph = 5,
    [Description("ME")]
    SurgicalTable = 6,
    [Description("MF")]
    PhysiologicalMonitor = 7,
    [Description("AR")]
    XRayMachine = 8,
    [Description("BC")]
    Bronchoscope = 9,
    [Description("MM")]
    MammographyMachine = 10,
    [Description("PR")]
    XRayProcessor = 11
}