using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/city")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public CityController(ApplicationContext context)
        {
            _context = context;

            if (_context.Cities.Any()) return;
            // Create a new CityItem if collection is empty,
            // which means you can't delete all TodoItems.
            _context.Cities.Add(new City("Item1", "Bone" ));
            _context.SaveChanges();
        }

        [HttpGet]
        public ActionResult<List<City>> GetAll()
        {
            return _context.Cities.ToList();
        }

        [HttpGet("{id}", Name = "GetCity")]
        public ActionResult<City> GetById(long id)
        {
            var city = _context.Cities.Find(id);
            if (city == null)
            {
                return NotFound();
            }
            return city;
        }

        [HttpPost]
        public IActionResult Create(City city)
        {
            _context.Cities.Add(city);
            _context.SaveChanges();

            return CreatedAtRoute("GetCity", new City(city));
        }
        
    }
}