using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using I4PRJ_SmartStorage.Models.Domain;

namespace I4PRJ_SmartStorage.ViewModels
{
    public class SupplierViewModel
    {
        public Supplier Supplier { get; set; }
        public List<Supplier> Suppliers { get; set; }

        public List<Inventory> FromInventory { get; set; }

        public List<Inventory> ToInventory { get; set; }

        public List<Product> Products { get; set; }
        public Product Product { get; set; }

        public List<Transaction> Transactions { get; set; }

        public Transaction Transaction { get; set; }

        [DisplayName("Restock")]
        public bool IsChecked { get; set; }

        [Required]
        [DisplayName("From")]
        public int FromInventoryId { get; set; }

        [Required]
        [DisplayName("To")]
        public int ToInventoryId { get; set; }

        [Required]
        [DisplayName("Product")]
        public int ProductId { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:F2}")]
        [Range(Double.MinValue, Double.MaxValue)]
        public double Quantity { get; set; }
    }
}