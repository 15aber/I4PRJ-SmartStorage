﻿using System;
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
    public class WholesalerController : ApiController
    {
        private ApplicationDbContext db;

        public WholesalerController()
        {
            db = new ApplicationDbContext();
        }

        //GET /api/wholesalers/GetWholesalers
        [ActionName("DefaultAction")]
        public IHttpActionResult GetWholesalers()
        {   
            return Ok(db.Transactions
                .Include(p=>p.Product.Wholesaler)
                .Include(i=>i.FromInventory).Where(i=>i.FromInventoryId==null)
                .Select(Mapper.Map<Transaction,TransactionDto>));
        }
    }
}