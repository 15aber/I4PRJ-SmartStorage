using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace I4PRJ_SmartStorage.Models.Domain
{
    public class Stock
    {
        public int StockId { get; set; }

        [Required]
        [DisplayName("Inventory")]
        public int InventoryId { get; set; }

        [Required]
        [DisplayName("Product")]
        public int ProductId { get; set; }

        public Inventory Inventory { get; set; }

        public Product Product { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:F2}")]
        [Range(Double.MinValue, Double.MaxValue)]
        public double Quantity { get; set; }
    }
}