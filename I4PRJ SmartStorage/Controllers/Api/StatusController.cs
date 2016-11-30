using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using I4PRJ_SmartStorage.Dtos;
using I4PRJ_SmartStorage.Models;
using I4PRJ_SmartStorage.Models.Domain;
using I4PRJ_SmartStorage.ViewModels;

namespace I4PRJ_SmartStorage.Controllers.Api
{
    public class StatusController : ApiController
    {
        private ApplicationDbContext db;

        public StatusController()
        {
            db = new ApplicationDbContext();
        }

        public IHttpActionResult GetStatusOfInventory(int id)
        {
            var inventory = db.Inventories.Find(id);

            if (inventory == null)
               return NotFound();
            
            var status = db.Stocks.Include(s => s.Inventory)
                .Include(p => p.Product)
                .Include(c => c.Product.Category).Where(i => i.InventoryId == id);

            return Ok(status);
        }

        public IHttpActionResult GetStatus(int id)
        {
            var status = db.Statuses.Find(id);

            if (status == null)
                return NotFound();

            var statuses = db.Statuses.Include(i => i.Product.Category)
                .Where(s => s.Updated == status.Updated && s.InventoryId == status.InventoryId).ToList();

            return Ok(statuses);
        }

        [HttpPost]
        public IHttpActionResult CreateStatus(NewStatusDto statusDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var time = DateTime.Now;

            for (int i = 0; i < statusDto.CurQuantities.Count; i++)
            {
                if(statusDto.CurQuantities[i] == null)
                    return BadRequest("Quantity value is invalid");

                var status = new Status
                {
                    InventoryId = statusDto.InventoryId,
                    ExpQuantity = statusDto.ExpQuantities[i],
                    CurQuantity = statusDto.CurQuantities[i],
                    IsStarted = statusDto.IsStarted,
                    ByUser = User.Identity.Name,
                    Difference = statusDto.Differences[i],
                    Updated = time,
                    ProductId = statusDto.ProductIds[i]
                };

                db.Statuses.Add(status);
            }

            db.SaveChanges();

            return Ok();
        }
    }
}