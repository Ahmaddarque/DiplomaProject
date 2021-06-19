using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Olympiads.BLL.BusinessModels
{
    internal class PasswordGenerator : VariousCharsCodeGenerator
    {
        public PasswordGenerator()
            :base("ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmopqrstuvwxyz0123456789")
        {

        }
    }
}
