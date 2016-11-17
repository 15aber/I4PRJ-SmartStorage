using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using I4PRJ_SmartStorage.Models.Domain;

namespace I4PRJ_SmartStorage.ViewModels
{
    public class StockViewModel
    {
        public List<Inventory> Inventory { get; set; }

        public List<Product> Product { get; set; }
    }
}