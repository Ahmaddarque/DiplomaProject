using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Olympiads.DAL.Domain
{
    [Table("TestPassings")]
    public class TestPassing : ActivityPassing
    {
        public int TestId { get; set; }
        public virtual Test Test { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
    }
}