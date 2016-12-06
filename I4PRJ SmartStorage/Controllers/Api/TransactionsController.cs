using I4PRJ_SmartStorage.BLL.Interfaces.Services;
using System.Web.Http;

namespace I4PRJ_SmartStorage.Controllers.Api
{
  public class TransactionsController : ApiController
  {
    private readonly ITransactionService _service;

    public TransactionsController()
    {
    }

    public TransactionsController(ITransactionService service)
    {
      _service = service;
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
