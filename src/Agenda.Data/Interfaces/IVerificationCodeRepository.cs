using Agenda.Data.Migrations.Auth;
using Agenda.Entities;

namespace Agenda.Data.Interfaces
{
    public interface IVerificationCodeRepository
    {
        void Add(VerificationCode entity);
        Task<VerificationCode> FindCodeUnchecked(string code);
    }
}
