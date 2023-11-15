using ApoloHealth.Domain.Entities;
using ApoloHealth.Domain.Interfaces;
using ApoloHealth.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace ApoloHealth.Persistence.Repositories;

internal class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
{
    public CustomerRepository(AppDbContext context) : base(context) { }

    public new async Task<Customer?> Get(Guid id, CancellationToken cancellationToken)
    {
        return await _context.Set<Customer>()
            .Include(e => e.Addresses)
            .Include(e => e.Appointments)
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }

    public new async Task<List<Customer>> GetAll(CancellationToken cancellationToken)
    {
        return await _context.Set<Customer>()
            .Include(e => e.Addresses)
            .Include(e => e.Appointments)
            .ToListAsync(cancellationToken);
    }
}
