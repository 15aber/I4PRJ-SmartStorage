using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using I4PRJ_SmartStorage.Models;
using I4PRJ_SmartStorage.Models.Domain;

namespace I4PRJ_SmartStorage.ViewModels
{
    public class InventoryViewModel
    {
        public List<Inventory> Inventories { get; set; }
        //public List<Product> Products { get; set; }
        //public List<Stock> Stocks { get; set; }
        //public ApplicationUser UpdateByUser { get; set; }
        public DateTime LastUpdated { get; set; }
    }
}