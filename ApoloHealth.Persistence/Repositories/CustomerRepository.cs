using ApoloHealth.Domain.Entities;
using ApoloHealth.Domain.Interfaces;
using ApoloHealth.Persistence.Context;

namespace ApoloHealth.Persistence.Repositories;

internal class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
{
    public CustomerRepository(AppDbContext context) : base(context) { }
}
