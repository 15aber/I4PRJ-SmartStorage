using System.Collections.Generic;
using I4PRJ_SmartStorage.Models.Domain;

namespace I4PRJ_SmartStorage.ViewModel
{
  public class TransactionViewModel
  {
    public List<Inventory> FromInventory { get; set; }

    public List<Inventory> ToInventory { get; set; }

    public List<Product> Products { get; set; }

    public Transaction Transaction { get; set; }

    public bool IsChecked { get; set; }

    public List<Transaction> Transactions { get; set; }
  }
}