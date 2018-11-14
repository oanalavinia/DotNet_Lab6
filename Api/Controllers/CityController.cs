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
    [Route("api/city")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly CitiesRepository _cities;

        public CityController(CitiesRepository cities)
        {
            _cities = cities;

            // Create a new CityItem if collection is empty,
            // which means you can't delete all TodoItems.
            _cities.Add(new City("Item1", "Bone" ));
        }

        [HttpGet]
        public ActionResult<IReadOnlyCollection<City>> GetAll()
        {
            return Ok(_cities.GetAll());
        }

        [HttpGet("{id}", Name = "GetCity")]
        public ActionResult<City> GetById(Guid id)
        {
            var city = _cities.GetById(id);
            if (city == null)
            {
                return NotFound();
            }
            return Ok(city);
        }

        [HttpPost]
        public IActionResult Create(City city)
        {
            _cities.Add(city);

            return CreatedAtRoute("GetCity", new City(city));
        }
        
    }
}