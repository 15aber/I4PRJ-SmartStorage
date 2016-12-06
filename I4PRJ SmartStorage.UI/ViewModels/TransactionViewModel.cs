using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using SmartStorage.BLL.Dtos;

namespace SmartStorage.UI.ViewModels
{
  public class TransactionViewModel
  {



    public List<TransactionDto> Transactions { get; set; }

    public TransactionDto Transaction { get; set; }



    [Required]
    [DisplayName("From")]
    public int FromInventoryId { get; set; }
    public IList<InventoryDto> FromInventory { get; set; }

    [Required]
    [DisplayName("To")]
    public int ToInventoryId { get; set; }
    public IList<InventoryDto> ToInventory { get; set; }

    [Required]
    [DisplayName("Product")]
    public int ProductId { get; set; }
    public IList<ProductDto> Products { get; set; }

    [Required]
    [DisplayFormat(DataFormatString = "{0:G}")]
    [Range(Double.MinValue, Double.MaxValue)]
    public double Quantity { get; set; }

    [DisplayName("Restock")]
    public bool IsChecked { get; set; }
  }
}