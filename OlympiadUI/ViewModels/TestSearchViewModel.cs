using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OlympiadUI.ViewModels
{
    public class TestSearchViewModel
    {
        public string Search { get; set; }
        public int[] Subjects { get; set; }
        public int[] Categories { get; set; }
        public int StartIdx { get; set; }
        public int PageIdx { get; set; } = 10;
    }
}