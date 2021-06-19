using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Olympiads.BLL.DTO
{
    public class TestSearchDTO
    {
        public string Search { get; set; }
        public int[] Subjects { get; set; }
        public int[] Categories { get; set; }
        public int StartIdx { get; set; }
        public int PageIdx { get; set; } 
    }
}
