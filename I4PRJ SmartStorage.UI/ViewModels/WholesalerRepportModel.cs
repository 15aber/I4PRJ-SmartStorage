using System.Collections.Generic;
using SmartStorage.BLL.Dtos;

namespace SmartStorage.UI.ViewModels
{
  public class WholesalerRepportModel
  {
    public WholesalerDto Wholesaler { get; set; }
    public List<WholesalerDto> Wholesalers { get; set; }
    public List<TransactionDto> Transaction { get; set; }
  }
}
