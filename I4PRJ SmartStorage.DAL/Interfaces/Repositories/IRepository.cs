using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace I4PRJ_SmartStorage.DAL.Interfaces.Repositories
{
  public interface IRepository<T> where T : class
  {
    void Add(T entity);
    void AddRange(List<T> entities);
    T Get(int id);
    List<T> GetAll();
    List<T> GetAll(Expression<Func<T, bool>> predicate);
    void Remove(T entity);
    void RemoveRange(List<T> entities);
    T SingleOrDefault(Expression<Func<T, bool>> predicate);
  }
}