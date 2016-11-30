using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using I4PRJ_SmartStorage.Models.Domain;

namespace I4PRJ_SmartStorage.Dtos
{
    public class ProductDto
    {
        public int ProductId { get; set; }

        [Required]
        public string Name { get; set; }

        [DataType(DataType.Currency)]
        [Range(0, Double.MaxValue)]
        public double PurchasePrice { get; set; }

        [Required]
        public int CategoryId { get; set; }

        public Category Category { get; set; }

        public List<Stock> Stock { get; set; }

        public int WholesalerId { get; set; }

        public Wholesaler Wholesaler { get; set; }

        public int SupplierId { get; set; }

        public Supplier Supplier { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:G}")]
        [Editable(false)]
        public DateTime Updated { get; set; }

        [Editable(false)]
        public string ByUser { get; set; }

        public bool IsDeleted { get; set; }
    }
}