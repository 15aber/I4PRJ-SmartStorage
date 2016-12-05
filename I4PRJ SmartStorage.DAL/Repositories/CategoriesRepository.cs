using I4PRJ_SmartStorage.DAL.Context;
using I4PRJ_SmartStorage.DAL.Interfaces.Repositories;
using I4PRJ_SmartStorage.DAL.Models;


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

  }
}
