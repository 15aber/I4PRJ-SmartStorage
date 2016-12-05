using System.Collections.Generic;

namespace I4PRJ_SmartStorage.BLL.Interfaces.Services
{
  public interface IService<T> where T : class
  {
    void Add(T entityDto);
    void Delete(int id);
    IList<T> GetAll();
    IList<T> GetAllActive();
    T GetSingle(int id);
    void Update(T entity);
  }
}