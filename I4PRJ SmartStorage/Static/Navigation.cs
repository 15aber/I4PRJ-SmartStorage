using System.Collections.Generic;
using System.Linq;
using I4PRJ_SmartStorage.Models;
using I4PRJ_SmartStorage.Models.Domain;

namespace I4PRJ_SmartStorage.Static
{
  public static class Navigation
  {
    public static List<Inventory> GetInventories()
    {
      using (ApplicationDbContext db = new ApplicationDbContext())
      {
        return db.Inventories.ToList();
      }
    }

    public static List<Category> GetCategories()
    {
      using (ApplicationDbContext db = new ApplicationDbContext())
      {
        return db.Categories.ToList();
      }
    }
  }
}