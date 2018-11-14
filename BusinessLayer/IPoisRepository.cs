using System;
using System.Collections.Generic;
using DataLayer;

namespace BusinessLayer
{
    public interface IPoisRepository
    {
        void Add(Poi city);
        void Delete(Poi city);
        void Delete(Guid id);
        void Edit(Poi city);
        Poi GetById(Guid id);
        IReadOnlyCollection<Poi> GetAll();
    }
}
