
using Olympiads.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Olympiads.WEB.Models
{
    public class TaskInfoViewModel
    {
        public string TestName { get; set; }
        public int TestId { get; set; }
        public int Number { get; set; }
        public int Total { get; set; }
        public string Content { get; set; }
        public string ImagePath { get; set; }
        public string IsLast { get; set; }
        public IEnumerable<string> Options { get; set; }
    }
}