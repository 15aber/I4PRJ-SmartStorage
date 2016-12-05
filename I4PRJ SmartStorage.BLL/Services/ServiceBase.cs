using I4PRJ_SmartStorage.BLL.Interfaces.Services;
using System;
using System.Collections.Generic;

namespace I4PRJ_SmartStorage.BLL.Services
{
  public abstract class ServiceBase<T> : IService<T> where T : class
  {
    public void Add(T entityDto)
    {
      throw new NotImplementedException();
    }

    public void Update(T entity)
    {
      throw new NotImplementedException();
    }

    public T GetSingle(int id)
    {
      throw new NotImplementedException();
    }

    public IList<T> GetAll()
    {
      throw new NotImplementedException();
    }
  }
}
