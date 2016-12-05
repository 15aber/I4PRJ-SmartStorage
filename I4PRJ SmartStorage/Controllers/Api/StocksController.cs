using System.Web.Http;
using I4PRJ_SmartStorage.BLL.Interfaces.Services;

namespace I4PRJ_SmartStorage.Controllers.Api
{
  public class StocksController : ApiController
  {
    private readonly IStockService _service;

    public StocksController(IStockService service)
    {
      _service = service;
    }

    [ActionName("DefaultAction")]
    public IHttpActionResult GetStocksOfInventory(int id)
    {
      var entityDto = _service.GetAllActiveOfInventory(id);

      if (entityDto == null) return NotFound();

      return Ok(entityDto);
    }
  }
}