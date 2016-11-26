using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using I4PRJ_SmartStorage.Models.Domain;

namespace I4PRJ_SmartStorage.Dtos
{
    public class TransactionDto
    {
        [Key]
        public int TransactionId { get; set; }

        [ForeignKey("FromInventory")]
        public int FromInventoryId { get; set; }

        public InventoryDto FromInventory { get; set; }

        [Required]
        [ForeignKey("ToInventory")]
        public int ToInventoryId { get; set; }

        public InventoryDto ToInventory { get; set; }

        [Required]
        [ForeignKey("Product")]
        public int ProductId { get; set; }

        public ProductDto Product { get; set; }

        [Required]
        [Range(Double.MinValue, Double.MaxValue)]
        public double Quantity { get; set; }

        [DataType(DataType.DateTime)]
        [Editable(false)]
        public DateTime Updated { get; set; }

        
        [Editable(false)]
        public string ByUser { get; set; }
    }   
}