﻿namespace DentallApp.DataAccess.Repositories;

public class Repository<TEntity> : IRepository<TEntity> where TEntity : EntityBase
{
    private readonly AppDbContext _context;
    private readonly DbSet<TEntity> _entities;

    protected AppDbContext Context => _context;
    protected DbSet<TEntity> Entities => _entities;

    public Repository(AppDbContext context)
    {
        _context = context;
        _entities = context.Set<TEntity>();
    }

    public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
        => await _entities.ToListAsync();

    public virtual async Task<TEntity> GetByIdAsync(int id)
        => await _entities.Where(entity => entity.Id == id).FirstOrDefaultAsync();

    public virtual void Insert(TEntity entity)
        => _entities.Add(entity);

    public virtual void Delete(TEntity entity)
        => _entities.Remove(entity);
}