using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;
using AutoMapper;
using I4PRJ_SmartStorage.Dtos;
using I4PRJ_SmartStorage.Models;
using I4PRJ_SmartStorage.Models.Domain;

namespace I4PRJ_SmartStorage.Controllers.Api
{
    public class ProductsController : ApiController
    {
        private ApplicationDbContext _context;

        public ProductsController()
        {
            _context = new ApplicationDbContext();
        }

        // GET /api/products
        [ActionName("DefaultAction")]
        public IHttpActionResult GetProducts()
        {
            var productsInDb = _context.Products.Include(p => p.Category).ToList();

            var products = Mapper.Map<List<Product>, List<ProductDto>>(productsInDb.ToList());

            return Ok(products);
        }

        // GET /api/products/getproduct/1
        public IHttpActionResult GetProduct(int id)
        {
            var product = _context.Products.SingleOrDefault(p => p.ProductId == id);

            if(product == null)
            return NotFound();

            return Ok(Mapper.Map<Product, ProductDto>(product));
        }

        // GET /api/products/getproductsofinventory/1
        public IHttpActionResult GetProductsOfInventory(int id)
        {
            // get stocks that have InventoryId == id
            var productsInDb = _context.Stocks.Where(o => o.InventoryId == id).Select(o => o.Product);

            var products = Mapper.Map<List<Product>, List<ProductDto>>(productsInDb.ToList());

            return Json(products);
        }

        // GET /api/products/getproductsofinventory/1
        public IHttpActionResult GetProductsOfCategory(int id)
        {
            // get stocks that have InventoryId == id
            var productsInDb = _context.Products.Where(o => o.CategoryId == id);

            var products = Mapper.Map<List<Product>, List<ProductDto>>(productsInDb.ToList());

            return Ok(products);
        }
    
        // GET /api/products/getproductsofwholesaler/1
        public IHttpActionResult GetProductsOfWholesaler(int id)
        {
            var productsInDb = _context.Products.Where(w => w.WholesalerId == id);

            var products = Mapper.Map<List<Product>, List<ProductDto>>(productsInDb.ToList());

            return Ok(products);
        }

        // GET /api/products/getproductsofsuppliers/1
        public IHttpActionResult GetProductsOfSupplier(int id)
        {
            var productsInDb = _context.Products.Where(s => s.SupplierId == id);

            var products = Mapper.Map<List<Product>, List<ProductDto>>(productsInDb.ToList());

            return Ok(products);
        }

        // POST /api/products/createproduct
        [HttpPost]
        public IHttpActionResult CreateProduct(ProductDto productDto)
        {
            if(!ModelState.IsValid)
            return BadRequest();

            var product = Mapper.Map<ProductDto, Product>(productDto);
            _context.Products.Add(product);
            _context.SaveChanges();

            productDto.ProductId = product.ProductId;
            return Created(new Uri(Request.RequestUri + "/" + product.ProductId), productDto);
        }

        // PUT /api/products/updateproduct/1
        [HttpPut]
        public IHttpActionResult UpdateProduct(int id, ProductDto productDto)
        {
            if(!ModelState.IsValid)
            return BadRequest();

            var productInDb = _context.Products.SingleOrDefault(p => p.ProductId == id);

            if(productInDb == null)
            return NotFound();

            Mapper.Map(productDto, productInDb);

            _context.SaveChanges();

            return Ok();
        }

        // DELETE /api/products/deleteproduct/1
        [HttpDelete]
        public IHttpActionResult DeleteProduct(int id)
        {
            var productInDb = _context.Products.SingleOrDefault(p => p.ProductId == id);

            if(productInDb == null)
            return NotFound();

            productInDb.IsDeleted = true;
            _context.SaveChanges();

            return Ok();
        }
    }
}