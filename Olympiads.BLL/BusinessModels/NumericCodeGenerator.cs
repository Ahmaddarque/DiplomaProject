using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Olympiads.BLL.BusinessModels
{
    class NumericCodeGenerator : VariousCharsCodeGenerator
    {
        public NumericCodeGenerator():base("0123456789")
        {

        }
    }
}
