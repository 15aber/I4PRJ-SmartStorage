using SmartStorage.DAL.Interfaces.Models;

namespace SmartStorage.BLL.Interfaces.Dtos
{
  public interface IStockDto
  {
    IInventory Inventory { get; set; }
    int InventoryId { get; set; }
    IProduct Product { get; set; }
    int ProductId { get; set; }
    double Quantity { get; set; }
  }
}