using I4PRJ_SmartStorage.DAL.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace I4PRJ_SmartStorage.DAL.Repositories
{
  public class Repository<T> : IRepository<T> where T : class
  {
    private readonly DbSet<T> _entities;

    public Repository(DbContext context)
    {
      _entities = context.Set<T>();
    }

    public T Get(int id)
    {
      return _entities.Find(id);
    }

    public List<T> GetAll()
    {
      return _entities.ToList();
    }

    public List<T> GetAll(System.Linq.Expressions.Expression<Func<T, bool>> whereCondition)
    {
      return _entities.Where(whereCondition).ToList();
    }

    public T SingleOrDefault(System.Linq.Expressions.Expression<Func<T, bool>> whereCondition)
    {
      return _entities.SingleOrDefault(whereCondition);
    }

    public void Add(T entity)
    {
      _entities.Add(entity);
    }

    public void AddRange(List<T> entities)
    {
      _entities.AddRange(entities);
    }

    public void Remove(T entity)
    {
      _entities.Remove(entity);
    }

    public void RemoveRange(List<T> entities)
    {
      _entities.RemoveRange(entities);
    }
  }
}
