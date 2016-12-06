using System.Collections.Generic;
using System.Linq;
using SmartStorage.DAL.Context;
using SmartStorage.DAL.Interfaces.Repositories;
using SmartStorage.DAL.Models;

namespace SmartStorage.DAL.Repositories
{
  public class ProductsRepository : Repository<Product>, IProductsRepository
  {
    public ProductsRepository(ApplicationDbContext context) : base(context)
    {
    }

    public ApplicationDbContext ApplicationDbContext
    {
      get { return Context as ApplicationDbContext; }
    }

    public IEnumerable<Product> GetAllActiveProducts()
    {
      return Context.Set<Product>().Where(c => c.IsDeleted == false).ToList();
    }
  }
}
