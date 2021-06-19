using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnidecodeSharpFork;

namespace Olympiads.BLL.BusinessModels
{
    class LoginGenerator
    {
        public string Generate( string surname, string name, string lastname)
        {
            return string.Join("",surname.Unidecode(),name.First().Unidecode(),lastname.First().Unidecode());
        }
    }
}
