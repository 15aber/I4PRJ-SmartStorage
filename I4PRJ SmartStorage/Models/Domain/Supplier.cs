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
        //[DisplayName("Product")]
        //public Product Product { get; set; }
    }
}