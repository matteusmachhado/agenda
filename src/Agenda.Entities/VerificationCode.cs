using Agenda.Shared.Enums;

namespace Agenda.Entities
{
    public class VerificationCode
    {
        public Guid Id { get; private set; }
        public DateTime CreateDate { get; private set; }
        public TypeOfCheckEnum TypeCheck { get; private set; }
        public string? PhoneNumber { get; private set; }
        public string? Email { get; private set; }
        public string Code { get; private set; }
        public DateTime? DateCheck { get; private set; }

        public VerificationCode()
        {
            
        }

        public VerificationCode(TypeOfCheckEnum typeOfCheck, string code)
        {
            Id = Guid.NewGuid();
            TypeCheck = typeOfCheck;
            Code = code;
            CreateDate = DateTime.Now;
        }

        public static VerificationCode FromPhoneNumber(string phoneNumber, string code) 
        {
            var entity = new VerificationCode(TypeOfCheckEnum.SMS, code);
            entity.PhoneNumber = phoneNumber;

            return entity;
        }

        public static VerificationCode FromEmail(string email, string code)
        {
            var entity = new VerificationCode(TypeOfCheckEnum.Email, code);
            entity.Email = email;

            return entity;
        }

        public void Checked() => DateCheck = DateTime.Now;
        
    }
}
