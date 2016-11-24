using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace I4PRJ_SmartStorage.Models.Domain
{
  public class Status
  {
    [Key]
    [DisplayName("#")]
    public int StatusId { get; set; }

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
    [Range(0, double.MaxValue, ErrorMessage = "Please enter a value bigger than {1}")]
    public double Quantity { get; set; }

    [Range(Double.MinValue, Double.MaxValue)]
    [Editable(false)]
    public double Difference { get; set; }

    [DisplayName("Updated")]
    [DataType(DataType.DateTime)]
    [DisplayFormat(DataFormatString = "{0:G}")]
    [Editable(false)]
    public DateTime Updated { get; set; }

    [DisplayName("By")]
    [Editable(false)]
    public string ByUser { get; set; }

    [Editable(false)]
    public bool IsStarted { get; set; }
  }
}