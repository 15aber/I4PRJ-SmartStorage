using System.Collections.Generic;

namespace SmartStorage.BLL.Interfaces.Services
{
  public interface IService<T> where T : class
  {
    void Add(T entityDto);
    IList<T> GetAll();
    T GetSingle(int id);
    void Update(T entity);
  }
}