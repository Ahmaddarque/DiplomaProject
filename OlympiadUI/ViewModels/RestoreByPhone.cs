using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OlympiadUI.ViewModels
{
    public class RestoreByPhone
    {
        [Phone(ErrorMessage = "Неверный номер телефона")]
        public string Phone { get; set; }
        [StringLength(6,ErrorMessage = "6 символов")]
        public string Code { get; set; }
    }
}