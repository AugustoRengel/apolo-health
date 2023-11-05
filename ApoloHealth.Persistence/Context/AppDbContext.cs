using ApoloHealth.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

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
        builder.Entity<Equipment>().HasKey(a => a.Id);
        builder.Entity<MaintanceRecord>().HasKey(a => a.Id);
        builder.Entity<Employee>().HasKey(a => a.Id);

        builder.Entity<Equipment>()
            .HasMany(a => a.MaintanceRecords);
        builder.Entity<Equipment>()
            .HasMany(a => a.Appointments);

        builder.Entity<Employee>()
            .HasMany(a => a.Addresses);
        builder.Entity<Employee>()
            .HasMany(a => a.Appointments);

        var guidAugusto = Guid.NewGuid();
        var guidIsabel = Guid.NewGuid();
        var guidBob = Guid.NewGuid();
        var guidAppointment = Guid.NewGuid();
        var guidExam = Guid.NewGuid();
        var guidEquipment = Guid.NewGuid();

        builder.Entity<Appointment>()
            .HasMany(p => p.Employees)
            .WithMany(p => p.Appointments)
            .UsingEntity(
                l => l.HasOne(typeof(Employee)).WithMany().HasForeignKey("EmployeeId").HasPrincipalKey(nameof(Employee.Id)),
                r => r.HasOne(typeof(Appointment)).WithMany().HasForeignKey("AppointmentId").HasPrincipalKey(nameof(Appointment.Id)),
                j => j.HasData(
                    new { AppointmentId=guidAppointment, EmployeeId=guidAugusto}, 
                    new { AppointmentId = guidAppointment, EmployeeId = guidIsabel }
                    )
            );

        builder.Entity<Appointment>()
            .HasMany(p => p.Equipments)
            .WithMany(p => p.Appointments)
            .UsingEntity(
                l => l.HasOne(typeof(Equipment)).WithMany().HasForeignKey("EquipmentId").HasPrincipalKey(nameof(Equipment.Id)),
                r => r.HasOne(typeof(Appointment)).WithMany().HasForeignKey("AppointmentId").HasPrincipalKey(nameof(Appointment.Id)),
                j => j.HasData(
                    new { AppointmentId = guidAppointment, EquipmentId = guidEquipment }
                    )
            );

        builder.Entity<Equipment>()
            .HasData(
            new Equipment
            { 
                Id = guidEquipment,
                Name = "Raio X",
                Description = "description",
                Type = EquipmentType.Xray,
                Status = EquipmentStatus.Operative,
                Maker = "Siemens",
                FabricationDate = DateTime.Now,
                Sector = EquipmentSector.DI,
                MonthsBetweenPreventive = 12,
                LastPreventiveDate = DateTime.Now,
                MinutesOfPreventive = 180
            }
            );

        builder.Entity<Employee>()
            .HasData(
            new Employee 
            { 
                Id= guidAugusto,
                Name="Augusto", 
                CPF="123.123.123.12", 
                BirthDate= DateTime.Parse("07/09/1998", new CultureInfo("pt-BR")),
                Email="augusto@email.com", 
                Phone="123456", 
                Gender=GenderType.Male, 
                Nationality="BR",
                MaritalStatus=MaritalStatusType.Single,
                Role=RoleType.Technician,
                Wage=3500
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
        builder.Entity<Exam>()
            .HasData(
            new Exam
            {
                Id = guidExam,
                Title = "Exame de raio-x",
                Description = "usa raio-x",
                DurationInMinutes = 30,
                RequiredEmployeeRole = RoleType.Doctor,
                RequiredEquipmentType = EquipmentType.Xray
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
                StartDate=DateTime.Now,
                EndDate=DateTime.Now,
                WasDone=false,
                CustomerId=guidBob,
                ExamId=guidExam
            }
            );

        builder.Entity<Equipment>()
            .HasMany(p => p.Technicians)
            .WithMany(p => p.Equipments)
            .UsingEntity(
                l => l.HasOne(typeof(Employee)).WithMany().HasForeignKey("EmployeeId").HasPrincipalKey(nameof(Employee.Id)),
                r => r.HasOne(typeof(Equipment)).WithMany().HasForeignKey("EquipmentId").HasPrincipalKey(nameof(Equipment.Id)),
                j => j.HasData(
                    new { EquipmentId = guidEquipment, EmployeeId = guidAugusto }
                    )
            );
    }
}
