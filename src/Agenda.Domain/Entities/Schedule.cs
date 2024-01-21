
namespace Agenda.Domain.Entities
{
    public class Schedule : Entity
    {
        public Service Service { get; private set; }
        public Guid ServiceId { get; private set; }
        public Employee Employee { get; private set; }
        public Guid EmployeeId { get; private set; }

        public Schedule(Service service, Employee employee)
        {
            Service = service;
            Employee = employee;
        }

        protected Schedule() { }
    }
}
