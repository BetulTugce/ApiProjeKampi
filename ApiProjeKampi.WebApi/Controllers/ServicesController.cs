﻿using ApiProjeKampi.WebApi.Contexts;
using ApiProjeKampi.WebApi.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiProjeKampi.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicesController : ControllerBase
    {
        private readonly ApiContext _context;

        public ServicesController(ApiContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetServices()
        {
            var values = _context.Services.ToList();
            return Ok(values);
        }

        [HttpGet("GetService")]
        public IActionResult GetService(int id)
        {
            var value = _context.Services.Find(id);
            return Ok(value);
        }

        [HttpPost]
        public IActionResult CreateService(Service service)
        {
            _context.Services.Add(service);
            _context.SaveChanges();
            return StatusCode(201);
        }

        [HttpPut]
        public IActionResult UpdateService(Service service)
        {
            _context.Services.Update(service);
            _context.SaveChanges();
            return Ok("Servis başarıyla güncellendi!");
        }

        [HttpDelete]
        public IActionResult DeleteService(int id)
        {
            var service = _context.Services.Find(id);
            if (service is not null)
            {
                _context.Services.Remove(service);
                _context.SaveChanges();

                return Ok("İşlem başarılı!");
                //return NoContent();
            }

            return NotFound();
        }
    }
}
