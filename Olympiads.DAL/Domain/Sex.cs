using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Olympiads.DAL.Domain
{

    public enum Sex
    {
        [Description("мужской")]
        Male,
        [Description("женский")]
        Female
    }
}