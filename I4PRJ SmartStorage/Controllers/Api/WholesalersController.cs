using System.Web.Http;
using I4PRJ_SmartStorage.BLL.Interfaces.Services;

namespace I4PRJ_SmartStorage.Controllers.Api
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