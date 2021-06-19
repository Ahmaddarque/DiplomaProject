using AutoMapper;
using OlympiadUI.Models;
using OlympiadUI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OlympiadUI.Controllers
{
    public class TasksController : Controller
    {
        private ActionResult GetTaskDetails(Task task)
        {
            if (task != null)
            {
                using (OlympiadDb context = new OlympiadDb())
                {
                    ActionResult TaskDetails = HttpNotFound();

                    var optionTask = context.OptionsTasks.FirstOrDefault(x => x.Id == task.Id);
                    if (optionTask != null)
                    {
                        IEnumerable<OptionsTaskOption> options = context.OptionsTaskOptions.Where(x => x.OptionsTaskId == optionTask.Id).ToList();
                        TaskDetails = PartialView("OptionTaskPartial", options);
                    }
                    else
                    {
                        var inputTask = context.InputTasks.FirstOrDefault(x => x.Id == task.Id);
                        if (inputTask != null)
                        {
                            TaskDetails = PartialView("InputTaskPartial", inputTask);
                        }
                    }

                    return TaskDetails;
                }
                
            }

            throw new ArgumentNullException();
        }
        public ActionResult GetTestTaskDetails(int TestId,int Number)
        {
            using (OlympiadDb context = new OlympiadDb())
            {
                var task = context.Tasks.FirstOrDefault(x => x.TestId == TestId && x.Number == Number);
                return GetTaskDetails(task);
            }
        }
        public ActionResult GetTestTask(int TestId,int Number)
        {
            using (OlympiadDb context = new OlympiadDb())
            {
                var task = context.Tasks.FirstOrDefault(x => x.TestId == TestId && x.Number == Number);
                var config = new MapperConfiguration(x => x.CreateMap<Task, TaskInfo>().ForMember(x => x.TestName, x => x.MapFrom(x => x.Test.Name)));
                var taskVm = new Mapper(config).Map<Task, TaskInfo>(task);
                taskVm.Total = context.Tasks.Where(x => x.TestId == task.TestId).Count();
                return PartialView("TaskPartial",taskVm);
            }
        }
    }
}