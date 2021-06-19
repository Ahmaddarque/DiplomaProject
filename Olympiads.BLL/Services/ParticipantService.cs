using AutoMapper;
using Olympiads.BLL.BusinessModels;
using Olympiads.BLL.DTO;
using Olympiads.BLL.Email;
using Olympiads.BLL.Infrastructure.Validation;
using Olympiads.BLL.Interfaces;
using Olympiads.DAL.Domain;
using Olympiads.DAL.EF;
using SimpleCrypto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using TTask= System.Threading.Tasks.Task;

namespace Olympiads.BLL.Services
{
    public class ParticipantService : IParticipantService
    {
        ICryptoService Crypto { get; }
        public ParticipantService(ICryptoService crypto)
        {
            Crypto = crypto;
        }
        public ParticipantProfileDTO GetProfileInfo(int Id)
        {
            using (OlympiadDb context = new OlympiadDb())
            {
                var participant = context.Participants.First(x => x.Id == Id);
                var mapper = new MapperConfiguration(x => x.CreateMap<Participant, ParticipantProfileDTO>()).CreateMapper();
                return mapper.Map<Participant, ParticipantProfileDTO>(participant);
            }
        }

        public ParticipantLoggedDTO Login(AuthParticipantDTO participant)
        {
            ParticipantLoggedDTO logged = new ParticipantLoggedDTO() { Logged = false };
            OlympiadDb context = new OlympiadDb();
                var user = context.Participants.FirstOrDefault(x => x.Login == participant.Login && !x.IsBlocked);
                if (user != null)
                {
                    var userHash = user.Password;
                    var logHash = Crypto.Compute(participant.Password, user.PasswordSalt);

                    if (userHash == logHash)
                    {
                        context.ParticipantLogins.Add(new ParticipantLogin() { Participant = user, Time = DateTime.Now });
                        context.SaveChangesAsync();
                        logged = new ParticipantLoggedDTO() { Id = user.Id, Logged = true };
                    }
                }
            return logged;
        }   

        public IValidationResult Register(RegisterParticipantDTO participant)
        {
            IValidationResult validationResult = new ValidResult();

            using (OlympiadDb context = new OlympiadDb())
            {
                var loginAlreadyExists = context.Participants.Count(x => x.Login == participant.Login) > 0;
                if (loginAlreadyExists)
                {
                    validationResult = new FailedResult("Логин уже существует"); 
                }
                else
                {
                    var emailAlreadyExists = context.Participants.Count(x => x.Email == participant.Email) > 0;
                    if (emailAlreadyExists)
                    {
                        validationResult = new FailedResult("Email уже существует");
                    }
                    else
                    {
                        TTask.Run(() =>
                        {
                            using (OlympiadDb db = new OlympiadDb())
                            {
                                var salt = Crypto.GenerateSalt();
                                var password = Crypto.Compute(participant.Password, salt);
                                var mapper = new MapperConfiguration(x => x.CreateMap<RegisterParticipantDTO, Participant>()
                                                                           .ForMember(c => c.RegistrationTime, y => y.MapFrom(e => DateTime.Now))
                                                                           .ForMember(y => y.RegistrationIP, m => m.MapFrom(o => o.IP))
                                                                           .ForMember(t => t.Sex, u => u.MapFrom(o => o.Gender == true ? Sex.Male : Sex.Female))
                                                                           .ForMember(t => t.Password, v => v.MapFrom(o => password))
                                                                           .ForMember(t => t.PasswordSalt, y => y.MapFrom(o => salt)))
                                                                           .CreateMapper();

                                db.Participants.Add(mapper.Map<RegisterParticipantDTO, Participant>(participant));
                                db.SaveChanges();
                            }
                        });
                        
                    }
                }
            }

            return validationResult;
        }

        public bool BeginRestore(string email)
        {
            Participant participant = null;
            using (OlympiadDb context = new OlympiadDb())
            {
                participant = context.Participants.AsNoTracking().FirstOrDefault(x => x.Email == email);
            }
            bool restore = false;
            if (participant != null)
            {
                TTask.Run(() =>
                {
                    var code = new AlphaNumericCodeGenerator().Generate(25);
                    using (OlympiadDb context = new OlympiadDb())
                    {
                        context.EmailRestores.Add(new EmailRestore() { Code = code, Participant = participant, Time = DateTime.Now });
                        context.SaveChanges();
                    }

                    using (var agent = new EmailAgent())
                    {
                        var msg = new RestorePasswordMessage(code);
                        msg.To.Add(participant.Email);
                        agent.Send(msg);
                    }
                });
                    
                restore = true;
            }

            return restore;
            
        }

        public bool VerifyEmailCode(string code)
        {
            bool verify = false;
            using (OlympiadDb context = new OlympiadDb())
            {
                var latestRestore = context.EmailRestores.AsNoTracking().OrderByDescending(x => x.Time).FirstOrDefault(x => x.Code == code);
                if (latestRestore != null && (DateTime.Now - latestRestore.Time).Hours <= 24)
                    verify = true;
            }

            return verify;
        }

        public void SubmitRestore(string code,string newPassword)
        {
            using (OlympiadDb context = new OlympiadDb())
            {
                var latestRestore = context.EmailRestores.OrderByDescending(x => x.Time).FirstOrDefault(x => x.Code == code);
                var participant = latestRestore.Participant;
                participant.Password = Crypto.Compute(newPassword,participant.PasswordSalt);
                context.SaveChanges();   
            }
        }
    }
}
