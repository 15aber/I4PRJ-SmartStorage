using SmartStorage.DAL.Context;
using SmartStorage.DAL.Interfaces;
using SmartStorage.DAL.Interfaces.Repositories;
using SmartStorage.DAL.Models;
using System.Collections.Generic;
using System.Linq;

namespace SmartStorage.DAL.Repositories
{
  public class ProductsRepository : Repository<Product>, IProductsRepository
  {
    public ProductsRepository(IApplicationDbContext context) : base(context)
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
