using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Olympiads.BLL.DTO
{
    //Kinda blob
    public class TestTaskInfoDTO
    {
        public int Number { get; set; }
        public int Total { get; set; }
        public string Content { get; set; }
        public string ImagePath { get; set; }
        public bool IsLast { get; set; }

        public IEnumerable<string> Options { get; set; }
    }
}
