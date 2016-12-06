using SmartStorage.DAL.Context;
using SmartStorage.DAL.UnitOfWork;
using System.Web.Http;
using SmartStorage.BLL.Interfaces.Services;
using SmartStorage.BLL.Services;

namespace SmartStorage.UI.Controllers.Api
{
  public class InventoriesController : ApiController
  {
    private readonly IInventoryService _service;

    public InventoriesController()
      : this(new InventoryService(new UnitOfWork(new ApplicationDbContext())))
    {
    }
    public InventoriesController(IInventoryService service)
    {
      _service = service ?? new InventoryService(new UnitOfWork(new ApplicationDbContext()));
    }

    [ActionName("DefaultAction")]
    public IHttpActionResult GetInventories()
    {
      var entityDto = _service.GetAllActive();

      if (entityDto == null) return NotFound();

      return Ok(entityDto);
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