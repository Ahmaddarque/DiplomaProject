using OlympiadUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OlympiadUI.ViewModels
{
    public class TaskInfo
    {
        public string TestName { get; set; }
        public int TestId { get; set; }
        public int Number { get; set; }
        public int Total { get; set; }
        public string Content { get; set; }
        public string ImagePath { get; set; }
    }
}