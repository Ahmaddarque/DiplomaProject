using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Olympiads.BLL.DTO
{
    public class SaveTaskDTO
    {
        public int ActivityId { get; set; }
        public int Number { get; set; }
        public string Content { get; set; }
        public byte[] Image { get; set; }
        public IEnumerable<TaskOptionDTO> Options { get; set; }
    }
}
