using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Olympiads.BLL.Infrastructure.Validation
{
    internal sealed class ValidResult : IValidationResult
    {
        public string Error => string.Empty;
        public string Property => string.Empty;
        public bool IsValid => true;
    }
}
