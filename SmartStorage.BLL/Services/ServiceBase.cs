using System;
using System.Collections.Generic;
using SmartStorage.BLL.Interfaces.Services;

namespace SmartStorage.BLL.Services
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
