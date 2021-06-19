using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Olympiads.WEB.Models.Admin
{
    public class ParticipantViewModel
    {
        public int Id { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public bool IsBlocked { get; set; }
    }
}