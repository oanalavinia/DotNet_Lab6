using System;

namespace DataLayer
{
    public class City
    {
        private Guid guid;

        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }

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
    }
}
