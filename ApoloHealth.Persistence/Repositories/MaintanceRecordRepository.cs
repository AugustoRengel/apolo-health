using ApoloHealth.Domain.Entities;
using ApoloHealth.Domain.Interfaces;
using ApoloHealth.Persistence.Context;

namespace ApoloHealth.Persistence.Repositories;

internal class MaintanceRecordRepository : BaseRepository<MaintanceRecord>, IMaintanceRecordRepository
{
    public MaintanceRecordRepository(AppDbContext context) : base(context) { }
}
