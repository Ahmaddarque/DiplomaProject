using OlympiadUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OlympiadUI.Repository
{
    public static class TestPassingsRepository
    {
        public static IQueryable<TestPassing> OrderByTime(this IQueryable<TestPassing> testPassings)
        {
            return testPassings.OrderBy(x => x.Time);
        }
        public static IQueryable<TestPassing> GetByVisiter(this IQueryable<TestPassing> testPassings,int VisiterId)
        {
            return testPassings.OrderByTime().Where(x => x.VisiterId == VisiterId);
        }

        public static IQueryable<TestPassing> FilterByStatus(this IQueryable<TestPassing> testPassings,TestStatus status)
        {
            return testPassings.Where(x => x.Status == status);
        }

        public static TestPassing GetCurrentPassing(this IQueryable<TestPassing> testPassings,int VisiterId)
        {
            return testPassings.GetByVisiter(VisiterId).FilterByStatus(TestStatus.Started).FirstOrDefault();
        }

        public static bool IsPassingATest(this IQueryable<TestPassing> testPassings,int VisiterId)
        {
            return testPassings.GetByVisiter(VisiterId).FilterByStatus(TestStatus.Started).Count() > 0;
        }
    }
}