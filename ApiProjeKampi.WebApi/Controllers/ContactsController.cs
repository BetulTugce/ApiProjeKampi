using ApiProjeKampi.WebApi.Contexts;
using ApiProjeKampi.WebApi.Dtos.ContactDtos;
using ApiProjeKampi.WebApi.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiProjeKampi.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly ApiContext _context;

        public ContactsController(ApiContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetContacts()
        {
            var values = _context.Contacts.ToList();

            return Ok(values.Select(contact => new ResultContactDto
            {
                ContactId = contact.ContactId,
                Address = contact.Address,
                Email = contact.Email,
                MapLocation = contact.MapLocation,
                OpenHours = contact.OpenHours,
                Phone = contact.Phone
            }));
        }

        [HttpPost]
        public IActionResult CreateContact(CreateContactDto contactDto)
        {
            Contact contact = new Contact();
            contact.Email = contactDto.Email;
            contact.Phone = contactDto.Phone;
            contact.Address = contactDto.Address;
            contact.MapLocation = contactDto.MapLocation;
            contact.OpenHours = contactDto.OpenHours;
            _context.Contacts.Add(contact);
            _context.SaveChanges();
            return StatusCode(statusCode: 201);
        }
    }
}
