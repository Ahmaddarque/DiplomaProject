using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Olympiads.BLL.BusinessModels
{
    class AlphaNumericCodeGenerator : VariousCharsCodeGenerator
    {
        public AlphaNumericCodeGenerator() : base("ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789")
        {

        }
    }
}
