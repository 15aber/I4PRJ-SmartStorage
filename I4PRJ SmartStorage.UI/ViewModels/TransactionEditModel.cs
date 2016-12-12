using System.Collections.Generic;
using SmartStorage.BLL.Dtos;

namespace SmartStorage.UI.ViewModels
{
  public class TransactionEditModel
  {
    public IList<InventoryDto> Inventories { get; set; }
    public IList<ProductDto> Products { get; set; }
    public TransactionDto Transaction { get; set; }
  }
}