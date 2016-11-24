using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using I4PRJ_SmartStorage.Models.Domain;

namespace I4PRJ_SmartStorage.Dtos
{
    public class StockDto
    {
        public int StockId { get; set; }

        [Required]
        public int InventoryId { get; set; }

        public Inventory Inventory { get; set; }

        [Required]
        public int ProductId { get; set; }

        public List<Product> Product { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:F2}")]
        [Range(Double.MinValue, Double.MaxValue)]
        public double Quantity { get; set; }
    }
}