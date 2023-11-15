using ApoloHealth.Domain.Entities;
using ApoloHealth.Domain.Interfaces;
using ApoloHealth.Persistence.Context;
using AutoMapper.Execution;
using Microsoft.EntityFrameworkCore;

namespace ApoloHealth.Persistence.Repositories;

internal class EquipmentRepository : BaseRepository<Equipment>, IEquipmentRepository
{
    public EquipmentRepository(AppDbContext context) : base(context) { }

    public new void Create(Equipment equipment)
    {
        equipment.DateCreated = DateTime.Now;
        int numberOfEquipmentsOfType = _context.Equipments.Count(e => e.Type == equipment.Type);
        equipment.Code = equipment.Sector.ToString() + equipment.Type.ToString() + numberOfEquipmentsOfType.ToString("D4");
        _context.Add(equipment);
    }

    public new async Task<Equipment?> Get(Guid id, CancellationToken cancellationToken)
    {
        return await _context.Set<Equipment>()
            .Include(e => e.MaintanceRecords)
            .Include(e => e.Technicians)
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }

    public new async Task<List<Equipment>> GetAll(CancellationToken cancellationToken)
    {
        return await _context.Set<Equipment>()
            .Include(e => e.MaintanceRecords)
            .Include(e => e.Technicians)
                .ThenInclude(emp => emp.Addresses)
            .ToListAsync(cancellationToken);
    }
}
