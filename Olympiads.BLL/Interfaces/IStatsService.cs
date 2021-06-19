using Olympiads.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Olympiads.BLL.Interfaces
{
    public interface IStatsService
    {
        RatioStatDTO OlympiadToTests(DateTime start, DateTime end);
        RatioStatDTO RegistrationToVisits(DateTime start, DateTime end);
        int TestPassCount(DateTime time);
        int OlympiadPassCount(DateTime time);
        int VisitsCount(DateTime time);
        int RegistrationsCount(DateTime time);
        IEnumerable<TimedStatDTO> TestPassingsSeries(DateTime start, DateTime end);
        IEnumerable<TimedStatDTO> OlympiadPassSeries(DateTime start, DateTime end);
        IEnumerable<TimedStatDTO> RegistrationSeries(DateTime start, DateTime end);
        IEnumerable<TimedStatDTO> VisitSeries(DateTime start, DateTime end);
    }
}
