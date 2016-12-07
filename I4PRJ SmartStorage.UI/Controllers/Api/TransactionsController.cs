using SmartStorage.BLL.Interfaces.Services;
using System.Web.Http;

namespace SmartStorage.UI.Controllers.Api
{
  public class TransactionsController : ApiController
  {
    private readonly ITransactionService _service;

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
