using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Olympiads.WEB.Models
{
    public class ChangePasswordViewModel
    {
        [Required]
        [StringLength(15, ErrorMessage = "Максимально допустимое количество символов - {1}")]
        public string NewPassword { get; set; }

        [StringLength(15, ErrorMessage = "Максимально допустимое количество символов - {1}")]
        [Required]
        [Compare(nameof(NewPassword), ErrorMessage = "Пароли не совпадают")]
        public string RepeatPassword { get; set; }
        public string Code { get; set; }
    }
}