﻿using ApoloHealth.Domain.Entities;
using ApoloHealth.Domain.Interfaces;
using ApoloHealth.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace ApoloHealth.Persistence.Repositories;

public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
{
    protected readonly AppDbContext _context;

    public BaseRepository(AppDbContext context)
    {
        _context = context;
    }
    public void Create(T entity)
    {
        entity.DateCreated = DateTime.Now;
        _context.Add(entity);
    }
    public void Update(T entity)
    {
        entity.DateUpdated = DateTime.Now;
        _context.Update(entity);
    }
    public void Delete(T entity)
    {
        entity.DateDeleted = DateTime.Now;
        _context.Remove(entity);
    }
    public async Task<T?> Get(Guid id, CancellationToken cancellationToken)
    {
        return await _context.Set<T>().FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }

    public async Task<List<T>> GetAll(CancellationToken cancellationToken)
    {
        return await _context.Set<T>().ToListAsync(cancellationToken);
    }
}
