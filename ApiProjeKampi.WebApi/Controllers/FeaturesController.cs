using ApiProjeKampi.WebApi.Contexts;
using ApiProjeKampi.WebApi.Dtos.FeatureDtos;
using ApiProjeKampi.WebApi.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiProjeKampi.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeaturesController : ControllerBase
    {
        private readonly ApiContext _context;
        private readonly IMapper _mapper;

        public FeaturesController(ApiContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetFeatures() 
        { 
            var values = _context.Features.ToList();
            return Ok(_mapper.Map<List<ResultFeatureDto>>(values));
        }

        [HttpGet("GetFeature")]
        public IActionResult GetFeature(int id)
        {
            var value = _context.Features.Find(id);
            return Ok(_mapper.Map<GetByIdFeatureDto>(value));
        }

        [HttpPost]
        public IActionResult CreateFeature(CreateFeatureDto createFeatureDto)
        {
            _context.Features.Add(_mapper.Map<Feature>(createFeatureDto));
            _context.SaveChanges();
            return StatusCode(201);
        }

        [HttpPut]
        public IActionResult UpdateFeature(UpdateFeatureDto updateFeatureDto)
        {
            _context.Features.Update(_mapper.Map<Feature>(updateFeatureDto));
            _context.SaveChanges();
            return Ok();
        }

        [HttpDelete]
        public IActionResult DeleteFeature(int id)
        {
            _context.Features.Remove(_context.Features.Find(id));
            _context.SaveChanges();
            return Ok();
        }
    }
}
