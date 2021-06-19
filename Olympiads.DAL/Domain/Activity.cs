using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Olympiads.DAL.Domain
{
    public class Activity
    {
        public int Id { get; set; }
        public int? ParticipantCategoryId { get; set; }
        public int? SubjectId { get; set; }
        public virtual ParticipantCategory Category { get; set; }
        public virtual Subject Subject { get; set; }
        public bool IsActive { get; set; }
        [Required]
        public DateTime CreationTime { get; set; } = DateTime.Now;
        public virtual ICollection<Task> Tasks { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
