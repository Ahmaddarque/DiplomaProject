using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Olympiads.BLL.Infrastructure.Validation
{
    internal class FailedResult : IValidationResult
    {
        private readonly string error;
        private readonly string property;

        public string Error => error;

        public bool IsValid => false;

        public string Property => property;

        public FailedResult(string error = "",string property="")
        {
            this.error = error;
            this.property = property;
        }
    }
}
