using SmartStorage.BLL.Interfaces.Services;
using System.Web.Http;

namespace SmartStorage.UI.Controllers.Api
{
  public class WholesalersController : ApiController
  {
    private readonly IWholesalerService _service;

    public WholesalersController(IWholesalerService service)
    {
      _service = service;
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