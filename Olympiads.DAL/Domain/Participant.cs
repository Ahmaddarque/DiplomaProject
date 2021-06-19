using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Olympiads.DAL.Domain
{
    [Table("Participant")]
    public class Participant : User
    {
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public DateTime Birthdate { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string EducationalInstitution { get; set; }
        public Sex Sex { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string PasswordSalt { get; set; }
        public DateTime RegistrationTime { get; set; } 
        public string RegistrationIP { get; set; }
        public bool IsBlocked { get; set; }
    }
}