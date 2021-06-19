using OlympiadUI.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OlympiadUI.ViewModels
{
    public class RegisterParticipant
    {
        [Require]
        [StringLength(50, ErrorMessage = "Максимально допустимое количество символов - {1}")]
        public string Surname { get; set; }

        [Require]
        [StringLength(50, ErrorMessage = "Максимально допустимое количество символов - {1}")]
        public string Name { get; set; }

        [StringLength(50, ErrorMessage = "Максимально допустимое количество символов - {1}")]
        public string Lastname { get; set; }

        [Require]
        [StringLength(25, ErrorMessage = "Максимально допустимое количество символов - {1}")]
        public string Login { get; set; }

        [Require]
        [StringLength(25, ErrorMessage = "Максимально допустимое количество символов - {1}")]
        [DataType(DataType.PhoneNumber)]
        [Phone(ErrorMessage = "Неверный номер телефона")]
        public string Phone { get; set; }

        [Require]
        [StringLength(150, ErrorMessage = "Максимально допустимое количество символов - {1}")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage ="Неверный email")]
        public string Email { get; set; }

        [Require]
        public DateTime Birthdate { get; set; }

        [Require]
        public string EducationalInstitution { get; set; }

        [Require]
        [StringLength(15, ErrorMessage = "Максимально допустимое количество символов - {1}")]
        public string Password { get; set; }

        [Require]
        [Compare(nameof(Password),ErrorMessage = "Пароли не совпадают")]
        [StringLength(15, ErrorMessage = "Максимально допустимое количество символов - {1}")]
        public string ConfirmPassword { get; set; }

        public int Sex { get; set; }
    }
}