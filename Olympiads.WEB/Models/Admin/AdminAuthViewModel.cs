using Olympiads.WEB.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Olympiads.WEB.Models.Admin
{
    public class AdminAuthViewModel
    {
        [Require]
        [StringLength(50, ErrorMessage = "Максимально допустимое количество символов - {1}")]
        [MinLength(8, ErrorMessage = "Минимальный логин состоит из - {1} символов")]
        public string Login { get; set; }
        [Require]
        [StringLength(50, ErrorMessage = "Максимально допустимое количество символов - {1}")]
        [MinLength(8, ErrorMessage = "Минимальный логин состоит из - {1} символов")]
        public string Password { get; set; }
    }
}