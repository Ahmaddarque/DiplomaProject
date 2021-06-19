using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Olympiads.BLL.Infrastructure.Validation
{
    public interface IValidationResult
    {
        string Error { get; }
        string Property{ get; }
        bool IsValid { get; }
    }
}
