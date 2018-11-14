﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer
{
    class Poi
    {

        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }

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
    }
}
