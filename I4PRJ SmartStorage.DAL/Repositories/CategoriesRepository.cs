using I4PRJ_SmartStorage.DAL.Interfaces.Repositories;
using I4PRJ_SmartStorage.DAL.Models;
using System.Collections.Generic;
using System.Linq;

namespace I4PRJ_SmartStorage.DAL.Repositories
{
  public class CategoriesRepository : Repository<CategoryModel>, ICategoriesRepository
  {
    public CategoriesRepository(SmartStorageContext context) : base(context)
    {
    }

    public SmartStorageContext SmartStorageContext
    {
      get { return Context as SmartStorageContext; }
    }

    public IEnumerable<CategoryModel> GetAllActiveCategories()
    {
      return Context.Set<CategoryModel>().Where(c => c.IsDeleted == false).ToList();
    }
  }
}
