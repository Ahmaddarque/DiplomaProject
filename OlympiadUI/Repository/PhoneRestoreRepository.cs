using OlympiadUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OlympiadUI.Repository
{
    public static class PhoneRestoreRepository
    {
        public static IQueryable<PhoneRestore> OrderByDate(this IQueryable<PhoneRestore> phoneRestores)
        {
            return phoneRestores.OrderBy(x => x.Time);
        }
        public static bool HasNearestRestoreFor(this IQueryable<PhoneRestore> phoneRestores, Participant participant)
        {
            bool has = false;
            var phoneRestore = phoneRestores.OrderByDate().Where(x => x.ParticipantId == participant.Id).Select(u => u.Time).FirstOrDefault();
            if ((phoneRestore - DateTime.Now).Minutes <= 2)
                has = true;

            return has;
            
        }
        public static PhoneRestore GetNearestRestoreFor(this IQueryable<PhoneRestore> phoneRestores,Participant participant)
        {
            PhoneRestore restore = null;
            if (phoneRestores.HasNearestRestoreFor(participant))
                restore = phoneRestores.OrderByDate().FirstOrDefault(x => x.ParticipantId == participant.Id);

            return restore;
        }
    }
}