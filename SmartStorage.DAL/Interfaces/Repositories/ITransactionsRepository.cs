using SmartStorage.DAL.Models;
using System.Collections.Generic;

namespace SmartStorage.DAL.Interfaces.Repositories
{
  public interface ITransactionsRepository : IRepository<Transaction>
  {
    List<Transaction> GetAllRestock();
  }
}