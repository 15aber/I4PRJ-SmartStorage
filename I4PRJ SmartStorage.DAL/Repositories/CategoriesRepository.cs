using SmartStorage.DAL.Context;
using SmartStorage.DAL.Context.Application;
using SmartStorage.DAL.Interfaces;
using SmartStorage.DAL.Interfaces.Repositories;
using SmartStorage.DAL.Models;

namespace SmartStorage.DAL.Repositories
{
  public class CategoriesRepository : Repository<Category>, ICategoriesRepository
  {
    public CategoriesRepository(IApplicationDbContext context) : base(context)
    {
    }

    public ApplicationDbContext ApplicationDbContext
    {
      get { return Context as ApplicationDbContext; }
    }

  }
}
