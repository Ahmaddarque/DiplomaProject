using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Olympiads.DAL.Domain
{
    public class ParticipantLogin
    {
        public int Id { get; set; }
        public int? ParticipantId { get; set; }
        public DateTime Time { get; set; }
        public virtual Participant Participant { get; set; }
    }
}
