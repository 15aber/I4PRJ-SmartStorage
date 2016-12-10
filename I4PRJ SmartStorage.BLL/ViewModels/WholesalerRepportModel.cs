using SmartStorage.BLL.Dtos;
using System.Collections.Generic;

namespace SmartStorage.BLL.ViewModels
{
  public class WholesalerRepportModel
  {
    public WholesalerDto Wholesaler { get; set; }
    public List<WholesalerDto> Wholesalers { get; set; }
    public List<TransactionDto> Transaction { get; set; }
  }
}
