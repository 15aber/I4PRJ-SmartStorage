using System.Collections.Generic;
using I4PRJ_SmartStorage.DAL.Interfaces.Models;

namespace I4PRJ_SmartStorage.BLL.ViewModels
{
  public class WholesalerViewModel
  {
    public IWholesalerModel Wholesaler { get; set; }

    public List<IWholesalerModel> Wholesalers { get; set; }

    public List<ITransactionModel> Transactions { get; set; }

    public ITransactionModel Transaction { get; set; }
  }
}