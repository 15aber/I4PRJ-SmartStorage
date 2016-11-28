using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using I4PRJ_SmartStorage.Dtos;
using I4PRJ_SmartStorage.Models;
using I4PRJ_SmartStorage.Models.Domain;

namespace I4PRJ_SmartStorage.Controllers.Api
{
    public class InventoriesController : ApiController
    {
        private ApplicationDbContext db;

        public InventoriesController()
        {
            db = new ApplicationDbContext();
        }

        // GET /api/inventories
        [ActionName("DefaultAction")]
        public IHttpActionResult GetInventories()
        {
            var inventoriesInDb = db.Inventories.Where(i => i.IsDeleted == false).ToList();

            var inventories = Mapper.Map<List<Inventory>, List<InventoryDto>>(inventoriesInDb.ToList());

            return Json(inventories);
        }

        public IHttpActionResult GetOtherInventories(int id)
        {
            var inventoriesInDb = db.Inventories.Where(i => i.IsDeleted == false && i.InventoryId != id).ToList();

            var inventories = Mapper.Map<List<Inventory>, List<InventoryDto>>(inventoriesInDb.ToList());

            return Json(inventories);
        }
    }
}