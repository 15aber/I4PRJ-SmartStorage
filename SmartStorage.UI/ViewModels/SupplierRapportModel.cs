using SmartStorage.BLL.Dtos;
using System.Collections.Generic;

namespace SmartStorage.UI.ViewModels
{
  public class SupplierRapportModel
  {
    public SupplierDto Supplier { get; set; }
    public List<SupplierDto> Suppliers { get; set; }
    public TransactionDto Transaction { get; set; }
  }
}