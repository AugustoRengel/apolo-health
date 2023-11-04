using ApoloHealth.Domain.Entities;
using ApoloHealth.Domain.Interfaces;
using ApoloHealth.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApoloHealth.Persistence.Repositories;

internal class MaintanceRecordRepository : BaseRepository<MaintanceRecord>, IMaintanceRecordRepository
{
    public MaintanceRecordRepository(AppDbContext context) : base(context) { }
}
