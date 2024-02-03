using Agenda.Entities.Enums;

namespace Agenda.Entities.Entities
{
    public class ItemSchedule
    {
        public Guid ScheduleId { get; private set; }
        public DateTime Date { get; set; }
        public StatusSchedule Status { get; private set; }
    }
}
