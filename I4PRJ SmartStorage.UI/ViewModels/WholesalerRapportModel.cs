using SmartStorage.BLL.Dtos;
using System.Collections.Generic;

namespace SmartStorage.UI.ViewModels
{
  public class WholesalerRapportModel
  {
    public WholesalerDto Wholesaler { get; set; }
    public List<WholesalerDto> Wholesalers { get; set; }
    public TransactionDto Transaction { get; set; }
  }
}