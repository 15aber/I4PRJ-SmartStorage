using I4PRJ_SmartStorage.DAL.Interfaces.Models;

namespace I4PRJ_SmartStorage.BLL.Interfaces.Dtos
{
  public interface IStockDto
  {
    IInventoryModel Inventory { get; set; }
    int InventoryId { get; set; }
    IProductModel Product { get; set; }
    int ProductId { get; set; }
    double Quantity { get; set; }
  }
}