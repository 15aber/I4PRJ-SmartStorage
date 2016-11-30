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

namespace I4PRJ_SmartStorage.Controllers.Api
{
    public class TransactionsController : ApiController
    {
        private ApplicationDbContext db;
        
        public TransactionsController()
        {
           db = new ApplicationDbContext();
        }

        //GET /api/transactions/GetTransactions
        [ActionName("DefaultAction")]
        public IHttpActionResult GetTransactions()
        {
            return Ok(db.Transactions
                .Include(t => t.Product)
                .Include(t => t.FromInventory)
                .Include(t => t.ToInventory)
                .ToList()
                .Select(Mapper.Map<Transaction, TransactionDto>));
        }

        //GET /api/transaction/GetTransactions/1
        public IHttpActionResult GetTransaction(int id)
        {
            var transaction = db.Transactions.SingleOrDefault(t => t.TransactionId == id);

            if (transaction == null)
                return NotFound();

            return Ok(Mapper.Map<Transaction, TransactionDto>(transaction));
        }
    }
}
