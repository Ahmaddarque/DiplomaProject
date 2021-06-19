using Olympiads.BLL.DTO;
using Olympiads.BLL.Interfaces;
using Olympiads.DAL.EF;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Olympiads.BLL.Services
{
    public class StatsService : IStatsService
    {
        readonly OlympiadDb db = new OlympiadDb();
        public IEnumerable<TimedStatDTO> VisitSeries(DateTime start,DateTime end)
        {
            end = end.AddDays(1);
            var date = start;
            while (date.Date <= end.Date)
            {
                var visits = db.Visits.Count(x => DbFunctions.TruncateTime(x.VisitTime) == DbFunctions.TruncateTime(date));
                var stat = new TimedStatDTO() 
                { 
                    Count = visits,
                    Time = date
                };
                date = date.AddDays(1);
                yield return stat;
            }
            //var stats = db.Visits.Where(x => x.VisitTime >= start && end >= x.VisitTime)
            //                     .GroupBy(x => x.VisitTime)
            //                     .Select(x => new TimedStatDTO()
            //                     {
            //                         Count = x.Count(u => DbFunctions.TruncateTime(u.VisitTime) == DbFunctions.TruncateTime(x.Key)),
            //                         Time = x.Key
            //                     }).ToList();
            //return stats;
        }
        public IEnumerable<TimedStatDTO> RegistrationSeries(DateTime start, DateTime end)
        {
            end = end.AddDays(1);
            var date = start;
            while (date.Date <= end.Date)
            {
                var regs = db.Participants.Count(x => DbFunctions.TruncateTime(x.RegistrationTime) == DbFunctions.TruncateTime(date));
                var stat = new TimedStatDTO()
                {
                    Count = regs,
                    Time = date
                };
                date = date.AddDays(1);
                yield return stat;
            }
            //var stats = db.Participants.Where(x => x.RegistrationTime >= start && end >= x.RegistrationTime)
            //                     .GroupBy(x => x.RegistrationTime)
            //                     .Select(x => new TimedStatDTO()
            //                     {
            //                         Count = x.Count(u => DbFunctions.TruncateTime(u.RegistrationTime) == DbFunctions.TruncateTime(x.Key)),
            //                         Time = x.Key
            //                     }).ToList();
            //return stats;
        }
        public IEnumerable<TimedStatDTO> OlympiadPassSeries(DateTime start, DateTime end)
        {
            yield break;
        }
        public IEnumerable<TimedStatDTO> TestPassingsSeries(DateTime start, DateTime end)
        {
            yield break;
        }
        public int RegistrationsCount(DateTime time)
        {
            return db.Participants.Count(x => DbFunctions.DiffDays(x.RegistrationTime,time) <= 1);
        }
        public int VisitsCount(DateTime time)
        {
            return db.Visits.Where(x => DbFunctions.DiffDays(x.VisitTime, time) <= 1).Count();
        }
        public int OlympiadPassCount(DateTime time)
        {
            return db.OlympiadPassings.Count(x => DbFunctions.DiffDays(x.Time, time) == 0);
        }
        public int TestPassCount(DateTime time)
        {
            return db.TestPassings.Count(x => DbFunctions.DiffDays(x.Time, time) == 0);
        }
        public RatioStatDTO RegistrationToVisits(DateTime start, DateTime end)
        {
            return new RatioStatDTO()
            {
                First = db.Participants.Count(u => DbFunctions.TruncateTime(u.RegistrationTime) >= DbFunctions.TruncateTime(start)
                                                   && DbFunctions.TruncateTime(u.RegistrationTime) <= DbFunctions.TruncateTime(end)),
                Second = db.Visits.Count(u => DbFunctions.TruncateTime(u.VisitTime) >= DbFunctions.TruncateTime(start)
                                                   && DbFunctions.TruncateTime(u.VisitTime) <= DbFunctions.TruncateTime(end)),
            };
        }
        public RatioStatDTO OlympiadToTests(DateTime start, DateTime end)
        {
            return new RatioStatDTO()
            {
                First = db.OlympiadPassings.Count(u => DbFunctions.TruncateTime(u.Time) >= DbFunctions.TruncateTime(start)
                                                   && DbFunctions.TruncateTime(u.Time) <= DbFunctions.TruncateTime(end)),
                Second = db.TestPassings.Count(u => DbFunctions.TruncateTime(u.Time) >= DbFunctions.TruncateTime(start)
                                                   && DbFunctions.TruncateTime(u.Time) <= DbFunctions.TruncateTime(end)),
            };
        }
        
    }
}
