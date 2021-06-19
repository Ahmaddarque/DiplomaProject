using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Olympiads.DAL.Domain
{
    public class PhoneRestore:AccountRestore
    {
        [MinLength(25)]
        [MaxLength(25)]
        public string Code { get; set; }
    }
}