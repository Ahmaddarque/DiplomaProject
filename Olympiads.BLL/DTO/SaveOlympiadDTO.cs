using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Olympiads.BLL.DTO
{
    public class SaveOlympiadDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Minutes { get; set; }
        public string Subject { get; set; }
        public string Category { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
    }
}
