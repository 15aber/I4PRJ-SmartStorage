using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Http;
using AutoMapper;
using I4PRJ_SmartStorage.Dtos;
using I4PRJ_SmartStorage.Models;
using I4PRJ_SmartStorage.Models.Domain;

namespace I4PRJ_SmartStorage.Controllers.Api
{
    public class SuppliersController : ApiController 
    {
        private ApplicationDbContext db;

        public SuppliersController()
        {
            db = new ApplicationDbContext();
        }

        //GET /api/suppliers/GetSuppliersTransactions
        [ActionName("DefaultAction")]
        public IHttpActionResult GetSuppliers()
        {
            return Ok(db.Transactions
                .Include(p => p.Product.Supplier)
                .Include(i => i.FromInventory).Where(i => i.FromInventoryId == null)
                .Select(Mapper.Map<Transaction, TransactionDto>));
        }
    }
}