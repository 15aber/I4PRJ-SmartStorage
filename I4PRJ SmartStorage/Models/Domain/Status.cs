using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace I4PRJ_SmartStorage.Models.Domain
{
    public class Status
    {
        [Key]
        public int StatusId { get; set; }

        [Required]
        [DisplayName("Inventory")]
        public int InventoryId { get; set; }
        public Inventory Inventory { get; set; }

        [Required]
        [DisplayName("Product")]
        public int ProductId { get; set; }
        public Product Product { get; set; }

        [Required]
        public int Quantity { get; set; }

        public int Difference { get; set; }

        [DisplayName("When")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:G}")]
        [Editable(false)]
        public DateTime DateTime { get; set; }

        public bool IsStarted { get; set; }
    }
}