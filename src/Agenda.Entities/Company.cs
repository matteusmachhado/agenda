﻿using System;
using Agenda.Entities.Base;

namespace Agenda.Entities
{
    public class Company : BaseEntity
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        //public ICollection<Service> Services { get; private set; }

        public Company() { }

        public Company(string name, string description)
        {
            Name = name;
            Description = description;
            //Services = new List<Service>();
        }



        //public void AddService(Service service) 
        //{
        //    Services.Add(service);
        //}

        //public void RemoveService(Service service) 
        //{
        //    Services.Remove(service);
        //}
    }
}
