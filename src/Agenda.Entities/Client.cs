using Agenda.Entities.Base;

namespace Agenda.Entities
{
    public class Client : BaseEntity
    {
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string PhoneNumber { get; private set; }

        public Client()
        {
            
        }

        public Client(string phoneNumber) 
        {
            PhoneNumber = phoneNumber;
        }
    }
}
