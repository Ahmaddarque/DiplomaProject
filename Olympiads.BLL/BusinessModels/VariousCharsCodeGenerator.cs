using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Olympiads.BLL.BusinessModels
{
    internal class VariousCharsCodeGenerator : CodeGenerator
    {
        private readonly string allowedChars;
        private readonly Random rand = new Random();

        protected sealed override string GetSymbol()
        {
            return allowedChars[rand.Next(allowedChars.Length)].ToString();
        }

        public VariousCharsCodeGenerator(string allowedChars)
        {
            this.allowedChars = allowedChars;
        }
    }
}
