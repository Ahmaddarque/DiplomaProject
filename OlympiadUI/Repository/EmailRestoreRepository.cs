using OlympiadUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OlympiadUI.Repository
{
    public static class EmailRestoreRepository
    {
        public static IQueryable<EmailRestore> OrderByTime(this IQueryable<EmailRestore> emailRestores)
        {
           return  emailRestores.OrderBy(x => x.Time);
        }
        public static bool ExistsFor(this IQueryable<EmailRestore> emailRestores,Participant participant)
        {
            return emailRestores.OrderByTime().Where(x => x.ParticipantId == participant.Id).Count() > 0;
        }

        public static bool ExistsWithCode(this IQueryable<EmailRestore> emailRestores,string code)
        {
            bool exists = false;
            var latestRestoreTime = emailRestores.OrderByTime().Where(x => x.Code == code).Select(u => u.Time).FirstOrDefault();
            if ((DateTime.Now - latestRestoreTime).Days <= 1)
                exists = true;

            return exists;
        }

        public static EmailRestore GetWithCode(this IQueryable<EmailRestore> emailRestores, string code)
        {
            EmailRestore restore = null;
            if (emailRestores.ExistsWithCode(code))
            {
                restore = emailRestores.OrderByTime().Where(x => x.Code == code).FirstOrDefault();
            }
            return restore;
        }
    }
}