using ApoloHealth.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace ApoloHealth.Persistence.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    { }
    public DbSet<Equipment> Equipments { get; set; }
    public DbSet<MaintanceRecord> MaintanceRecords { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Address> Addresses { get; set; }
    public DbSet<Appointment> Appointments { get; set; }
    public DbSet<Exam> Exams { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Equipment>()
            .HasMany(a => a.MaintanceRecords);
        builder.Entity<Equipment>()
            .HasMany(a => a.Appointments);

        builder.Entity<Employee>()
            .HasMany(a => a.MaintanceRecords);
        builder.Entity<Employee>()
            .HasMany(a => a.Appointments);

        builder.Entity<Address>()
            .HasOne(a => a.Person)
            .WithMany(a => a.Addresses)
            .HasForeignKey("PersonId");

        PopulateDb(builder);
    }

    protected void PopulateDb(ModelBuilder builder)
    {
        Dictionary<string, Guid> idOfEmployee = new() 
        {
            { "Augusto", Guid.NewGuid() },  //Tec
            { "Isabel", Guid.NewGuid() },   //Doc
            { "Alice", Guid.NewGuid() },    //Tec
            { "Carlos", Guid.NewGuid() },   //Doc
            { "Fernanda", Guid.NewGuid() }, //Nur
            { "Gustavo", Guid.NewGuid() },  //Tec
            { "Mariana", Guid.NewGuid() },  //Doc
            { "Pedro", Guid.NewGuid() },    //Nur
            { "Camila", Guid.NewGuid() },   //Tec
            { "Rafael", Guid.NewGuid() },   //Doc
            { "Júlia", Guid.NewGuid() },    //Nur
            { "Luis", Guid.NewGuid() },     //Tec
        };

        builder.Entity<Employee>()
            .HasData(
            new Employee
            {
                Id = idOfEmployee["Augusto"],
                Name = "Augusto",
                CPF = "123.123.123.12",
                BirthDate = DateTime.Parse("07/09/1998", new CultureInfo("pt-BR")),
                Email = "augusto@email.com",
                Phone = "123456",
                Gender = GenderType.Male,
                Nationality = "BR",
                MaritalStatus = MaritalStatusType.Single,
                Role = RoleType.Technician,
                Wage = 3500
            },
            new Employee
            {
                Id = idOfEmployee["Isabel"],
                Name = "Isabel",
                CPF = "321.321.321.32",
                BirthDate = DateTime.Parse("26/08/2000", new CultureInfo("pt-BR")),
                Email = "isabel@email.com",
                Phone = "321456",
                Gender = GenderType.Male,
                Nationality = "BR",
                MaritalStatus = MaritalStatusType.Single,
                Role = RoleType.Doctor,
                Wage = 3000,
                DateCreated = DateTime.Parse($"04/02/2023 12:00", new CultureInfo("pt-BR"))
            },
            new Employee
            {
                Id = idOfEmployee["Alice"],
                Name = "Alice",
                CPF = "444.555.666.77",
                BirthDate = DateTime.Parse("10/05/1995", new CultureInfo("pt-BR")),
                Email = "alice@email.com",
                Phone = "123789",
                Gender = GenderType.Female,
                Nationality = "BR",
                MaritalStatus = MaritalStatusType.Single,
                Role = RoleType.Technician,
                Wage = 3800,
                DateCreated = DateTime.Parse($"04/02/2023 12:00", new CultureInfo("pt-BR"))
            },
            new Employee
            {
                Id = idOfEmployee["Carlos"],
                Name = "Carlos",
                CPF = "999.888.777.66",
                BirthDate = DateTime.Parse("02/12/1987", new CultureInfo("pt-BR")),
                Email = "carlos@email.com",
                Phone = "456789",
                Gender = GenderType.Male,
                Nationality = "BR",
                MaritalStatus = MaritalStatusType.Married,
                Role = RoleType.Doctor,
                Wage = 4200,
                DateCreated = DateTime.Parse($"04/02/2023 12:00", new CultureInfo("pt-BR"))
            },
            new Employee
            {
                Id = idOfEmployee["Fernanda"],
                Name = "Fernanda",
                CPF = "111.222.333.44",
                BirthDate = DateTime.Parse("25/09/1992", new CultureInfo("pt-BR")),
                Email = "fernanda@email.com",
                Phone = "987123",
                Gender = GenderType.Female,
                Nationality = "BR",
                MaritalStatus = MaritalStatusType.Single,
                Role = RoleType.Nurse,
                Wage = 3900,
                DateCreated = DateTime.Parse($"04/02/2023 12:00", new CultureInfo("pt-BR"))
            },
            new Employee
            {
                Id = idOfEmployee["Gustavo"],
                Name = "Gustavo",
                CPF = "555.666.777.88",
                BirthDate = DateTime.Parse("18/06/1985", new CultureInfo("pt-BR")),
                Email = "gustavo@email.com",
                Phone = "654789",
                Gender = GenderType.Male,
                Nationality = "BR",
                MaritalStatus = MaritalStatusType.Married,
                Role = RoleType.Technician,
                Wage = 3600,
                DateCreated = DateTime.Parse($"04/02/2023 12:00", new CultureInfo("pt-BR"))
            },
            new Employee
            {
                Id = idOfEmployee["Mariana"],
                Name = "Mariana",
                CPF = "777.888.999.00",
                BirthDate = DateTime.Parse("12/11/1990", new CultureInfo("pt-BR")),
                Email = "mariana@email.com",
                Phone = "789456",
                Gender = GenderType.Female,
                Nationality = "BR",
                MaritalStatus = MaritalStatusType.Single,
                Role = RoleType.Doctor,
                Wage = 4100,
                DateCreated = DateTime.Parse($"04/02/2023 12:00", new CultureInfo("pt-BR"))
            },
            new Employee
            {
                Id = idOfEmployee["Pedro"],
                Name = "Pedro",
                CPF = "333.444.555.66",
                BirthDate = DateTime.Parse("05/04/1983", new CultureInfo("pt-BR")),
                Email = "pedro@email.com",
                Phone = "987456",
                Gender = GenderType.Male,
                Nationality = "BR",
                MaritalStatus = MaritalStatusType.Married,
                Role = RoleType.Nurse,
                Wage = 3800,
                DateCreated = DateTime.Parse($"04/02/2023 12:00", new CultureInfo("pt-BR"))
            },
            new Employee
            {
                Id = idOfEmployee["Camila"],
                Name = "Camila",
                CPF = "666.777.888.99",
                BirthDate = DateTime.Parse("29/01/1988", new CultureInfo("pt-BR")),
                Email = "camila@email.com",
                Phone = "123987",
                Gender = GenderType.Female,
                Nationality = "BR",
                MaritalStatus = MaritalStatusType.Single,
                Role = RoleType.Technician,
                Wage = 3900,
                DateCreated = DateTime.Parse($"04/02/2023 12:00", new CultureInfo("pt-BR"))
            },
            new Employee
            {
                Id = idOfEmployee["Rafael"],
                Name = "Rafael",
                CPF = "222.333.444.55",
                BirthDate = DateTime.Parse("14/08/1980", new CultureInfo("pt-BR")),
                Email = "rafael@email.com",
                Phone = "654123",
                Gender = GenderType.Male,
                Nationality = "BR",
                MaritalStatus = MaritalStatusType.Married,
                Role = RoleType.Doctor,
                Wage = 4200,
                DateCreated = DateTime.Parse($"04/02/2023 12:00", new CultureInfo("pt-BR"))
            },
            new Employee
            {
                Id = idOfEmployee["Júlia"],
                Name = "Júlia",
                CPF = "888.999.000.11",
                BirthDate = DateTime.Parse("07/03/1986", new CultureInfo("pt-BR")),
                Email = "julia@email.com",
                Phone = "321987",
                Gender = GenderType.Female,
                Nationality = "BR",
                MaritalStatus = MaritalStatusType.Single,
                Role = RoleType.Nurse,
                Wage = 3600,
                DateCreated = DateTime.Parse($"04/02/2023 12:00", new CultureInfo("pt-BR"))
            },
            new Employee
            {
                Id = idOfEmployee["Luis"],
                Name = "Luis",
                CPF = "111.222.333.44",
                BirthDate = DateTime.Parse("20/10/1981", new CultureInfo("pt-BR")),
                Email = "luis@email.com",
                Phone = "987654",
                Gender = GenderType.Male,
                Nationality = "BR",
                MaritalStatus = MaritalStatusType.Married,
                Role = RoleType.Technician,
                Wage = 4000,
                DateCreated = DateTime.Parse($"04/02/2023 12:00", new CultureInfo("pt-BR"))
            }
            );

        Dictionary<string, Guid> idOfCustomer = new();
        List<Customer> customerList = new List<Customer>();
        for(int i = 1; i <= 10; i++)
        {
            idOfCustomer.Add($"customer_{i}", Guid.NewGuid());

            customerList.Add(
                new Customer
                {
                    Id = idOfCustomer[$"customer_{i}"],
                    Name = $"Customer_{i}",
                    CPF = $"{i}00.{i}00.000.42",
                    BirthDate = DateTime.Parse($"{i:D2}/{i:D2}/1997", new CultureInfo("pt-BR")),
                    Email = $"Customer_{i}@email.com",
                    Phone = "555456",
                    Gender = i % 2 == 0 ? GenderType.Male : GenderType.Female,
                    Nationality = "BR",
                    MaritalStatus = MaritalStatusType.Single,

                    LastAppointment = DateTime.Parse($"{i:D2}/{i:D2}/2020", new CultureInfo("pt-BR")),
                    HealthInsurance = "Unimed",
                    DateCreated = DateTime.Parse($"04/02/2023 12:00", new CultureInfo("pt-BR"))
                }
                );
        }
        builder.Entity<Customer>().HasData(customerList);

        List<Address> addresses = new List<Address>();
        Dictionary<string, Guid> ids = idOfEmployee.Union(idOfCustomer).ToDictionary(pair => pair.Key, pair => pair.Value);
        foreach(var id in ids)
        {
            addresses.Add(
                new Address
                {
                    Id = Guid.NewGuid(),
                    PersonId = id.Value,
                    Street = $"rua_{id.Key}",
                    City = "São José dos Campos",
                    State = "São Paulo",
                    PostalCode = "12215-300",
                    Country = "BR",
                    DateCreated = DateTime.Parse($"04/02/2023 12:00", new CultureInfo("pt-BR"))
                }
                );
        }
        builder.Entity<Address>().HasData(addresses);

        List<Equipment> equipmentList = new();
        List<string> codevalues = new()
        {
            "CC-BE0001", "CC-BE0002", "CC-BE0003", "CC-BV0001", "CC-BV0002",
            "CC-CD0001", "CC-EC0001", "CC-EC0002", "CC-EE0001", "CC-ME0001",
            "CC-MF0001", "CC-AR0001", "CC-BC0001", "CC-MM0001", "CC-PR0001"
        };
        List<string> typeValues = new() { "1", "1", "1", "2", "2", "3", "4", "4", "5", "6", "7", "8", "9", "10", "11" }; // 15 Equipments
        List<string> sectorvalues = new() { "2", "2", "2", "2", "2", "2", "2", "2", "2", "2", "2", "3", "3", "3", "3" };
        List<string> makerValues = new() { "Siemens Healthineers", "Philips Healthcare", "Medtronic", "Stryker" };
        List<int> mbpValues = new() { 4, 4, 4, 30, 30, 10, 6, 6, 3, 8, 8, 9, 4, 5, 3 };
        List<int> mopValues = new() { 180, 180, 180, 120, 120, 180, 240, 240, 120, 120, 120, 600, 180, 480, 180 };
        List<Guid> equipmentsGuids = new();

        DateTime fabricationDate = DateTime.Parse("07/09/2022", new CultureInfo("pt-BR"));
        for (int i = 0; i < 15; i++)
        {
            equipmentsGuids.Add(Guid.NewGuid());
            Equipment tempEquipment = new Equipment
            {
                Id = equipmentsGuids[i],
                Code = codevalues[i],
                Description = "Description of the equipment",
                Type = (EquipmentType)Enum.Parse(typeof(EquipmentType), typeValues[i]),
                Status = EquipmentStatus.Operative,
                Maker = makerValues[i % 4],
                FabricationDate = fabricationDate,
                Sector = (EquipmentSector)Enum.Parse(typeof(EquipmentSector), sectorvalues[i]),
                MonthsBetweenPreventive = mbpValues[i],
                LastPreventiveDate = fabricationDate,
                MinutesOfPreventive = mopValues[i],
                DateCreated = DateTime.Parse($"04/02/2023 12:00", new CultureInfo("pt-BR"))
            };

            equipmentList.Add(tempEquipment);
        }
        builder.Entity<Equipment>().HasData(equipmentList);

        builder.Entity<MaintanceRecord>()
            .HasData(
            new MaintanceRecord
            {
                Id = Guid.NewGuid(),
                StartDate = DateTime.Parse("05/10/2022 12:00", new CultureInfo("pt-BR")),
                EndDate = DateTime.Parse("05/10/2022 18:00", new CultureInfo("pt-BR")),
                InitialState = EquipmentStatus.Operative,
                FinalState = EquipmentStatus.Operative,
                ProblemDescription = "revisão periodica",
                SolutionDescription = "tudo certo",
                WasDone = true,
                Type = MaintanceType.Preventive,
                EquipmentId = equipmentsGuids[0],
                EmployeeId = idOfEmployee["Augusto"],
                DateCreated = DateTime.Parse($"04/02/2023 12:00", new CultureInfo("pt-BR"))
            }
            );

        builder.Entity<Exam>()
            .HasData(
            new Exam
            {
                Id = Guid.NewGuid(),
                Title = "Exame de raio-x",
                Description = "usa raio-x",
                DurationInMinutes = 30,
                RequiredEmployeeRole = RoleType.Doctor,
                RequiredEquipmentType = EquipmentType.XRayMachine,
                DateCreated = DateTime.Parse($"04/02/2023 12:00", new CultureInfo("pt-BR"))
            },
            new Exam
            {
                Id = Guid.NewGuid(),
                Title = "Cirurgia de Apêndice",
                Description = "",
                DurationInMinutes = 180,
                RequiredEmployeeRole = RoleType.Doctor,
                RequiredEquipmentType = EquipmentType.ElectricScalpel,
                DateCreated = DateTime.Parse($"04/02/2023 12:00", new CultureInfo("pt-BR"))
            },
            new Exam
            {
                Id = Guid.NewGuid(),
                Title = "Exame de mamografia",
                Description = "",
                DurationInMinutes = 30,
                RequiredEmployeeRole = RoleType.Doctor,
                RequiredEquipmentType = EquipmentType.MammographyMachine,
                DateCreated = DateTime.Parse($"04/02/2023 12:00", new CultureInfo("pt-BR"))
            },
            new Exam
            {
                Id = Guid.NewGuid(),
                Title = "Cirurgia",
                Description = "",
                DurationInMinutes = 240,
                RequiredEmployeeRole = RoleType.Doctor,
                RequiredEquipmentType = EquipmentType.SurgicalTable,
                DateCreated = DateTime.Parse($"04/02/2023 12:00", new CultureInfo("pt-BR"))
            },
            new Exam
            {
                Id = Guid.NewGuid(),
                Title = "Cirurgia v2",
                Description = "",
                DurationInMinutes = 600,
                RequiredEmployeeRole = RoleType.Doctor,
                RequiredEquipmentType = EquipmentType.Defibrillator,
                DateCreated = DateTime.Parse($"04/02/2023 12:00", new CultureInfo("pt-BR"))
            }
            );

        builder.Entity<Equipment>()
            .HasMany(p => p.Technicians)
            .WithMany(p => p.Equipments)
            .UsingEntity(
                l => l.HasOne(typeof(Employee)).WithMany().HasForeignKey("EmployeeId").HasPrincipalKey(nameof(Employee.Id)),
                r => r.HasOne(typeof(Equipment)).WithMany().HasForeignKey("EquipmentId").HasPrincipalKey(nameof(Equipment.Id)),
                j => j.HasData(
                    new { EquipmentId = equipmentsGuids[0], EmployeeId = idOfEmployee["Augusto"] },
                    new { EquipmentId = equipmentsGuids[0], EmployeeId = idOfEmployee["Alice"] },
                    new { EquipmentId = equipmentsGuids[1], EmployeeId = idOfEmployee["Luis"] },
                    new { EquipmentId = equipmentsGuids[2], EmployeeId = idOfEmployee["Camila"] },
                    new { EquipmentId = equipmentsGuids[3], EmployeeId = idOfEmployee["Gustavo"] },
                    new { EquipmentId = equipmentsGuids[4], EmployeeId = idOfEmployee["Alice"] },
                    new { EquipmentId = equipmentsGuids[5], EmployeeId = idOfEmployee["Camila"] },
                    new { EquipmentId = equipmentsGuids[6], EmployeeId = idOfEmployee["Camila"] },
                    new { EquipmentId = equipmentsGuids[7], EmployeeId = idOfEmployee["Gustavo"] },
                    new { EquipmentId = equipmentsGuids[8], EmployeeId = idOfEmployee["Gustavo"] },
                    new { EquipmentId = equipmentsGuids[9], EmployeeId = idOfEmployee["Alice"] },
                    new { EquipmentId = equipmentsGuids[10], EmployeeId = idOfEmployee["Alice"] },
                    new { EquipmentId = equipmentsGuids[11], EmployeeId = idOfEmployee["Augusto"] },
                    new { EquipmentId = equipmentsGuids[12], EmployeeId = idOfEmployee["Augusto"] },
                    new { EquipmentId = equipmentsGuids[13], EmployeeId = idOfEmployee["Alice"] },
                    new { EquipmentId = equipmentsGuids[14], EmployeeId = idOfEmployee["Augusto"] }
                    )
            );
    }
}
