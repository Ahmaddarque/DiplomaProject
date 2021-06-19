using OlympiadUI.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OlympiadUI.ViewModels
{
    public class AuthParticipant
    {
        [Require]
        [StringLength(25, ErrorMessage = "Максимально допустимое количество символов - {1}")]
        public string Login { get; set; }
        [Require]
        [StringLength(15, ErrorMessage = "Максимально допустимое количество символов - {1}")]
        public string Password { get; set; }
    }
}