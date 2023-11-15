using ApoloHealth.Domain.Entities;
using ApoloHealth.Domain.Interfaces;
using ApoloHealth.Persistence.Context;

namespace ApoloHealth.Persistence.Repositories;

internal class AddressRepository : BaseRepository<Address>, IAddressRepository
{
    public AddressRepository(AppDbContext context) : base(context) { }
}
