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

        //GET /api/suppliers/getsuppliertransactions
        public IHttpActionResult GetSupplierTransactions()
        {
            return Ok(db.Transactions
                .Include(p => p.Product.Supplier)
                .Include(i => i.FromInventory).Where(i => i.FromInventoryId == null)
                .Select(Mapper.Map<Transaction, TransactionDto>));
        }

        // GET /api/suppliers
        [ActionName("DefaultAction")]
        public IHttpActionResult GetSuppliers()
        {
            var suppliersInDb = db.Suppliers.Where(c => c.IsDeleted == false).ToList();

            var suppliers = Mapper.Map<List<Supplier>, List<SupplierDto>>(suppliersInDb.ToList());

            return Ok(suppliers);
        }

        // GET /api/suppliers/getsupplier/1
        public IHttpActionResult GetSupplier(int id)
        {
            var supplier = db.Suppliers.Where(c => c.IsDeleted == false).SingleOrDefault(p => p.SupplierId == id);

            if (supplier == null)
                return NotFound();

            return Ok(Mapper.Map<Supplier, SupplierDto>(supplier));
        }

        //POST /api/suppliers/createsupplier
        [HttpPost]
        public IHttpActionResult CreateSupplier(SupplierDto supplierDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var supplier = Mapper.Map<SupplierDto, Supplier>(supplierDto);

            db.Suppliers.Add(supplier);
            db.SaveChanges();

            supplierDto.SupplierId = supplier.SupplierId;

            return Created(new Uri(Request.RequestUri + "/" + supplier.SupplierId), supplierDto);
        }

        //PUT /api/suppliers/updatesupplier/1
        [HttpPut]
        public IHttpActionResult UpdateSupplier(int id, SupplierDto supplierDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var suppliersInDb = db.Suppliers.Where(c => c.IsDeleted == false).SingleOrDefault(p => p.SupplierId == id);

            if (suppliersInDb == null)
                return NotFound();

            Mapper.Map(supplierDto, suppliersInDb);

            db.SaveChanges();

            return Ok();
        }

        //DELETE /api/suppliers/deletesupplier/1
        [HttpDelete]
        public IHttpActionResult DeleteSupplier(int id)
        {
            var suppliersInDb = db.Suppliers.Where(c => c.IsDeleted == false).SingleOrDefault(p => p.SupplierId == id);

            if (suppliersInDb == null)
                return NotFound();

            suppliersInDb.IsDeleted = true;
            db.SaveChanges();

            return Ok();
        }
    }
}