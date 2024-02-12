using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Agenda.Entities.Base;

namespace Agenda.Entities
{
    public class Client : BaseEntity
    {
        public string Name { get; private set; }
        public string Email { get; private set; }
    }
}
