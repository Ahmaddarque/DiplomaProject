using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Olympiads.DAL.Domain
{
    public class TaskAnswer
    {
        public int Id { get; set; }
        public int TaskId { get; set; }
        public int ActivityPassingId { get; set; }
        public virtual Task Task { get; set; }
        public virtual ActivityPassing ActivityPassing { get; set; }
        [Required]
        public bool IsRight { get; set; }
        public TaskOption TaskOption { get; set; }
    }
}