using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OlympiadUI.ViewModels
{
    public class AnswerViewModel
    {
        public string UserAnswer { get; set; }
        public int TestId { get; set; }
        public int TaskNumber { get; set; }
    }
}