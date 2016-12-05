using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace I4PRJ_SmartStorage.DAL.Interfaces.Repositories
{
  public interface IRepository<T> where T : class
  {
    void Add(T entity);
    T Get(int id);
    List<T> GetAll();
    List<T> GetAll(Expression<Func<T, bool>> where);
    List<T> GetAll(Expression<Func<T, bool>> where1, Expression<Func<T, bool>> where2);
    T GetSingle(Expression<Func<T, bool>> predicate);
    T GetSingle(Expression<Func<T, bool>> where1, Expression<Func<T, bool>> where2);
    void Remove(T entity);
    void Update(T entity);
    IQueryable<T> GetQueryable();
  }
}