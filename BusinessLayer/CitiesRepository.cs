using System;
using System.Collections.Generic;
using System.Linq;
using DataLayer;

namespace BusinessLayer
{
    public class CitiesRepository : ICitiesRepository
    {
        private readonly CitiesContext context;

        public CitiesRepository(CitiesContext receivedContext)
        {
            context = receivedContext;
        }

        public void Add(City city)
        {
            context.Cities.Add(city);
            context.SaveChanges();
        }

        public void Delete(City city)
        {
            context.Cities.Remove(city);
            context.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var city = GetById(id);
            context.Cities.Remove(city);
            context.SaveChanges();
        }

        public void Edit(City city)
        {
            context.Cities.Update(city);
            context.SaveChanges();
        }

        public IReadOnlyCollection<City> GetAll()
        {
            return context.Cities.ToList();
        }

        public City GetById(Guid id)
        {
            return context.Cities.FirstOrDefault(c => c.Id == id);
        }
    }
}
