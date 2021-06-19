using AutoMapper;
using Olympiads.BLL.DTO;
using Olympiads.DAL.Domain;
using Olympiads.DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Olympiads.BLL.Services
{
    //public class TestTaskService
    //{
    //    protected readonly OlympiadDb context = new OlympiadDb();
    //    public int UserId { get; }
    //    public TestTaskInfoDTO GetTask(int Number)
    //    {
    //        var passing = context.TestPassings.OrderByDescending(x => x.Time).FirstOrDefault(y => y.UserId == UserId && y.Status == ActivityStatus.Started);
    //        if (passing == null)
    //            throw new ArgumentException();
    //        else
    //        {
    //            var task = context.Tasks.FirstOrDefault(x => x.ActivityId == passing.TestId && x.Number == Number);
    //            if (task == null)
    //            {
    //                throw new ArgumentException();
    //            }
    //            var mapper = new MapperConfiguration(c => c.CreateMap<Task, TestTaskInfoDTO>()).CreateMapper();
    //            var taskDTO = mapper.Map<Task, TestTaskInfoDTO>(task);
    //            taskDTO.IsLast = true;
    //            if (context.Tasks.Any(x => x.ActivityId == task.ActivityId && x.Number == task.Number + 1))
    //            {
    //                taskDTO.IsLast = false;
    //            }
    //            taskDTO.Total = context.Tasks.Count(x => x.ActivityId == task.ActivityId);
    //            taskDTO.Options = task.Options.Select(x => x.Option);
    //            return taskDTO;
    //        }
    //    }
    //    public void StartTest(int TestId)
    //    {
    //        var uncompleted = context.TestPassings.FirstOrDefault(x => x.Status == ActivityStatus.Started && x.UserId == UserId);
    //        if (!(uncompleted is null))
    //        {
    //            var answers = context.TaskAnswers.Where(x => x.ActivityPassingId == uncompleted.Id);
    //            context.TaskAnswers.RemoveRange(answers);
    //            context.TestPassings.Remove(uncompleted);
    //        }
                
    //        context.TestPassings.Add(new TestPassing() { TestId = TestId, UserId = UserId, Time = DateTime.Now, IsPassed = false});
    //        context.SaveChanges();
    //    }

    //    public void Answer(int Num,string Answer)
    //    {
    //        var pass = context.TestPassings.OrderByDescending(u => u.Time).First(x => x.UserId == UserId && x.Status == ActivityStatus.Started);
    //        var task = context.Tasks.First(t => t.Number == Num && t.ActivityId == pass.TestId);
    //        var answer = context.TaskAnswers.FirstOrDefault(i => i.TaskId == task.Id && i.ActivityPassingId == pass.TestId);
    //        var rightOptions = task.Options;
            
    //        if (answer != null)
    //        {
    //            var optionAnswer = context.TaskAnswers.First(x => x.Id == answer.Id);
    //            var option = context.TaskOptions.FirstOrDefault(x => x.Option == Answer && x.Task == task);
    //            if (option != null)
    //            {
    //                optionAnswer.IsRight = rightOptions.Contains(option);
    //                optionAnswer.TaskOption = option;
    //            }
    //        }
    //        else
    //        {

    //            var option = task.Options.FirstOrDefault(x => x.Option == Answer);
    //            TaskAnswer optionTaskAnswer = new TaskAnswer() { ActivityPassingId = pass.Id, TaskId = task.Id };
    //            if (option == null)
    //            {
    //                optionTaskAnswer.TaskOption = null;
    //                optionTaskAnswer.IsRight = false;
    //            }
    //            else
    //            {
    //                optionTaskAnswer.TaskOption = option;
    //                optionTaskAnswer.IsRight = rightOptions.Contains(option);
    //            }

    //            context.TaskAnswers.Add(optionTaskAnswer);

    //        }
    //        var tasksCount = context.Tasks.Where(x => x.ActivityId == pass.TestId).Count();
    //        if (task.Number == tasksCount)
    //        {
    //            pass.Status = ActivityStatus.Completed;
    //        }
    //        context.SaveChanges();
    //    }

    //    public ActivityResultDTO GetResults()
    //    {
    //        var pass = context.TestPassings.OrderByDescending(u => u.Time).First(x => x.UserId == UserId && x.Status == ActivityStatus.Completed);

    //        ActivityResultDTO result = new ActivityResultDTO
    //        {
    //            Right = context.TaskAnswers.Count(x => x.ActivityPassingId == pass.Id && x.IsRight == true),
    //            Total = context.Tasks.Count(x => x.ActivityId == pass.TestId)
    //        };


    //        return result;
    //    }
    //    public TestTaskService(int UserId)
    //    {
    //        if (context.Users.Any(x => x.Id == UserId))
    //        {
    //            this.UserId = UserId;
    //        }
    //        else
    //        {
    //            throw new ArgumentException();
    //        }

    //        this.UserId = UserId;
    //    }
    //}
}
