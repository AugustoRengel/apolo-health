using ApoloHealth.Domain.Entities;
using ApoloHealth.Domain.Interfaces;
using ApoloHealth.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace ApoloHealth.Persistence.Repositories;

internal class EquipmentRepository : BaseRepository<Equipment>, IEquipmentRepository
{
    public EquipmentRepository(AppDbContext context) : base(context) { }

    public async Task<Equipment?> GetByName(string name, CancellationToken cancellationToken)
    {
        return await _context.Set<Equipment>()
            .Include(e => e.MaintanceRecords)
            .FirstOrDefaultAsync(x => x.Name == name, cancellationToken);
    }
    public new async Task<Equipment?> Get(Guid id, CancellationToken cancellationToken)
    {
        return await _context.Set<Equipment>()
            .Include(e => e.MaintanceRecords)
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }

    public new async Task<List<Equipment>> GetAll(CancellationToken cancellationToken)
    {
        return await _context.Set<Equipment>()
            .Include(e => e.MaintanceRecords)
            .ToListAsync(cancellationToken);
    }
}
