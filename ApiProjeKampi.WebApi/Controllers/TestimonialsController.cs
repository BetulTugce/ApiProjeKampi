using ApiProjeKampi.WebApi.Contexts;
using ApiProjeKampi.WebApi.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ApiProjeKampi.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialsController : ControllerBase
    {
        private readonly ApiContext _context;

        public TestimonialsController(ApiContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetTestimonials()
        {
            var values = _context.Testimonials.ToList();
            return Ok(values);
        }

        [HttpGet("GetTestimonial")]
        public IActionResult GetTestimonial(int id)
        {
            var value = _context.Testimonials.Find(id);
            return Ok(value);
        }

        [HttpPost]
        public IActionResult CreateTestimonial(Testimonial testimonial)
        {
            _context.Testimonials.Add(testimonial);
            _context.SaveChanges();
            return StatusCode(201);
        }

        [HttpPut]
        public IActionResult UpdateTestimonial(Testimonial testimonial)
        {
            _context.Testimonials.Update(testimonial);
            _context.SaveChanges();
            return Ok("Müşteri yorumu başarıyla güncellendi!");
        }

        [HttpDelete]
        public IActionResult DeleteTestimonial(int id)
        {
            var testimonial = _context.Testimonials.Find(id);
            if (testimonial is not null)
            {
                _context.Testimonials.Remove(testimonial);
                _context.SaveChanges();

                return Ok("İşlem başarılı!");
                //return NoContent();
            }

            return NotFound();
        }
    }
}
