using Olympiads.BLL.DTO;
using Olympiads.BLL.Infrastructure.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Olympiads.BLL.Interfaces
{
    public interface ICRUDTestService
    {
        IEnumerable<TestDTO> GetTests(TestInfoDTO testInfo);
        TestSaveDTO GetTest(int TestId);
        void Activate(int TestId);
        void Deactivate(int TestId);
        void Save(TestSaveDTO save);
    }
}
