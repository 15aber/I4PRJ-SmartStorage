using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace I4PRJ_SmartStorage.Dtos
{
    public class WholesalerDto
    {
        [Key]
        [DisplayName("#")]
        public int WholesalerId { get; set; }

        [Required]
        [DisplayName("Wholesaler")]
        public string Name { get; set; }

        [DisplayName("Updated")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:G}")]
        [Editable(false)]
        public DateTime Updated { get; set; }

        [DisplayName("By")]
        [Editable(false)]
        public string ByUser { get; set; }

        [DisplayName("Archived")]
        [Editable(false)]
        public bool IsDeleted { get; set; }

        [Required]
        [ForeignKey("Product")]
        [DisplayName("Product")]
        public int ProductId { get; set; }
    }
}