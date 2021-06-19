using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Olympiads.DAL.Domain
{
    [Table("OlympiadPassing")]
    public class OlympiadPassing : ActivityPassing
    {
        public virtual Olympiad Olympiad { get; set; }
        public int? OlympiadId { get; set; }
        public int? ParticipantId { get; set; }
        public virtual Participant Participant { get; set; }
    }
}
