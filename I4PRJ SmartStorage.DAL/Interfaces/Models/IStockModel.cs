namespace I4PRJ_SmartStorage.DAL.Interfaces.Models
{
  public interface IStockModel
  {
    IInventoryModel Inventory { get; set; }
    int InventoryId { get; set; }
    IProductModel Product { get; set; }
    int ProductId { get; set; }
    double Quantity { get; set; }
  }
}