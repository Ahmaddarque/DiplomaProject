using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Olympiads.WEB.Models.Admin
{
    public class DashboardViewModel
    {
        public int VisitersLastDay { get; set; }
        public int ParticipantsLastDay { get; set; }
        public int TestsLastDay { get; set; }
        public int OlympiadsLastDay { get; set; }
    }
}