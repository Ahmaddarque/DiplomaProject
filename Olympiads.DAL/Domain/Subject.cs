using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Olympiads.DAL.Domain
{
    public class Subject
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string IconPath { get; set; }
        public virtual ICollection<Activity> Activities { get; set; }
    }
}