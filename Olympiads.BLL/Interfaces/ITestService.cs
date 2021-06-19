using Olympiads.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Olympiads.BLL.Interfaces
{
    public interface ITestService
    {
        IEnumerable<TestDTO> GetTests(TestSearchDTO testQuery);
    }
}
