using AutoMapper;
using Olympiads.BLL.BusinessModels;
using Olympiads.BLL.DTO;
using Olympiads.BLL.Infrastructure.Validation;
using Olympiads.BLL.Interfaces;
using Olympiads.DAL.Domain;
using Olympiads.DAL.EF;
using SimpleCrypto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Olympiads.BLL.Services
{
    public class CRUDParticipantService:ICRUDParticipantService
    {
        ICryptoService Crypto { get; set; }
        private readonly OlympiadDb db = new OlympiadDb();
        public IEnumerable<ParticipantDTO> SearchParticipants(string Search)
        {
            IEnumerable<ParticipantDTO> participants = new List<ParticipantDTO>();
            var mapper = new MapperConfiguration(x => x.CreateMap<Participant, ParticipantDTO>()).CreateMapper();
            if (int.TryParse(Search, out int id))
            {
                var participant = db.Participants.FirstOrDefault(x => x.Id == id);
                if (participant != null)
                    participants = new List<ParticipantDTO>() { (mapper.Map<Participant, ParticipantDTO>(participant)) };
            }
            else
            {
                participants = mapper.Map<IEnumerable<Participant>, IEnumerable<ParticipantDTO>>(db.Participants.Where(x => x.Surname.Contains(Search)).ToList());
            }

            return participants;
        }
        public ParticipantDTO GetParticipant(int ParticipantId)
        {
            var participant = db.Participants.FirstOrDefault(x => x.Id == ParticipantId);
            var mapper = new MapperConfiguration(x => x.CreateMap<Participant, ParticipantDTO>()
                                                       .ForMember(z => z.IsMale,i => i.MapFrom(u => u.Sex == Sex.Male))).CreateMapper();
            if (participant == null)
            {
                return null;
            }
            return mapper.Map<Participant, ParticipantDTO>(participant);

        }
        public void Unblock(int ParticipantId)
        {
            var participant = db.Participants.FirstOrDefault(x => x.Id == ParticipantId);
            if (participant != null)
            {
                participant.IsBlocked = false;
            }

            db.SaveChanges();
        }
        public void Block(int ParticipantId)
        {
            var participant = db.Participants.FirstOrDefault(x => x.Id == ParticipantId);
            if (participant != null)
            {
                participant.IsBlocked = true;
            }

            db.SaveChanges();
        }
        public IValidationResult EditParticipant(EditParticipantDTO edit)
        {
            IValidationResult validationResult = new ValidResult();
            var participant = db.Participants.FirstOrDefault(x => x.Id == edit.Id);
            if (participant != null)
            {
                if (db.Participants.Count(x => x.Email == edit.Email) > 1)
                {
                    validationResult = new FailedResult("Почта привязана к другому аккаунту","Email");
                }
                else
                {
                    participant.Surname = edit.Surname;
                    participant.Lastname = edit.Lastname;
                    participant.Name = edit.Name;
                    participant.Sex = edit.IsMale ? Sex.Male : Sex.Female;
                    participant.RegistrationTime = DateTime.Now;
                    participant.EducationalInstitution = edit.EducationalInstitution;
                    participant.Phone = edit.Phone;
                    participant.Email = edit.Email;
                    db.SaveChanges();
                }
            }
            else
            {
                validationResult = new FailedResult("Пользователь не найден");
            }

            return validationResult;
        }
        public IValidationResult AddParticipant(AddParticipantDTO add)
        {
            IValidationResult validationResult = new ValidResult();
            if (db.Participants.Count(x => x.Email == add.Email) > 0)
            {
                validationResult = new FailedResult("Email уже есть в системе","Email");
            }
            else
            {
                var mapper = new MapperConfiguration(x => x.CreateMap<AddParticipantDTO, Participant>()).CreateMapper();
                var newParticipant = mapper.Map<AddParticipantDTO, Participant>(add);
                newParticipant.PasswordSalt = Crypto.GenerateSalt();
                var password = new PasswordGenerator().Generate(8);
                newParticipant.Password = Crypto.Compute(password, newParticipant.PasswordSalt);
                newParticipant.Login = new LoginGenerator().Generate(newParticipant.Surname, newParticipant.Name, newParticipant.Lastname);
                newParticipant.RegistrationTime = DateTime.Now;

                db.Participants.Add(newParticipant);
                db.SaveChanges();
            }

            return validationResult;
        }

        public CRUDParticipantService(ICryptoService crypto)
        {
            Crypto = crypto;
        }
    }
}
