using I4PRJ_SmartStorage.Models.Domain;
using System.Collections.Generic;

namespace I4PRJ_SmartStorage.ViewModel
{
    public class TransactionViewModel
    {
        public List<Inventory> FromInventory { get; set; }

        public List<Inventory> ToInventory { get; set; }

        public List<Product> Product { get; set; }

        public Transaction Transaction { get; set; }
    }
}