using System.Collections.Generic;
using I4PRJ_SmartStorage.DAL.Models;

namespace I4PRJ_SmartStorage.DAL.Interfaces.Repositories
{
  public interface ISuppliersRepository : IRepository<SupplierModel>
  {
    IEnumerable<SupplierModel> GetAllActiveSuppliers();
  }
}