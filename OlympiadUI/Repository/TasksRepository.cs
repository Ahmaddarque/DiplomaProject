using OlympiadUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OlympiadUI.Repository
{
    public static class TasksRepository
    {
        public static Task GetTaskFor(this IQueryable<Task> tasks,int TestId,int Number)
        {
            return tasks.Where(x => x.Number == Number && x.TestId == TestId).FirstOrDefault();
        }

        public static int GetCountOfTest(this IQueryable<Task> tasks,int TestId)
        {
            return tasks.Where(x => x.TestId == TestId).Count();
        }
    }
}