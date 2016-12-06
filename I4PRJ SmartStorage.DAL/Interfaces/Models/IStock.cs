using I4PRJ_SmartStorage.DAL.Models;

namespace I4PRJ_SmartStorage.DAL.Interfaces.Models
{
  public interface IStock
  {
    Inventory Inventory { get; set; }
    int InventoryId { get; set; }
    Product Product { get; set; }
    int ProductId { get; set; }
    double Quantity { get; set; }
  }
}