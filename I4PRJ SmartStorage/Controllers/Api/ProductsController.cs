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
        private ApplicationDbContext db;

        public ProductsController()
        {
            db = new ApplicationDbContext();
        }

        // GET /api/products
        [ActionName("DefaultAction")]
        public IHttpActionResult GetProducts()
        {
            var productsInDb = db.Products.Where(c => c.IsDeleted == false).Include(p => p.Category).ToList();

            var products = Mapper.Map<List<Product>, List<ProductDto>>(productsInDb.ToList());

            return Ok(products);
        }

        // GET /api/products/getproduct/1
        public IHttpActionResult GetProduct(int id)
        {
            var product = db.Products.Where(c => c.IsDeleted == false).SingleOrDefault(p => p.ProductId == id);

            if (product == null)
                return NotFound();

            return Ok(Mapper.Map<Product, ProductDto>(product));
        }

        // GET /api/products/getproductsofinventory/1
        public IHttpActionResult GetProductsOfInventory(int id)
        {
            // get stocks that have InventoryId == id
            var productsInDb = db.Stocks.Where(o => o.InventoryId == id).Select(o => o.Product);

            var products = Mapper.Map<List<Product>, List<ProductDto>>(productsInDb.ToList());

            return Json(products);
        }

        // GET /api/products/getproductsofcategory/1
        public IHttpActionResult GetProductsOfCategory(int id)
        {
            // get products that have CategoryId == id
            var productsInDb = db.Products.Where(c => c.IsDeleted == false).Where(o => o.CategoryId == id);

            var products = Mapper.Map<List<Product>, List<ProductDto>>(productsInDb.ToList());

            return Ok(products);
        }

        // POST /api/products/createproduct
        [HttpPost]
        public IHttpActionResult CreateProduct(ProductDto productDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var product = Mapper.Map<ProductDto, Product>(productDto);
            db.Products.Add(product);
            db.SaveChanges();

            productDto.ProductId = product.ProductId;
            return Created(new Uri(Request.RequestUri + "/" + product.ProductId), productDto);
        }

        // PUT /api/products/updateproduct/1
        [HttpPut]
        public IHttpActionResult UpdateProduct(int id, ProductDto productDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var productInDb = db.Products.Where(c => c.IsDeleted == false).SingleOrDefault(p => p.ProductId == id);

            if (productInDb == null)
                return NotFound();

            Mapper.Map(productDto, productInDb);

            db.SaveChanges();

            return Ok();
        }

        // DELETE /api/products/deleteproduct/1
        [HttpDelete]
        public IHttpActionResult DeleteProduct(int id)
        {
            var productInDb = db.Products.Where(c => c.IsDeleted == false).SingleOrDefault(p => p.ProductId == id);

            if (productInDb == null)
                return NotFound();

            productInDb.IsDeleted = true;
            db.SaveChanges();

            return Ok();
        }
    }
}