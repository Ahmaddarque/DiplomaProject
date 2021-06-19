using Olympiads.BLL.DTO;
using Olympiads.BLL.Infrastructure.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Olympiads.BLL.Interfaces
{
    public interface ICRUDOlympiadService
    {
        IEnumerable<OlympiadDTO> GetOlympiads(OlympiadInfoDTO info);
        SaveOlympiadDTO GetOlympiad(int OlympiadId);
        IValidationResult Save(SaveOlympiadDTO olympiad);
        void Activate(int OlympiadId);
        void Deactivate(int OlympiadId);
    }
}
