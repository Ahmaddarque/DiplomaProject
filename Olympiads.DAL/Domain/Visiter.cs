using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Olympiads.DAL.Domain
{
    [Table("Visiter")]
    public class Visiter : User
    {
        public string IP { get; set; }
    }
}