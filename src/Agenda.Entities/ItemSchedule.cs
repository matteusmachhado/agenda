using Agenda.Shared.Enums;

namespace Agenda.Entities
{
    public class ItemSchedule
    {
        public Guid ScheduleId { get; private set; }
        public DateTime Date { get; set; }
        public StatusScheduleEnum Status { get; private set; }
    }
}
