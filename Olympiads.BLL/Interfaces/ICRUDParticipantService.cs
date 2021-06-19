using Olympiads.BLL.DTO;
using Olympiads.BLL.Infrastructure.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Olympiads.BLL.Interfaces
{
    public interface ICRUDParticipantService
    {
        IEnumerable<ParticipantDTO> SearchParticipants(string Search);
        ParticipantDTO GetParticipant(int ParticipantId);
        void Unblock(int ParticipantId);
        void Block(int ParticipantId);
        IValidationResult EditParticipant(EditParticipantDTO edit);
        IValidationResult AddParticipant(AddParticipantDTO add);
    }
}
