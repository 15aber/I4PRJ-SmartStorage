using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.Linq;
using System.Web;

namespace I4PRJ_SmartStorage.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Purchase Price")]
        public double PurchasePrice { get; set; }

        public int Package { get; set; }

        [Display(Name = "Last Edited")]
        public DateTime DateLastEdit { get; set; }  

        //public Category Category { get; set; }

        [Required]
        [Display(Name = "Category")]
        public byte CategoryId { get; set; }


    }
}