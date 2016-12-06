using System.Web.Http;
using SmartStorage.BLL.Interfaces.Services;
using SmartStorage.BLL.Services;
using SmartStorage.DAL.Context;
using SmartStorage.DAL.UnitOfWork;

namespace SmartStorage.UI.Controllers.Api
{
  public class TransactionsController : ApiController
  {
    private readonly ITransactionService _service;

    public TransactionsController()
      : this(new TransactionService(new UnitOfWork(new ApplicationDbContext())))
    {
    }

    public TransactionsController(ITransactionService service)
    {
      _service = service ?? new TransactionService(new UnitOfWork(new ApplicationDbContext()));
    }

    [ActionName("DefaultAction")]
    public IHttpActionResult GetTransactions()
    {
      var entityDto = _service.GetAll();

      if (entityDto == null) return NotFound();

      return Ok(entityDto);
    }
  }
}
