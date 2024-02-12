using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Agenda.Entities.Base;

namespace Agenda.Entities
{
    public class Product : BaseEntity
    {
        public string Name { get; private set; }
        public string Description { get; private set; }

        public Product(string name, string description)
        {
            Name = name;
            Description = description;
        }

        protected Product() { }
    }
}
