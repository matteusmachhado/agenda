using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda.Domain.Entities
{
    public class Employee : Entity
    {
        public string Name { get; private set; }
        public ICollection<Service> Services { get; private set; }

        public Employee(string name)
        {
            Name = name;    
        }

        protected Employee() { }
    }
}
