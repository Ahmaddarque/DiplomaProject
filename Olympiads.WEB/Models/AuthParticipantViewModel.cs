using Olympiads.WEB.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Olympiads.WEB.Models
{
    public class AuthParticipantViewModel
    {
        [Require]
        [StringLength(25, ErrorMessage = "Максимально допустимое количество символов - {1}")]
        public string Login { get; set; }
        [Require]
        [StringLength(50, ErrorMessage = "Максимально допустимое количество символов - {1}")]
        public string Password { get; set; }
    }
}