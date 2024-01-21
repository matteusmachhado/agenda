using Agenda.Domain.Enums;

namespace Agenda.Domain.Entities
{
    public class ItemSchedule
    {
        public Guid ScheduleId { get; private set; }
        public DateTime Date { get; set; }
        public StatusSchedule Status { get; private set; }
    }
}
