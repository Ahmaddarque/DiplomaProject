using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Olympiads.DAL.Domain
{
    [Table("Olympiad")]
    public class Olympiad : Activity
    {
        [Required]
        public int Minutes { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
    }
}