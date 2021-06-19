using Olympiads.WEB.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Olympiads.WEB.Models.Admin
{
    public class ParticipantEditViewModel
    {
        public int Id { get; set; }
        [Require]
        public string Surname { get; set; }
        [Require]
        public string Name { get; set; }
        public string Lastname { get; set; }
        [Require]
        [StringLength(25, ErrorMessage = "Максимально допустимое количество символов - {1}")]
        [DataType(DataType.PhoneNumber)]
        [Phone(ErrorMessage = "Неверный номер телефона")]
        public string Phone { get; set; }
        [Require]
        [StringLength(150, ErrorMessage = "Максимально допустимое количество символов - {1}")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "Неверный email")]
        public string Email { get; set; }
        [Require]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Birthdate { get; set; }
        public bool IsMale { get; set; }
        [Require]
        public string EducationalInstitution { get; set; }
        public bool IsEdit { get; set; }
    }
}