using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda.Domain.Entities
{
    public class Service : Entity
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public TimeOnly Duration { get; private set; }
        public ICollection<Product> Products { get; private set; }
        public ICollection<Employee> Employees { get; private set; }

        public Service(string name, string description, TimeOnly duration)
        {
            Name = name;
            Description = description;
            Duration = duration;
            Products = new List<Product>();
            Employees = new List<Employee>();
        }

        protected Service() { }

        public void AddProduct(Product product) 
        {
            Products.Add(product);
        }

        public void RemoveProduct(Product product)
        {
            Products.Remove(product);
        }

        public void AddProduct(Employee employee)
        {
            Employees.Add(employee);
        }

        public void RemoveProduct(Employee employee)
        {
            Employees.Remove(employee);
        }
    }
}
