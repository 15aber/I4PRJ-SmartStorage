using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
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

            var status = from i in db.Inventories.Where(i => i.InventoryId == id)//Primary where clause
                               join stk in db.Stocks on i.InventoryId equals stk.InventoryId
                               join p in db.Products on stk.ProductId equals p.ProductId
                               join cat in db.Categories on p.CategoryId equals cat.CategoryId
                               select new //Setup projection
                               {
                                   ProductId = p.ProductId,
                                   ProductName = p.Name,
                                   Quantity  = stk.Quantity,
                                   CategoryName = cat.Name
                               }; //INNER JOIN

            return Ok(status);
        }

        public IHttpActionResult GetStatus(int id)
        {
            var status = db.Statuses.Find(id);

            if (status == null)
                return NotFound();

            var statuses = from sts in db.Statuses.Where(sts => sts.InventoryId == status.InventoryId 
                           && EntityFunctions.DiffSeconds(sts.Updated, status.Updated) == 0) //Primary where clause
                         join cat in db.Categories on sts.Product.CategoryId equals cat.CategoryId
                         join p in db.Products on sts.ProductId equals p.ProductId
                         select new //Setup projection
                         {
                             ProductName = p.Name,
                             CategoryName = cat.Name,
                             ExpQuantity = sts.ExpQuantity,
                             CurQuantity = sts.CurQuantity,
                             Difference = sts.Difference
                         }; //INNER JOIN

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