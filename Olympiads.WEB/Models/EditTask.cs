using Olympiads.WEB.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Olympiads.WEB.Models
{
    public class EditTask
    {
        public int Number { get; set; }
        [Require]
        [StringLength(500,ErrorMessage = "Максимальное кол-во символов - {1}")]
        public string Content { get; set; }
        [DataType(DataType.Upload)]
        public string ImagePath { get; set; }
        public bool IsEdit { get; set; }
    }
}