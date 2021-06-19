using Olympiads.BLL.DTO;
using Olympiads.BLL.Infrastructure.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Olympiads.BLL.Interfaces
{
    public interface IParticipantService
    {
        IValidationResult Register(RegisterParticipantDTO participant);
        ParticipantLoggedDTO Login(AuthParticipantDTO participant);
        ParticipantProfileDTO GetProfileInfo(int Id);
        bool BeginRestore(string email);
        bool VerifyEmailCode(string code);
        void SubmitRestore(string code, string newPassword);
    }
}
