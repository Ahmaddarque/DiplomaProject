using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Olympiads.DAL.Domain
{
    public class ParticipantCategory
    {
        public int Id { get; set; }
        public string IconPath { get; set; }
        [Required]
        public string Name { get; set; }
    }
}