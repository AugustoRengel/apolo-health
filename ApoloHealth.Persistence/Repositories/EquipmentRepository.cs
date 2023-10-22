using ApoloHealth.Domain.Entities;
using ApoloHealth.Domain.Interfaces;
using ApoloHealth.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApoloHealth.Persistence.Repositories;

public class EquipmentRepository : BaseRepository<Equipment>, IEquipmentRepository
{
    public EquipmentRepository(AppDbContext context) : base(context) { }

    public async Task<Equipment> GetByName(string name, CancellationToken cancellationToken)
    {
        return await _context.Equipments.FirstOrDefaultAsync(x => x.Name == name, cancellationToken);
    }
}
