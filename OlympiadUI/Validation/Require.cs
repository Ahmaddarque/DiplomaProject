using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OlympiadUI.Validation
{
    public class Require : RequiredAttribute
    {
        public Require()
        {
            ErrorMessage = "Поле не заполнено";
        }
    }
}