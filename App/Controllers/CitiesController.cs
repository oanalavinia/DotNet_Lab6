using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.ViewModel;
using BusinessLayer;
using DataLayer;
using Microsoft.AspNetCore.Mvc;

namespace App.Controllers
{
    public class CitiesController : Controller
    {
        private readonly ICitiesRepository repository;

        public CitiesController(ICitiesRepository sentContext)
        {
            repository = sentContext;
        }

        public IActionResult Index()
        {
            var cities = repository.GetAll();
            var vms = new List<CityViewModel>();
            foreach (var city in cities)
            {
                vms.Add(new CityViewModel {Name = city.Name, Description = city.Description});
            }
            return View(vms);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create([Bind("Name, Description")] CityViewModel model)
        {
            if (ModelState.IsValid)
            {
                var city = new City(model.Name, model.Description);
                repository.Add(city);
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var city = repository.GetById(id);
            if (city == null)
            {
                return NotFound();
            }
            repository.Delete(city);
            return RedirectToAction(nameof(Index));
        }
    }
}