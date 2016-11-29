using System.Collections.Generic;
using I4PRJ_SmartStorage.Models.Domain;

namespace I4PRJ_SmartStorage.ViewModels
{
  public class StatusViewModel
  {
    public List<Stock> Stocks { get; set; }

    public List<Inventory> Inventories { get; set; }

    public List<Product> Products { get; set; }

    public List<Category> Categories { get; set; }

    public List<int> StatusStartedInventories { get; set; }

    public string Name { get; set; }

    public bool ShowNotification { get; set; }

    public bool IsStarted { get; set; }
  }
}