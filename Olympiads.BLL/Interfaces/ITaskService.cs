using Olympiads.BLL.DTO;
using Olympiads.BLL.Infrastructure.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Olympiads.BLL.Interfaces
{
    public interface ITaskService
    {
        IEnumerable<TaskInfoDTO> GetTasks(int ActivityId);
        TaskDTO GetTask(int ActivityId, int Number);
        IValidationResult SaveTask(SaveTaskDTO task);
        IValidationResult DeleteTask(int ActivityId, int Number);
    }
}
