using System.Web.Http;
using AutoMapper;
using I4PRJ_SmartStorage.UI.Identity;

namespace I4PRJ_SmartStorage.UI.Controllers.Api
{
    public class TransactionsController : ApiController
    {
        private ApplicationDbContext db;
        
        public TransactionsController()
        {
           db = new ApplicationDbContext();
        }

        //GET /api/transactions/GetTransactions
        [ActionName("DefaultAction")]
        public IHttpActionResult GetTransactions()
        {
            return Ok(db.Transactions
                .Include(t => t.Product)
                .Include(t => t.FromInventory)
                .Include(t => t.ToInventory)
                .ToList()
                .Select(Mapper.Map<Transaction, TransactionDto>));
        }

        //GET /api/transaction/GetTransactions/1
        public IHttpActionResult GetTransaction(int id)
        {
            var transaction = db.Transactions.SingleOrDefault(t => t.TransactionId == id);

            if (transaction == null)
                return NotFound();

            return Ok(Mapper.Map<Transaction, TransactionDto>(transaction));
        }
    }
}
