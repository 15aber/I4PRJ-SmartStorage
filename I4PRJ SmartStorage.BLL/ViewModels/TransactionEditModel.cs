using SmartStorage.BLL.Dtos;
using System.Collections.Generic;

namespace SmartStorage.BLL.ViewModels
{
  public class TransactionEditModel
  {
    public IList<InventoryDto> Inventories { get; set; }
    public IList<ProductDto> Products { get; set; }
    public TransactionDto Transaction { get; set; }
  }
}