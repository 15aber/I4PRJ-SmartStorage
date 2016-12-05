using System.Web.Http;
using I4PRJ_SmartStorage.BLL.Interfaces.Services;

namespace I4PRJ_SmartStorage.UI.Controllers.Api
{
  public class InventoriesController : ApiController
  {
    private readonly IInventoryService _service;

    public InventoriesController(IInventoryService service)
    {
      _service = service;
    }

    [ActionName("DefaultAction")]
    public IHttpActionResult GetInventories()
    {
      var wholesalerDto = _service.GetAllActive();

      if (wholesalerDto == null) return NotFound();

      return Ok(wholesalerDto);
    }

    [HttpDelete]
    public IHttpActionResult DeleteInventory(int id)
    {
      // TODO null kontrol

      _service.Delete(id);

      return Ok();
    }
  }
}