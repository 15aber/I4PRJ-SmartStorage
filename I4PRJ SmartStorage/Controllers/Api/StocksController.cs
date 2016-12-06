using I4PRJ_SmartStorage.BLL.Interfaces.Services;
using I4PRJ_SmartStorage.BLL.Services;
using I4PRJ_SmartStorage.DAL.Context;
using I4PRJ_SmartStorage.DAL.UnitOfWork;
using System.Web.Http;

namespace I4PRJ_SmartStorage.Controllers.Api
{
  public class StocksController : ApiController
  {
    private readonly IStockService _service;

    public StocksController()
      : this(new StockService(new UnitOfWork(new ApplicationDbContext())))
    {
    }

    public StocksController(IStockService service)
    {
      _service = service ?? new StockService(new UnitOfWork(new ApplicationDbContext()));
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