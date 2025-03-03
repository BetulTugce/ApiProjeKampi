﻿using ApiProjeKampi.WebApi.Contexts;
using ApiProjeKampi.WebApi.Dtos.MessageDtos;
using ApiProjeKampi.WebApi.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiProjeKampi.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        private readonly ApiContext _context;
        private readonly IMapper _mapper;

        public MessagesController(ApiContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetMessages()
        {
            var values = _context.Messages.ToList();
            return Ok(_mapper.Map<List<ResultMessageDto>>(values));
        }

        [HttpGet("GetMessage")]
        public IActionResult GetMessage(int id)
        {
            var value = _context.Messages.Find(id);
            return Ok(_mapper.Map<GetByIdMessageDto>(value));
        }

        [HttpPost]
        public IActionResult CreateMessage(CreateMessageDto createMessageDto)
        {
            _context.Messages.Add(_mapper.Map<Message>(createMessageDto));
            _context.SaveChanges();
            return StatusCode(201);
        }

        [HttpPut]
        public IActionResult UpdateMessage(UpdateMessageDto updateMessageDto)
        {
            _context.Messages.Update(_mapper.Map<Message>(updateMessageDto));
            _context.SaveChanges();
            return Ok();
        }

        [HttpDelete]
        public IActionResult DeleteMessage(int id)
        {
            var value = _context.Messages.Find(id);
            _context.Messages.Remove(value);
            _context.SaveChanges();
            return Ok();
        }
    }
}
