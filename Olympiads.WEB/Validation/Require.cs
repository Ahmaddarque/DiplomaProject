using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Olympiads.WEB.Validation
{
    public class Require : RequiredAttribute
    {
        private const string required = "Поле не заполнено";
        public Require()
        {
            ErrorMessage = required;
        }
    }
}