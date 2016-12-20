using System.Collections.Generic;
using SmartStorage.BLL.Dtos;

namespace SmartStorage.UI.ViewModels
{
  public class StatusViewModel
  {
    public IList<StockDto> Stocks { get; set; }

    public IList<InventoryDto> Inventories { get; set; }

    public IList<ProductDto> Products { get; set; }

    public List<CategoryDto> Categories { get; set; }

    public IList<StatusDto> Statuses { get; set; }

    public List<int> StatusStartedInventories { get; set; }

    public string Name { get; set; }

    public bool ShowNotification { get; set; }

    public bool IsStarted { get; set; }

    public StatusDto Status { get; set; }
  }
}
