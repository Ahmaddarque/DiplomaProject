using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OlympiadUI.ViewModels
{
    public class ChangePasswordViewModel
    {
        public int ParticipantId { get; set; }
        [Required(ErrorMessage = ValidationErrors.ERR_REQUIRED)]
        [StringLength(15, ErrorMessage = "Максимально допустимое количество символов - {1}")]
        public string NewPassword { get; set; }

        [StringLength(15, ErrorMessage = "Максимально допустимое количество символов - {1}")]
        [Required(ErrorMessage = ValidationErrors.ERR_REQUIRED)]
        [Compare(nameof(NewPassword), ErrorMessage = "Пароли не совпадают")]
        public string RepeatPassword { get; set; }
    }
}