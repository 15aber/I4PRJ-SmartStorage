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
    public class StocksController : ApiController
    {
        private ApplicationDbContext db;

        public StocksController()
        {
            db = new ApplicationDbContext();
        }

        public IHttpActionResult GetStocks(int id)
        {
            //var product = _context.Products.SingleOrDefault(p => p.ProductId == id);

            //if (product == null)
            //   return NotFound();

            var viewModel = new StatusViewModel
            {
                Products = db.Products.Include(p => p.Category).Where(p => p.IsDeleted != true).ToList(),
                Stocks = db.Stocks.Where(s => s.InventoryId == id).ToList()
            };

            return Ok(viewModel);
        }
    }
}
