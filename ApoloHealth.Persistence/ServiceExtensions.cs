using ApoloHealth.Domain.Interfaces;
using ApoloHealth.Persistence.Context;
using ApoloHealth.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ApoloHealth.Persistence;

public static class ServiceExtensions
{
    public static void ConfigurePersistenceApp(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("Sqlite");
        services.AddDbContext<AppDbContext>(opt => opt.UseSqlite(connectionString));

        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IEquipmentRepository, EquipmentRepository>();
        //services.AddScoped<IMaintanceRecordRepository, MaintanceRecordRepository>();
    }
}
