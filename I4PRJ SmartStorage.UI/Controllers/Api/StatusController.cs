using SmartStorage.BLL.Dtos;
using SmartStorage.BLL.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Web.Http;
using SmartStorage.UI.ViewModels;

namespace SmartStorage.UI.Controllers.Api
{
  public class StatusController : ApiController
  {
    private readonly IStatusService _statusService;
    private readonly IStockService _stockService;

    public StatusController(IStatusService statusService, IStockService stockService)
    {
      _statusService = statusService;
      _stockService = stockService;
    }

    public IHttpActionResult GetStatusOfInventory(int id)
    {
      var statusDtos = _statusService.GetUpdated(id);

      return Ok(statusDtos);
    }

    public IHttpActionResult GetStatus(int id)
    {
      var entityDto = _statusService.GetSingle(id);

      return Ok(entityDto);
    }

    [HttpPost]
    public IHttpActionResult CreateStatus(StatusApiModel model)
    {
      var time = DateTime.Now;
      var user = User.Identity.Name;
      var modelDto = new List<StatusDto>();
      for (int i = 0; i < model.ProductIds.Count; i++)
      {
        var statusDto = new StatusDto
        {
          InventoryId = model.InventoryId,
          ProductId = model.ProductIds[i],
          ExpQuantity = model.ExpQuantities[i],
          CurQuantity = model.CurQuantities[i],
          Difference = model.Differences[i],
          IsStarted = model.IsStarted,
          ByUser = user,
          Updated = time
        };
        modelDto.Add(statusDto);
      }

      _statusService.Create(modelDto);
      return Ok();
    }
  }
}