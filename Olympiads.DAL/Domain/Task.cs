using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Olympiads.DAL.Domain
{
    public class Task
    {
        public int Id { get; set; }
        [Required]
        public int Number { get; set; }
        //[Required]
        public int? ActivityId { get; set; }
        public virtual Activity Activity { get; set; }
        [Required]
        public string Content { get; set; }
        public byte[] Image { get; set; }
        public decimal Points { get; set; }
        public virtual ICollection<TaskOption> Options { get; set; }
    }
}