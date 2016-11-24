using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using I4PRJ_SmartStorage.Models.Domain;

namespace I4PRJ_SmartStorage.ViewModels
{
    public class SupplierViewModel
    {
        public List<Supplier> Suppliers { get; set; }
        //public List<Product> Products { get; set; }
        public DateTime DeliveryDate { get; set; }  
    }
}