using I4PRJ_SmartStorage.DAL.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace I4PRJ_SmartStorage.DAL.Repositories
{
  public class Repository<T> : IRepository<T> where T : class
  {
    protected readonly DbContext Context;
    private readonly DbSet<T> _dbSet;

    public Repository(DbContext context)
    {
      Context = context;
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

    public List<T> GetAll(System.Linq.Expressions.Expression<Func<T, bool>> whereCondition)
    {
      return _dbSet.Where(whereCondition).ToList();
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

  }
}
