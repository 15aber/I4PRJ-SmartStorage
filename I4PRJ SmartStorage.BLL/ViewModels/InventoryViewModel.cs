using System.Collections.Generic;
using I4PRJ_SmartStorage.DAL.Interfaces.Models;

namespace I4PRJ_SmartStorage.BLL.ViewModels
{
  public class InventoryViewModel
  {
    public List<IInventoryModel> Inventories { get; set; }
    public IInventoryModel Inventory { get; set; }
  }
}