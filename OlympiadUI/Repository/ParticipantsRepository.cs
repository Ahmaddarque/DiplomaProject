using OlympiadUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OlympiadUI.Repository
{
    public static class ParticipantsRepository
    {
        public static Participant GetByCredentials(this IQueryable<Participant> participants,string login,string pass)
        {
            return participants.FirstOrDefault(x => x.Login == login && x.Password == pass);
        }

        public static bool ExistsWithEmail(this IQueryable<Participant> participants, string email) =>
            participants.Where(x => x.Email == email).Count() > 0;
        public static Participant GetByEmail(this IQueryable<Participant> participants, string email)
        {
            return participants.FirstOrDefault(x => x.Email == email);
        }

        public static Participant GetByPhone(this IQueryable<Participant> participants, string phone)
        {
            return participants.FirstOrDefault(x => x.Phone == phone);
        }

        public static bool ExistsWithPhone(this IQueryable<Participant> participants,string phone)
        {
            bool exists = false;
            if (participants.FirstOrDefault(x => x.Phone == phone) != null)
            {
                exists = true;
            }

            return exists;
        }

        public static Participant GetById(this IQueryable<Participant> participants,int Id)
        {
            return participants.FirstOrDefault(x => x.Id == Id);
        }
        
        public static bool ExistsWithId(this IQueryable<Participant> participants,int Id)
        {
            return participants.Where(x => x.Id == Id).Count() > 0;
        }
    }
}