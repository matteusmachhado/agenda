using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda.Domain.Entities
{
    public class Company : BaseEntity
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public ICollection<Service> Services { get; private set; }

        public Company(string name, string description) 
        {
            Name = name;
            Description = description;
            Services = new List<Service>();
        }

        protected Company() { }

        public void AddService(Service service) 
        {
            Services.Add(service);
        }

        public void RemoveService(Service service) 
        {
            Services.Remove(service);
        }
    }
}
