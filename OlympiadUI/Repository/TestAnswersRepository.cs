using OlympiadUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OlympiadUI.Repository
{
    public static class TestAnswersRepository
    {
        public static bool ExistsWithPassingId(this IQueryable<TaskAnswer> taskAnswers, int PassingId) =>
                taskAnswers.Where(x => x.TestPassingId == PassingId).Count() > 0;

        public static IQueryable<TaskAnswer> OrderById(this IQueryable<TaskAnswer> taskAnswers) =>
            taskAnswers.OrderByDescending(x => x.Id);

        public static TaskAnswer GetByPassingId(this IQueryable<TaskAnswer> taskAnswers,int PassingId)
        {
            return taskAnswers.Where(x => x.TestPassingId == PassingId).OrderById().FirstOrDefault();
        }

        public static Task GetLastTask(this IQueryable<TaskAnswer> taskAnswers, int PassingId)
        {
            Task lastTask = null;
            if (taskAnswers.ExistsWithPassingId(PassingId))
            {
                lastTask = taskAnswers.GetByPassingId(PassingId).Task;
            }

            return lastTask;
        }

        //public static HasPassedByVisiter()
        //{

        //}

       
    }
}