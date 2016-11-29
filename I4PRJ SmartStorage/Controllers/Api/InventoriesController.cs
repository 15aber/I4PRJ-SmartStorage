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

        // GET /api/inventories/getinventory/1
        public IHttpActionResult GetInventory(int id)
        {
            var inventory = db.Inventories.Where(c => c.IsDeleted == false).SingleOrDefault(p => p.InventoryId == id);

            if (inventory == null)
                return NotFound();

            return Ok(Mapper.Map<Inventory, InventoryDto>(inventory));
        }

        // POST /api/inventories/createinventory
        [HttpPost]
        public IHttpActionResult CreateInventory(InventoryDto inventoryDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var inventory = Mapper.Map<InventoryDto, Inventory>(inventoryDto);
            db.Inventories.Add(inventory);
            db.SaveChanges();

            inventoryDto.InventoryId = inventory.InventoryId;
            return Created(new Uri(Request.RequestUri + "/" + inventory.InventoryId), inventoryDto);
        }

        // PUT /api/inventories/updateinventory/1
        [HttpPut]
        public IHttpActionResult UpdateInventory(int id, InventoryDto inventoryDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var inventoryInDb = db.Inventories.Where(c => c.IsDeleted == false).SingleOrDefault(p => p.InventoryId == id);

            if (inventoryInDb == null)
                return NotFound();

            Mapper.Map(inventoryDto, inventoryInDb);

            db.SaveChanges();

            return Ok();
        }

        // DELETE /api/inventories/deleteinventory/1
        [HttpDelete]
        public IHttpActionResult DeleteInventory(int id)
        {
            var inventoryInDb = db.Inventories.Where(c => c.IsDeleted == false).SingleOrDefault(p => p.InventoryId == id);

            if (inventoryInDb == null)
                return NotFound();

            inventoryInDb.IsDeleted = true;
            db.SaveChanges();

            return Ok();
        }
    }
}