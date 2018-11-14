using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer
{
    public class Poi
    {

        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }

        public Guid CityId { get; private set; }
        public virtual City City { get; private set; }

        public Poi()
        {
            //EF Needs This
        }

        public Poi(string name, string description)
        {
            Id = Guid.NewGuid();
            Name = name;
            Description = description;
        }

        public void SetName(string _name)
        {
            Name = _name;
        }

        public void SetDescription(string description)
        {
            Description = description;
        }

        public void SetCityId(Guid cityId)
        {
            CityId = cityId;
        }
        public void SetCity(City city)
        {
            City = city;
        }
    }
}
