using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace I4PRJ_SmartStorage.Models.Domain
{
    public class Transaction
    {
        [Key]
        public int TransactionId { get; set; }

        [Required]
        [ForeignKey("FromInventory")]
        public int FromInventoryId { get; set; }

        [DisplayName("From")]
        public Inventory FromInventory { get; set; }

        [Required]
        [ForeignKey("ToInventory")]
        public int ToInventoryId { get; set; }

        [DisplayName("To")]
        public Inventory ToInventory { get; set; }

        [Required]
        public int ProductId { get; set; }

        public Product Product { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:F2}")]
        [Range(Double.MinValue, Double.MaxValue)]
        public double Quantity { get; set; }

        [DisplayName("When")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:G}")]
        [Editable(false)]
        public DateTime DateTime { get; set; }

        [DisplayName("By")]
        [Editable(false)]
        public string ByUser { get; set; }
    }
}