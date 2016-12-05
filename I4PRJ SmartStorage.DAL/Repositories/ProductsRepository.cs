using System.Collections.Generic;
using System.Linq;
using I4PRJ_SmartStorage.DAL.Context;
using I4PRJ_SmartStorage.DAL.Interfaces;
using I4PRJ_SmartStorage.DAL.Interfaces.Repositories;
using I4PRJ_SmartStorage.DAL.Models;

namespace I4PRJ_SmartStorage.DAL.Repositories
{
  public class ProductsRepository : Repository<ProductModel>, IProductsRepository
  {
    public ProductsRepository(SmartStorageContext context) : base(context)
    {
    }

    public SmartStorageContext SmartStorageContext
    {
      get { return Context as SmartStorageContext; }
    }

    public IEnumerable<ProductModel> GetAllActiveProducts()
    {
      return Context.Set<ProductModel>().Where(c => c.IsDeleted == false).ToList();
    }
  }
}
