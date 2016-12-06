using SmartStorage.DAL.Models;

namespace SmartStorage.DAL.Interfaces.Models
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