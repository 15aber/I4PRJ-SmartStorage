using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using I4PRJ_SmartStorage.Models.Domain;

namespace I4PRJ_SmartStorage.ViewModels
{
    public class TransactionViewModel
    {
        [DisplayName("From")]
        public List<Inventory> FromInventory { get; set; }

        [DisplayName("To")]
        public List<Inventory> ToInventory { get; set; }

        [DisplayName("Product")]
        public List<Product> Products { get; set; }

        [Required]
        [Range(Double.MinValue, Double.MaxValue)]
        public double Quantity { get; set; }

        public Transaction Transaction { get; set; }
    }
}