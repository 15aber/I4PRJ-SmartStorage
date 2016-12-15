using SmartStorage.DAL.Interfaces;
using SmartStorage.DAL.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace SmartStorage.DAL.Repositories
{
  public class Repository<T> : IRepository<T> where T : class
  {
    protected readonly DbContext Context;
    private readonly DbSet<T> _dbSet;

    public Repository(IApplicationDbContext context)
    {
      Context = (DbContext)context;
      _dbSet = Context.Set<T>();
    }

    public T Get(int id)
    {
      return _dbSet.Find(id);
    }

    public List<T> GetAll()
    {
      return _dbSet.ToList();
    }

    public List<T> GetAll(Expression<Func<T, bool>> predicate)
    {
      return _dbSet.Where(predicate).ToList();
    }

    public List<T> GetAll(Expression<Func<T, bool>> predicate1, Expression<Func<T, bool>> predicate2)
    {
      return _dbSet.Where(predicate1).Where(predicate2).ToList();
    }

    public T GetSingle(Expression<Func<T, bool>> predicate)
    {
      return _dbSet.Where(predicate).SingleOrDefault<T>();
    }

    public T GetSingle(Expression<Func<T, bool>> predicate1, Expression<Func<T, bool>> predicate2)
    {
      return _dbSet.Where(predicate1).Where(predicate2).SingleOrDefault<T>();
    }

    public void Add(T entity)
    {
      _dbSet.Add(entity);
    }

    public void Remove(T entity)
    {
      if (Context.Entry(entity).State == EntityState.Detached)
      {
        _dbSet.Attach(entity);
      }
      _dbSet.Remove(entity);
    }

    public void Update(T entity)
    {
      _dbSet.Attach(entity);
      Context.Entry(entity).State = EntityState.Modified;
    }

    public IQueryable<T> GetQueryable()
    {
      return _dbSet.AsQueryable();
    }

  }
}
