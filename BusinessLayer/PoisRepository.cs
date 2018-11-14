using System;
using System.Collections.Generic;
using System.Linq;
using DataLayer;

namespace BusinessLayer
{
    public class PoisRepository : IPoisRepository
    {
        private readonly ApplicationContext context;

        public PoisRepository(ApplicationContext receivedContext)
        {
            context = receivedContext;
        }

        public void Add(Poi poi)
        {
            context.Pois.Add(poi);
            context.SaveChanges();
        }

        public void Delete(Poi poi)
        {
            context.Pois.Remove(poi);
            context.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var city = GetById(id);
            context.Pois.Remove(city);
            context.SaveChanges();
        }

        public void Edit(Poi poi)
        {
            context.Pois.Update(poi);
            context.SaveChanges();
        }

        public IReadOnlyCollection<Poi> GetAll()
        {
            return context.Pois.ToList();
        }

        public Poi GetById(Guid id)
        {
            return context.Pois.FirstOrDefault(p => p.Id == id);
        }
    }
}
