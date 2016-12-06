using System.Web.Http;
using SmartStorage.BLL.Interfaces.Services;
using SmartStorage.BLL.Services;
using SmartStorage.DAL.Context;
using SmartStorage.DAL.UnitOfWork;

namespace SmartStorage.UI.Controllers.Api
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