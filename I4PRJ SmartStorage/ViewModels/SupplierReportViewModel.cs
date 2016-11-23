using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Web;
using I4PRJ_SmartStorage.Models.Domain;

namespace I4PRJ_SmartStorage.ViewModels
{
    public class SupplierReportViewModel
    {
        public Supplier Supplier { get; set; }
        //public Product Product { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }       
        public DateTime FirstDeliveryDate { get; set; }
        public DateTime LastDeliveryDate { get; set; }
    }
}