using System.Collections.Generic;
using System.ComponentModel;
using I4PRJ_SmartStorage.Models.Domain;

namespace I4PRJ_SmartStorage.ViewModels
{
  public class TransactionViewModel
  {
    public List<Inventory> FromInventory { get; set; }

    public List<Inventory> ToInventory { get; set; }

    public List<Product> Products { get; set; }

    public Transaction Transaction { get; set; }

    [DisplayName("Restock")]
    public bool IsChecked { get; set; }

    public List<Transaction> Transactions { get; set; }
  }
}