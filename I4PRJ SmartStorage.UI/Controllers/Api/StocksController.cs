using SmartStorage.BLL.Interfaces.Services;
using System.Web.Http;

namespace SmartStorage.UI.Controllers.Api
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
      var entityDto = _service.GetAllOfInventory(id);

      if (entityDto == null) return NotFound();

      return Ok(entityDto);
    }
  }
}