using Olympiads.BLL.DTO;
using Olympiads.BLL.Infrastructure.Validation;
using Olympiads.BLL.Interfaces;
using Olympiads.DAL.Domain;
using Olympiads.DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Olympiads.BLL.Services
{
    public class TaskService : ITaskService
    {
        readonly OlympiadDb db = new OlympiadDb();
        public IEnumerable<TaskInfoDTO> GetTasks(int ActivityId)
        {
            var tasks = db.Tasks.Where(x => x.ActivityId == ActivityId)
                                      .Select(x => new TaskInfoDTO
                                      { 
                                        Number = x.Number,
                                        Content = x.Content
                                      }).ToList();

            return tasks;
        }
        public TaskDTO GetTask(int ActivityId,int Number)
        {
            var task = db.Tasks.Where(x => x.ActivityId == ActivityId && x.Number == Number)
                    .Select(x => new TaskDTO() 
                    { 
                        Content = x.Content,
                        Image = x.Image,
                        Number = x.Number,
                        Options = x.Options.Select(u => new TaskOptionDTO 
                        { 
                            Option = u.Option,
                            IsCorrect = u.IsCorrect
                        })
                    }).FirstOrDefault();

            return task;
        }
        public IValidationResult SaveTask(SaveTaskDTO task)
        {
            var domainTask = db.Tasks.FirstOrDefault(x => x.Number == task.Number && x.ActivityId == task.ActivityId);
            if (domainTask == null)
            {
                if (db.Tasks.Any(x => x.ActivityId == task.ActivityId))
                {
                    var nextNumber = db.Tasks.Where(x => x.ActivityId == task.ActivityId).Max(u => u.Number) + 1;
                    domainTask = new DAL.Domain.Task() { Number = nextNumber, ActivityId = task.ActivityId };
                }
                else
                {
                    return new FailedResult();
                }
            }
            domainTask.Options.Clear();
            domainTask.Image = task.Image;
            foreach (var option in task.Options)
            {
                domainTask.Options.Add(new TaskOption() { Option = option.Option, IsCorrect = option.IsCorrect });
            }

            db.SaveChanges();
            return new ValidResult();
        }
        public IValidationResult DeleteTask(int ActivityId, int Number)
        {
            IValidationResult result = new ValidResult();
            var task = db.Tasks.FirstOrDefault(x => x.ActivityId == ActivityId && x.Number == Number);
            if (task == null)
            {
                result = new FailedResult("Задание не найдено");
            }
            else
            {
                if (db.TaskAnswers.Any(x => x.TaskId == task.Id))
                {
                    result = new FailedResult("Есть решённые задания");
                }
                else
                {
                    db.Tasks.Remove(task);
                    task.Options?.Clear();
                    db.SaveChanges();
                }
            }

            return result;
        }
    }
}
