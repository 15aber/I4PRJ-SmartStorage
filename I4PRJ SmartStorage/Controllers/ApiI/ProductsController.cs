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

namespace I4PRJ_SmartStorage.Controllers.Web_API
{
    public class ProductsController : ApiController
    {
        private ApplicationDbContext _context;

        public ProductsController()
        {
            _context = new ApplicationDbContext();
        }

        // GET /WebAPI/products
        public IHttpActionResult GetProducts()
        {
            var productDtos = _context.Products.ToList().Select(Mapper.Map<Product, ProductDto>);

            return Ok(productDtos);
        }

        // GET /WebAPI/products/1
        public IHttpActionResult GetProduct(int id)
        {
            var product = _context.Products.SingleOrDefault(p => p.ProductId == id);

            if (product == null)
                return NotFound();

            return Ok(Mapper.Map<Product, ProductDto>(product));
        }

        // POST /WebAPI/products
        [HttpPost]
        public IHttpActionResult CreateProduct(ProductDto productDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var product = Mapper.Map<ProductDto, Product>(productDto);
            _context.Products.Add(product);
            _context.SaveChanges();

            productDto.ProductId = product.ProductId;
            return Created(new Uri(Request.RequestUri + "/" + product.ProductId), productDto);
        }

        // PUT /api/products/1
        [HttpPut]
        public IHttpActionResult UpdateProduct(int id, ProductDto productDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var productInDb = _context.Products.SingleOrDefault(p => p.ProductId == id);

            if (productInDb == null)
                return NotFound();

            Mapper.Map(productDto, productInDb);

            _context.SaveChanges();

            return Ok();
        }

        // DELETE /WebAPI/products/1
        [HttpDelete]
        public IHttpActionResult DeleteProduct(int id)
        {
            var productInDb = _context.Products.SingleOrDefault(p => p.ProductId == id);

            if (productInDb == null)
                return NotFound();

            _context.Products.Remove(productInDb);
            _context.SaveChanges();

            return Ok();
        }
    }
}
