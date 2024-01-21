using Agenda.Domain.Enums;

namespace Agenda.Domain.Entities
{
    public class Availability : Entity
    {
        public AvailabilityType AvailabilityType { get; private set; } = AvailabilityType.WeekdaysAndSaturday;

        public Availability(AvailabilityType availabilityType)
        {
            AvailabilityType = availabilityType;
        }
    }
}
