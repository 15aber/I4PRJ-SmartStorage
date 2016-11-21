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

        public IHttpActionResult GetStatus(int id)
        {
            /*
            if (product == null)
               return NotFound();

            var result = db.Stocks.Join(db.Products.Include(p => p.Category),
                s => s.ProductId,
                p => p.ProductId,
                (stock, product) => new
                {
                    Product = product,
                    Stock = stock
                }).Where(s => s.Stock.InventoryId == id);
          
            var result = db.Products.Include(s => s.Stocks).Include(c => c.Category)
                (product, stock) => new
            {
                Product = product,
                Stock = stock
            }).
            */

            var result = db.Products.Join(db.Stocks,
                p => p.ProductId,
                s => s.ProductId,
                (product, stock) => new
                {
                    Product = product,
                    Stock = stock
                }).Where(s => s.Stock.InventoryId == id);

            return Ok(result);
            //return Ok();
        }

        [HttpPost]
        public IHttpActionResult CreateNewRentals(StatusDto status)
        {
            return Ok();
        }
    }
}
