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

        //builder.Entity<Employee>()
        //    .HasMany(a => a.Addresses)
        //    .WithOne(a => a.Person)
        //    .HasForeignKey("PersonId");
        builder.Entity<Employee>()
            .HasMany(a => a.Appointments);

        builder.Entity<Address>()
            .HasOne(a => a.Person)
            .WithMany(a => a.Addresses)
            .HasForeignKey("PersonId");

        var guidAugusto = Guid.NewGuid();
        var guidIsabel = Guid.NewGuid();
        var guidBob = Guid.NewGuid();
        var guidAppointment = Guid.NewGuid();
        var guidExam = Guid.NewGuid();

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
                MinutesOfPreventive = mopValues[i]
            };

            equipmentList.Add(tempEquipment);
        }

        builder.Entity<Equipment>().HasData(equipmentList);

        builder.Entity<MaintanceRecord>()
            .HasData(
            new MaintanceRecord
            {
                Id = Guid.NewGuid(),
                StartDate = DateTime.Now,
                EndDate = DateTime.Now,
                Technician = "Augusto",
                InitialState = EquipmentStatus.Inoperative,
                FinalState = EquipmentStatus.Operative,
                ProblemDescription = "opa",
                SolutionDescription = "hey",
                WasDone = true,
                Type = MaintanceType.Corrective,
                EquipmentId = equipmentsGuids[0]
            }
            );

        builder.Entity<Employee>()
            .HasData(
            new Employee
            {
                Id = guidAugusto,
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
                Id = guidIsabel,
                Name = "Isabel",
                CPF = "321.321.321.32",
                BirthDate = DateTime.Parse("26/08/2000", new CultureInfo("pt-BR")),
                Email = "isabel@email.com",
                Phone = "321456",
                Gender = GenderType.Male,
                Nationality = "BR",
                MaritalStatus = MaritalStatusType.Single,
                Role = RoleType.Doctor,
                Wage = 3000
            }
            );

        builder.Entity<Customer>()
            .HasData(
            new Customer
            {
                Id = guidBob,
                Name = "Bob",
                CPF = "555.123.123.12",
                BirthDate = DateTime.Parse("07/03/1997", new CultureInfo("pt-BR")),
                Email = "bob@email.com",
                Phone = "555456",
                Gender = GenderType.Male,
                Nationality = "BR",
                MaritalStatus = MaritalStatusType.Single,

                LastAppointment = DateTime.Now,
                HealthInsurance = "Unimed"
            }
            );

        builder.Entity<Address>().HasData(
            new Address
            {
                Id = Guid.NewGuid(),
                PersonId = guidAugusto,
                Street = "nome da rua",
                City = "São José dos Campos",
                State = "São Paulo",
                PostalCode = "12215-300",
                Country = "BR"
            },
            new Address
            {
                Id = Guid.NewGuid(),
                PersonId = guidIsabel,
                Street = "nome da rua 2",
                City = "São José dos Campos",
                State = "São Paulo",
                PostalCode = "30215-300",
                Country = "BR"
            },
            new Address
            {
                Id = Guid.NewGuid(),
                PersonId = guidBob,
                Street = "nome da rua 3",
                City = "São Paulo",
                State = "São Paulo",
                PostalCode = "88215-300",
                Country = "BR"
            }
            );

        builder.Entity<Exam>()
            .HasData(
            new Exam
            {
                Id = guidExam,
                Title = "Exame de raio-x",
                Description = "usa raio-x",
                DurationInMinutes = 30,
                RequiredEmployeeRole = RoleType.Doctor,
                RequiredEquipmentType = EquipmentType.ElectricScalpel
            }
            );
        builder.Entity<Appointment>()
            .HasData(
            new Appointment
            {
                Id = guidAppointment,
                Title = "Appointment of bob",
                Description = "Description",
                RoomNumber = 1,
                StartDate = DateTime.Now,
                EndDate = DateTime.Now,
                WasDone = false,
                RequiresTechnician = false,
                EquipmentId = equipmentsGuids[0],
                EmployeeId = guidIsabel,
                CustomerId = guidBob,
                ExamId = guidExam
            }
            );

        builder.Entity<Equipment>()
            .HasMany(p => p.Technicians)
            .WithMany(p => p.Equipments)
            .UsingEntity(
                l => l.HasOne(typeof(Employee)).WithMany().HasForeignKey("EmployeeId").HasPrincipalKey(nameof(Employee.Id)),
                r => r.HasOne(typeof(Equipment)).WithMany().HasForeignKey("EquipmentId").HasPrincipalKey(nameof(Equipment.Id)),
                j => j.HasData(
                    new { EquipmentId = equipmentsGuids[0], EmployeeId = guidAugusto }
                    )
            );
    }
}
