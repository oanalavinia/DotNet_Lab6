using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer;
using DataLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace Api.Controllers
{
    [Route("api/cities/{CityId}/[controller]")]
    [ApiController]
    public class PoisController : ControllerBase
    {
        private PoisRepository repository;
        private CitiesRepository citiesRepository;
        public PoisController(PoisRepository _repository, CitiesRepository _citiesRepository)
        {
            repository = _repository;
            citiesRepository = _citiesRepository;
        }
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<Poi>> Get()
        {
            return Ok(repository.GetAll());
        }

        // GET api/values/5
        [HttpGet("{id}", Name = "GetById")]
        public ActionResult<string> Get(Guid id)
        {
           
            var poi = repository.GetById(id);
            if (poi != null)
            {
                var city = citiesRepository.GetById(poi.CityId);
                if (city != null) return Ok(poi);
                            else return NotFound();
            }
            else
                return NotFound();
        
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post(Poi poi)
        {

            var city = citiesRepository.GetById(poi.CityId);
            if (city != null)
            {
                repository.Add(poi);
                return CreatedAtRoute("GetById", new { id = poi.Id }, poi);
            }
            else return BadRequest();
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(Poi poi)
        {
            var _poi = repository.GetById(poi.Id);
            if (_poi == null)
            {
                return NotFound();
            }

            _poi.SetName(poi.Name);
            _poi.SetDescription(poi.Description);
            _poi.SetCityId (poi.CityId);
            _poi.SetCity (poi.City);

            repository.Edit(_poi);
            return NoContent();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var poi = repository.GetById(id);
            if (poi == null)
            {
                return NotFound();
            }

            repository.Delete(poi);
            return NoContent();
        }
    }
}