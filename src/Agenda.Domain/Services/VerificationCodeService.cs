using Agenda.Data.Interfaces;
using Agenda.Domain.Interfaces;
using Agenda.Shared.Enums;
using Agenda.Shared.Utils;

namespace Agenda.Domain.Services
{
    public class VerificationCodeService : BaseService, IVerificationCodeService
    {
        private readonly IVerificationCodeRepository _verificationCodeRepository;

        public VerificationCodeService(INotificationService notificador,
            IUnitOfWork unitOfWork,
            IVerificationCodeRepository verificationCodeRepository) : base(notificador, unitOfWork)
        {
            _verificationCodeRepository = verificationCodeRepository;
        }

        public async Task<string> CreateVerificationCodeSMS(string phoneNumber, TypeOfVerificarionCodeEnum typeOfVerificarionCode)
        {
            var code = GenerateCode(typeOfVerificarionCode, 5);

            var entity = Entities.VerificationCode.FromPhoneNumber(phoneNumber, code);

            _verificationCodeRepository.Add(entity);

            await Commit();

            return code;
        }

        public async Task<string> CreateVerificationCodeEmail(string email, TypeOfVerificarionCodeEnum typeOfVerificarionCode)
        {
            var code = GenerateCode(typeOfVerificarionCode, 5);

            var entity = Entities.VerificationCode.FromEmail(email, code);

            _verificationCodeRepository.Add(entity);

            await Commit();

            return code;
        }

        private string GenerateCode(TypeOfVerificarionCodeEnum type, int length) => type switch
        {
            TypeOfVerificarionCodeEnum.Numeric => RandomUtil.Numeric(length),
            TypeOfVerificarionCodeEnum.AlphaNumeric => RandomUtil.AlphaNumeric(length),
            _ => throw new NotImplementedException()
        };
    }
}
