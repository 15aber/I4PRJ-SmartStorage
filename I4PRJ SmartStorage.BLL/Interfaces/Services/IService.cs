using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace I4PRJ_SmartStorage.BLL.Interfaces.Services
{
  public interface IService<T> where T : class
  {
    void Add(T entity);
    long Count();
    long Count(Expression<Func<T, bool>> whereCondition);
    void Delete(T entity);
    IList<T> GetAll();
    IList<T> GetAll(Expression<Func<T, bool>> whereCondition);
    T GetSingle(Expression<Func<T, bool>> whereCondition);
    void Update(T entity);
  }
}