using SmartStorage.BLL.Dtos;
using System.Collections.Generic;

namespace SmartStorage.BLL.Interfaces.Services
{
  public interface ITransactionService : IService<TransactionDto>
  {
    IList<TransactionDto> GetAllRestock();
  }
}
