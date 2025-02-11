using ApiProjeKampi.WebApi.Contexts;
using ApiProjeKampi.WebApi.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ApiProjeKampi.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ApiContext _context;

        public CategoriesController(ApiContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetCategories()
        {
            var values = _context.Categories.ToList();
            return Ok(values);
        }

        [HttpGet("GetCategory")]
        public IActionResult GetCategory(int id)
        {
            var value = _context.Categories.Find(id);
            return Ok(value);
        }

        [HttpPost]
        public IActionResult CreateCategory(Category category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();
            return StatusCode(201);
        }

        [HttpPut]
        public IActionResult UpdateCategory(Category category)
        {
            _context.Categories.Update(category);
            _context.SaveChanges();
            return Ok("Kategori başarıyla güncellendi!");
        }

        [HttpDelete]
        public IActionResult DeleteCategory(int id)
        {
            var category = _context.Categories.Find(id);
            if (category is not null)
            {
                _context.Categories.Remove(category);
                _context.SaveChanges();

                return Ok("İşlem başarılı!");
                //return NoContent();
            }

            return NotFound();
        }
    }
}
