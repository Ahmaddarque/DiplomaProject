using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Olympiads.BLL.BusinessModels
{
    internal abstract class CodeGenerator
    {
        public string Generate(int digits)
        {
            string code = string.Empty;

            for (int i = 0; i < digits; i++)
            {
                code += GetSymbol();
            }
            return code;
        }

        protected abstract string GetSymbol();
    }
}
