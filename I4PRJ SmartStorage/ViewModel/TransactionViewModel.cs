using I4PRJ_SmartStorage.Models.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace I4PRJ_SmartStorage.ViewModel
{
    public class TransactionViewModel
    {
        [DisplayName("From")]
        public int FromInventoryId { get; set; }

        [DisplayName("From")]
        public List<Inventory> FromInventory { get; set; }

        [Required]
        [DisplayName("To")]
        public int ToInventoryId { get; set; }

        [DisplayName("To")]
        public List<Inventory> ToInventory { get; set; }

        [Required]
        [DisplayName("Product")]
        public int ProductId { get; set; }

        public List<Product> Product { get; set; }

        [Required]
        [Range(Double.MinValue, Double.MaxValue)]
        public double Quantity { get; set; }

        public Transaction Transaction { get; set; }
    }
}