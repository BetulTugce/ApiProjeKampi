using ApiProjeKampi.WebApi.Contexts;
using ApiProjeKampi.WebApi.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiProjeKampi.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class YummyEventsController : ControllerBase
    {
        private readonly ApiContext _context;

        public YummyEventsController(ApiContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetYummyEvents()
        {
            var values = _context.YummyEvents.ToList();
            return Ok(values);
        }

        [HttpGet("GetYummyEvent")]
        public IActionResult GetYummyEvent(int id)
        {
            var value = _context.YummyEvents.Find(id);
            return Ok(value);
        }

        [HttpPost]
        public IActionResult CreateYummyEvent(YummyEvent yummyEvent)
        {
            _context.YummyEvents.Add(yummyEvent);
            _context.SaveChanges();
            return StatusCode(201);
        }

        [HttpPut]
        public IActionResult UpdateYummyEvent(YummyEvent yummyEvent)
        {
            _context.YummyEvents.Update(yummyEvent);
            _context.SaveChanges();
            return Ok("Etkinlik başarıyla güncellendi!");
        }

        [HttpDelete]
        public IActionResult DeleteYummyEvent(int id)
        {
            var yummyEvent = _context.YummyEvents.Find(id);
            if (yummyEvent is not null)
            {
                _context.YummyEvents.Remove(yummyEvent);
                _context.SaveChanges();

                return Ok("İşlem başarılı!");
                //return NoContent();
            }

            return NotFound();
        }
    }
}
