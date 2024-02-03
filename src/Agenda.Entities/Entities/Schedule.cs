using Agenda.Entities.Entities.Base;
using Agenda.Entities.Enums;

namespace Agenda.Entities.Entities
{
    public class Schedule : BaseEntity
    {
        public Service Service { get; private set; }
        public Guid ServiceId { get; private set; }
        public Employee Employee { get; private set; }
        public Guid EmployeeId { get; private set; }
        public AvailabilityType AvailabilityType { get; private set; } = AvailabilityType.WeekdaysAndSaturday;
        public ICollection<ItemSchedule> Schedules { get; private set; }

        public Schedule(Service service, Employee employee)
        {
            Service = service;
            Employee = employee;
        }

        protected Schedule() { }

        public IList<ItemSchedule> GetSchedules()
        {
            var items = new List<ItemSchedule>();

            var totalFirstPeriod = GetTotalInMinutesFirstPeriod();
            var totalLastPeriod = GetTotalInMinutesLastPeriod();
            var totalAvailability = totalFirstPeriod + totalLastPeriod;

            var totalAvailabilityByDay = totalAvailability / Service.Duration.Minute;

            foreach (var index in Enumerable.Range(1, totalAvailabilityByDay)) 
            {
                
            }

            return items;
        }

        private int GetTotalInMinutesFirstPeriod()
        {
            var time = Employee.StartWork < Employee.StopWork ? Employee.StopWork - Employee.StartWork : Employee.StartWork - Employee.StopWork;

            return time.Minutes;
        }

        private int GetTotalInMinutesLastPeriod()
        {
            var time = Employee.RestartWork < Employee.EndWork ? Employee.EndWork - Employee.RestartWork : Employee.RestartWork - Employee.EndWork;

            return time.Minutes;
        }
    }
}
