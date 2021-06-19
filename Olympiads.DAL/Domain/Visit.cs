using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Olympiads.DAL.Domain
{
    public class Visit
    {
        public int Id { get; set; }
        public int? VisiterId { get; set; }
        public Visiter Visiter { get; set; }
        public DateTime VisitTime { get; set; }
    }
}
