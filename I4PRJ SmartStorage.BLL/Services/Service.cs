using I4PRJ_SmartStorage.BLL.Interfaces.Services;
using System;
using System.Collections.Generic;

namespace I4PRJ_SmartStorage.BLL.Services
{
  public abstract class Service<T> : IService<T> where T : class
  {
    public T GetSingle(System.Linq.Expressions.Expression<Func<T, bool>> whereCondition)
    {
      throw new NotImplementedException();
    }

    public void Add(T entity)
    {
      throw new NotImplementedException();
    }

    public void Delete(T entity)
    {
      throw new NotImplementedException();
    }

    public void Update(T entity)
    {
      throw new NotImplementedException();
    }

    public IList<T> GetAll(System.Linq.Expressions.Expression<Func<T, bool>> whereCondition)
    {
      throw new NotImplementedException();
    }

    public IList<T> GetAll()
    {
      throw new NotImplementedException();
    }

    public long Count(System.Linq.Expressions.Expression<Func<T, bool>> whereCondition)
    {
      throw new NotImplementedException();
    }

    public long Count()
    {
      throw new NotImplementedException();
    }
  }
}
