using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace I4PRJ_SmartStorage.Models.Domain
{
    public class Stock
    {
        [Key]
        [DisplayName("#")]
        public int StockId { get; set; }

        [Required]
        [ForeignKey("Inventory")]
        [DisplayName("Inventory")]
        public int InventoryId { get; set; }

        public Inventory Inventory { get; set; }

        [Required]
        [ForeignKey("Product")]
        [DisplayName("Product")]
        public int ProductId { get; set; }

        public Product Product { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:F2}")]
        [Range(Double.MinValue, Double.MaxValue)]
        public double Quantity { get; set; }

        //[DisplayName("Last Updated")]
        //[DataType(DataType.DateTime)]
        //[DisplayFormat(DataFormatString = "{0:G}")]
        //[Editable(false)]
        //public DateTime LastUpdated { get; set; }

        //[DisplayName("By Username")]
        //[Editable(false)]
        //public string ByUser { get; set; }

        //[Timestamp]
        //[HiddenInput(DisplayValue = false)]
        //public byte[] Version { get; set; }
    }
}