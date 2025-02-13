﻿using Domain.Common;
using Domain.Repositories;
using Infrastructure.Persistence.DbContext;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories;
public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
{
    private readonly AppDbContext _dbContext;
    private DbSet<T> _dbSet;
    public GenericRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
        _dbSet = _dbContext.Set<T>();
    }
    public async Task<T> GetByIdAsync(Guid id)
    {
        var entity = await _dbSet.FindAsync(id);

        if (entity == null)
        {
            throw new Exception($"Entity {typeof(T).Name} with id {id} not found");
        }

        return entity;
    }
    public async Task<List<T>> ListAllAsync()
    {
        var entities = await _dbSet.ToListAsync();
        return entities;
    }

    public async Task<List<T>> ListAllAsyncNoTracking()
    {
        var entities = await _dbSet.AsNoTracking().ToListAsync();
        return entities;
    }

    public async Task<T> AddAsync(T entity)
    {
        await _dbSet.AddAsync(entity);
        await _dbContext.SaveChangesAsync();
        return entity;
    }

    public async Task UpdateAsync(T entity)
    {
        _dbSet.Update(entity);
        await _dbContext.SaveChangesAsync();
    }

    public Task DeleteAsync(T entity)
    {
        _dbSet.Remove(entity);
        return _dbContext.SaveChangesAsync();
    }
}
