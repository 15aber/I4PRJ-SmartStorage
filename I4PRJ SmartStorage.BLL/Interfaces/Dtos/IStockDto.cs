using I4PRJ_SmartStorage.DAL.Interfaces.Models;

namespace I4PRJ_SmartStorage.BLL.Interfaces.Dtos
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