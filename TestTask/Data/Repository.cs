﻿using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TestTask.Data.Interfaces;

namespace TestTask.Data
{
  public class Reposiory : IRepository
  {
    private readonly DemoDBContext _dbContext;

    public Reposiory(DemoDBContext dbContext)
    {
      _dbContext = dbContext;
    }

    public IQueryable<TEntity> Get<TEntity>() where TEntity : class, IEntity
    {
      return _dbContext.Set<TEntity>().AsNoTracking();
    }

    public IQueryable<TEntity>? GetByFilter<TEntity>(Expression<Func<TEntity, bool>> condition) where TEntity : class, IEntity
    {
      try
      {
        return _dbContext.Set<TEntity>().AsNoTracking().Where(condition) ?? Enumerable.Empty<TEntity>().AsQueryable();
      }
      catch (ArgumentNullException ex)
      {
        //TODO LS log
        return null;
      }
    }

    public async Task<TEntity?> FirstOrDefaultAsync<TEntity>(Expression<Func<TEntity, bool>> condition) where TEntity : class, IEntity
    {
      try
      {
        return await _dbContext.Set<TEntity>().AsNoTracking().FirstOrDefaultAsync(condition);
      }
      catch(ArgumentNullException ex)
      {
        //TODO LS log
        throw new ArgumentNullException();
      }
    }

    public async Task AddAsync<TEntity>(TEntity entity) where TEntity : class, IEntity
    {
      await _dbContext.Set<TEntity>().AddAsync(entity);
    }

    public void Update<TEntity>(TEntity entity) where TEntity : class, IEntity
    {
      _dbContext.Set<TEntity>().Update(entity);
    }

    public void Remove<TEntity>(TEntity entity) where TEntity : class, IEntity
    {
      _dbContext.Set<TEntity>().Remove(entity);
    }

    public async Task<bool> SaveChangesAsync()
    {
      try
      {
        return await _dbContext.SaveChangesAsync() != 0;
      }
      catch (DbUpdateConcurrencyException ex)
      {
        //TODO LS log
        return false;
      }
      catch (DbUpdateException ex)
      {
        //TODO LS log
        return false;
      }
    }
  }
}
