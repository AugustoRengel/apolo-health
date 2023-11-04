using ApoloHealth.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApoloHealth.Persistence.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    { }
    public DbSet<Equipment> Equipments { get; set; }
    public DbSet<MaintanceRecord> MaintanceRecords { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Equipment>().HasKey(a => a.Id);
        builder.Entity<MaintanceRecord>().HasKey(a => a.Id);

        builder.Entity<Equipment>()
            .HasMany(a => a.MaintanceRecords);
    }
}
