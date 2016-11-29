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
    public class CategoriesController : ApiController
    {
        private ApplicationDbContext db;

        public CategoriesController()
        {
            db = new ApplicationDbContext();
        }

        // GET /api/categories
        [ActionName("DefaultAction")]
        public IHttpActionResult GetCategories()
        {
            var categoriesInDb = db.Categories.Where(c => c.IsDeleted == false).ToList();

            var categories = Mapper.Map<List<Category>, List<CategoryDto>>(categoriesInDb.ToList());

            return Ok(categories);
        }

        // GET /api/categories/getcategory/1
        public IHttpActionResult GetCategory(int id)
        {
            var category = db.Categories.Where(c => c.IsDeleted == false).SingleOrDefault(p => p.CategoryId == id);

            if (category == null)
                return NotFound();

            return Ok(Mapper.Map<Category, CategoryDto>(category));
        }

        // POST /api/categories/createcategory
        [HttpPost]
        public IHttpActionResult CreateCategory(CategoryDto categoryDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var category = Mapper.Map<CategoryDto, Category>(categoryDto);
            db.Categories.Add(category);
            db.SaveChanges();

            categoryDto.CategoryId = category.CategoryId;
            return Created(new Uri(Request.RequestUri + "/" + category.CategoryId), categoryDto);
        }

        // PUT /api/categories/updatecategory/1
        [HttpPut]
        public IHttpActionResult UpdateCategory(int id, CategoryDto categoryDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var categoryInDb = db.Categories.Where(c => c.IsDeleted == false).SingleOrDefault(p => p.CategoryId == id);

            if (categoryInDb == null)
                return NotFound();

            Mapper.Map(categoryDto, categoryInDb);

            db.SaveChanges();

            return Ok();
        }

        // DELETE /api/categories/deletecategory/1
        [HttpDelete]
        public IHttpActionResult DeleteCategory(int id)
        {
            var categoryInDb = db.Categories.Where(c => c.IsDeleted == false).SingleOrDefault(p => p.CategoryId == id);

            if (categoryInDb == null)
                return NotFound();

            categoryInDb.IsDeleted = true;
            db.SaveChanges();

            return Ok();
        }
    }
}
