
namespace Agenda.Domain.Entities
{
    public class Employee : BaseEntity
    {
        public string Name { get; private set; }
        public TimeOnly StartWork { get; private set; }
        public TimeOnly StopWork { get; private set; }
        public TimeOnly RestartWork { get; private set; }
        public TimeOnly EndWork { get; private set; }
        public ICollection<Service> Services { get; private set; }

        public Employee(string name, TimeOnly startWork, TimeOnly stopWork, TimeOnly restartWork, TimeOnly endWork)
        {
            Name = name;    
            StartWork = startWork;
            StopWork = stopWork;
            RestartWork = restartWork;
            EndWork = endWork;  
        }

        protected Employee() { }
    }
}
