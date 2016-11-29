using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using I4PRJ_SmartStorage.Models.Domain;

namespace I4PRJ_SmartStorage.ViewModel
{
    public class WholesalerViewModel
    {
        public Wholesaler Wholesaler { get; set; }
        public List<Wholesaler> Wholesalers { get; set; }
        public Transaction Transaction { get; set; }
        public List<Inventory> Inventories { get; set; }
        public List<Transaction> Transactions { get; set; }
        public List<Product> Products { get; set; }


    }
}