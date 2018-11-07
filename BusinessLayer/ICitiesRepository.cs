using DataLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer
{
    public interface ICitiesRepository
    {
        void Add(City city);
        void Delete(City city);
        void Delete(Guid id);
        void Edit(City city);
        City GetById(Guid id);
        IReadOnlyCollection<City> GetAll();
    }
}
