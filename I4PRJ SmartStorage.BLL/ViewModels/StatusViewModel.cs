using System.Collections.Generic;
using I4PRJ_SmartStorage.DAL.Interfaces.Models;

namespace I4PRJ_SmartStorage.BLL.ViewModels
{
  public class StatusViewModel
  {
    public List<IStockModel> Stocks { get; set; }

    public List<IInventoryModel> Inventories { get; set; }

    public List<IProductModel> Products { get; set; }

    public List<ICategoryModel> Categories { get; set; }

    public List<IStatusModel> Statuses { get; set; }

    public List<int> StatusStartedInventories { get; set; }

    public string Name { get; set; }

    public bool ShowNotification { get; set; }

    public bool IsStarted { get; set; }

    public IStatusModel Status { get; set; }
  }
}