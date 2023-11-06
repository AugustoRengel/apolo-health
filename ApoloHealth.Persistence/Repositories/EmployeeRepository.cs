using ApoloHealth.Domain.Entities;
using ApoloHealth.Domain.Interfaces;
using ApoloHealth.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace ApoloHealth.Persistence.Repositories;

internal class EmployeeRepository : BaseRepository<Employee>, IEmployeeRepository
{
    public EmployeeRepository(AppDbContext context) : base(context) { }

    public new async Task<Employee?> Get(Guid id, CancellationToken cancellationToken)
    {
        return await _context.Set<Employee>()
            .Include(e => e.Addresses)
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }

    public new async Task<List<Employee>> GetAll(CancellationToken cancellationToken)
    {
        return await _context.Set<Employee>()
            .Include(e => e.Addresses)
            .Include(e => e.Equipments)
            .ToListAsync(cancellationToken);
    }
}
