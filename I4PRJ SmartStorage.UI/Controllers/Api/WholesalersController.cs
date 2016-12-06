using I4PRJ_SmartStorage.BLL.Interfaces.Services;
using I4PRJ_SmartStorage.BLL.Services;
using I4PRJ_SmartStorage.DAL.Context;
using I4PRJ_SmartStorage.DAL.UnitOfWork;
using System.Web.Http;

namespace I4PRJ_SmartStorage.Controllers.Api
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
      var wholesalerDto = _service.GetAllActive();

      if (wholesalerDto == null) return NotFound();

      return Ok(wholesalerDto);
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