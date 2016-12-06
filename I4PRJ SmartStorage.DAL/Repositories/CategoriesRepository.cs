using SmartStorage.DAL.Context;
using SmartStorage.DAL.Interfaces.Repositories;
using SmartStorage.DAL.Models;

namespace SmartStorage.DAL.Repositories
{
  public class CategoriesRepository : Repository<Category>, ICategoriesRepository
  {
    public CategoriesRepository(ApplicationDbContext context) : base(context)
    {
    }

    public ApplicationDbContext ApplicationDbContext
    {
      get { return Context as ApplicationDbContext; }
    }

  }
}
