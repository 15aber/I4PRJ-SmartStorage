using System.Collections.Generic;
using I4PRJ_SmartStorage.DAL.Interfaces.Models;

namespace I4PRJ_SmartStorage.BLL.ViewModels
{
  public class StockViewModel
  {
    public List<IStockModel> Stocks { get; set; }

    public IStockModel Stock { get; set; }

    public IInventoryModel Inventory { get; set; }
  }
}