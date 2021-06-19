using AutoMapper;
using Olympiads.BLL.DTO;
using Olympiads.BLL.Interfaces;
using Olympiads.WEB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Olympiads.WEB.Controllers
{
    public class TasksController : Controller
    {
        private readonly ITaskService taskService;

        // GET: Tasks
        public ActionResult Index(int Id)
        {
            return View(Id);
        }
        public PartialViewResult GetTasks(int ActivityId)
        {
            var tasks = taskService.GetTasks(ActivityId);
            if (tasks.Any())
            {
                var mapper = new MapperConfiguration(x => x.CreateMap<TaskInfoDTO, TaskViewModel>()
                                                            .ForMember(r => r.ShortContent, i => i.MapFrom(o => o.Content.Length > 30 ? string.Join(o.Content.Take(30).ToString(), "...") : o.Content))).CreateMapper();
                var tasksVm = mapper.Map<IEnumerable<TaskInfoDTO>,IEnumerable<TaskViewModel>>(tasks);
                return PartialView("TasksPartial",tasksVm);
            }
            else
            {
                return PartialView("ResultNotFoundPartial");
            }
        }
        public PartialViewResult GetTask(int ActivityId,int TaskNumber)
        {
            var task = taskService.GetTask(ActivityId, TaskNumber);
            if (task != null)
            {
                var mapper = new MapperConfiguration(r => r.CreateMap<TaskDTO, EditTask>()).CreateMapper();
                var taskVm = mapper.Map<TaskDTO, EditTask>(task);
                taskVm.IsEdit = true;
                return PartialView("AddEditPartial", taskVm);
            }
            else
            {
                return PartialView("ResultNotFoundPartial");
            }
        }

        public PartialViewResult Add()
        {
            return PartialView("AddEditPartial",new EditTask());
        }
        public void Delete(int ActivityId, int TaskNumber)
        {
            taskService.DeleteTask(ActivityId,TaskNumber);
        }

        public JsonResult Save(EditTask edit)
        {
            IEnumerable<ErrorInfo> errors = Enumerable.Empty<ErrorInfo>();
            return Json(errors);
        }

        public TasksController(ITaskService taskService)
        {
            this.taskService = taskService;
        }
    }
}