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
using Microsoft.Ajax.Utilities;

namespace I4PRJ_SmartStorage.Controllers.Api
{
    public class WholesalersController : ApiController
    {
        private ApplicationDbContext db;

        public WholesalersController()
        {
            db = new ApplicationDbContext();
        }

        //GET /api/wholesalers/getwholesalertransactions
        //[ActionName("DefaultAction")]
        public IHttpActionResult GetWholesalerTransactions()
        {   
            return Ok(db.Transactions
                .Include(p=>p.Product.Wholesaler)
                .Include(i=>i.FromInventory).Where(i=>i.FromInventoryId==null)
                .Select(Mapper.Map<Transaction,TransactionDto>));
        }

        // GET /api/wholesalers
        [ActionName("DefaultAction")]
        public IHttpActionResult GetWholesalers()
        {
            var wholesalersInDb = db.Wholesalers.Where(c => c.IsDeleted == false).ToList();

            var wholesalers = Mapper.Map<List<Wholesaler>, List<WholesalerDto>>(wholesalersInDb.ToList());

            return Ok(wholesalers);
        }

        // GET /api/wholesalers/getwholesaler/1
        public IHttpActionResult GetWholesaler(int id)
        {
            var wholesaler = db.Wholesalers.Where(c => c.IsDeleted == false).SingleOrDefault(p => p.WholesalerId == id);

            if (wholesaler == null)
                return NotFound();

            return Ok(Mapper.Map<Wholesaler, WholesalerDto>(wholesaler));
        }

        //POST /api/wholesalers/createwholesaler
        [HttpPost]
        public IHttpActionResult CreateWholesaler(WholesalerDto wholesalerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var wholesaler = Mapper.Map<WholesalerDto, Wholesaler>(wholesalerDto);

            db.Wholesalers.Add(wholesaler);
            db.SaveChanges();

            wholesalerDto.WholesalerId = wholesaler.WholesalerId;

            return Created(new Uri(Request.RequestUri + "/" + wholesaler.WholesalerId), wholesalerDto);
        }

        //PUT /api/wholesalers/updatewholesaler/1
        [HttpPut]
        public IHttpActionResult UpdateWholesaler(int id, WholesalerDto wholesalerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var wholesalerInDb = db.Wholesalers.Where(c => c.IsDeleted == false).SingleOrDefault(p => p.WholesalerId == id);

            if (wholesalerInDb == null)
                return NotFound();

            Mapper.Map(wholesalerDto, wholesalerInDb);

            db.SaveChanges();

            return Ok();
        }

        //DELETE /api/wholesalers/deletewholesaler/1
        [HttpDelete]
        public IHttpActionResult DeleteWholesaler(int id)
        {
            var wholesalerInDb = db.Wholesalers.Where(c => c.IsDeleted == false).SingleOrDefault(p => p.WholesalerId == id);

            if (wholesalerInDb == null)
                return NotFound();

            wholesalerInDb.IsDeleted = true;
            db.SaveChanges();

            return Ok();
        }
    }
}