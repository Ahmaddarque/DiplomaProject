using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Olympiads.BLL.DTO
{
    public class RegisterParticipantDTO
    {
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string Login { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public DateTime Birthdate { get; set; }
        public string EducationalInstitution { get; set; }
        public string Password { get; set; }
        public bool Gender { get; set; }
        public string IP { get; set; }
    }
}