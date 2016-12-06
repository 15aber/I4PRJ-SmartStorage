using SmartStorage.DAL.Context;
using SmartStorage.DAL.UnitOfWork;
using System.Web.Http;
using SmartStorage.BLL.Interfaces.Services;
using SmartStorage.BLL.Services;

namespace SmartStorage.UI.Controllers.Api
{
  public class WholesalersController : ApiController
  {
    private readonly IWholesalerService _service;

    public WholesalersController()
      : this(new WholesalerService(new UnitOfWork(new ApplicationDbContext())))
    {
    }

    public WholesalersController(IWholesalerService service)
    {
      _service = service ?? new WholesalerService(new UnitOfWork(new ApplicationDbContext()));
    }

    [ActionName("DefaultAction")]
    public IHttpActionResult GetWholesalers()
    {
      var entityDto = _service.GetAllActive();

      if (entityDto == null) return NotFound();

      return Ok(entityDto);
    }

    [HttpDelete]
    public IHttpActionResult DeleteWholesaler(int id)
    {
      // TODO null kontrol

      _service.Delete(id);

      return Ok();
    }
  }
}