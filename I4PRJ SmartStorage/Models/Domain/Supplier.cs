using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace I4PRJ_SmartStorage.Models.Domain
{
    public class Supplier
    {
        [Key]
        public int SupplierId { get; set; }
        [Required]
        [DisplayName("Supplier")]
        public string Name { get; set; }

        //[Required]
        //[ForeignKey("Product")]
        //[DisplayName("Product")]
        //public int ProductId { get; set; }

        //[DisplayName("Delivery date")]
        //[DataType(DataType.DateTime)]
        //[DisplayFormat(DataFormatString = "{0:G}")]
        //[Editable(false)]
        //public DateTime DeliveryDate { get; set; }

    }
}