using Olympiads.WEB.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Olympiads.WEB.Models
{
    public class RestoreByEmailViewModel
    {
        [Require]
        [StringLength(150, ErrorMessage = "Максимально допустимое количество символов - {1}")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "Неверный email")]
        public string Email { get; set; }
    }
}