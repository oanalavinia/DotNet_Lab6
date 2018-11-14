using System;
using System.Collections.Generic;

namespace DataLayer
{
    public class City
    {
        private City city;

        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public virtual ICollection<Poi> Pois { get; private set; }

        public City()
        {
            //EF Needs This
        }

        public City(string name, string description)
        {
            Id = Guid.NewGuid();
            Name = name;
            Description = description;
        }

        public City(City city)
        {
            this.city = city;
        }
    }
}
