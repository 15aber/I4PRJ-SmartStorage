using System.Collections.Generic;
using System.Linq;
using I4PRJ_SmartStorage.DAL.Interfaces;
using I4PRJ_SmartStorage.DAL.Interfaces.Repositories;
using I4PRJ_SmartStorage.DAL.Models;

namespace I4PRJ_SmartStorage.DAL.Repositories
{
  public class SuppliersRepository : Repository<SupplierModel>, ISuppliersRepository
  {
    public SuppliersRepository(SmartStorageContext context) : base(context)
    {
    }

    public SmartStorageContext SmartStorageContext
    {
      get { return Context as SmartStorageContext; }
    }

    public IEnumerable<SupplierModel> GetAllActiveSuppliers()
    {
      return Context.Set<SupplierModel>().Where(c => c.IsDeleted == false).ToList();
    }
  }
}
