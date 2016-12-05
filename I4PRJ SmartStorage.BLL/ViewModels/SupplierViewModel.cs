using System.Collections.Generic;
using I4PRJ_SmartStorage.DAL.Interfaces.Models;

namespace I4PRJ_SmartStorage.BLL.ViewModels
{
  public class SupplierViewModel
  {
    public ISupplierModel Supplier { get; set; }
    public List<ISupplierModel> Suppliers { get; set; }

    public List<ITransactionModel> Transactions { get; set; }

    public ITransactionModel Transaction { get; set; }

  }
}