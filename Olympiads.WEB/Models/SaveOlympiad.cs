using Olympiads.WEB.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Olympiads.WEB.Models
{
    public class SaveOlympiad
    {
        public int Id { get; set; }
        [Require]
        [StringLength(50,ErrorMessage = "Максимальное название - {1} символов")]
        [MinLength(8,ErrorMessage = "Максимальное название - {1} символов")]
        public string Name { get; set; }
        [StringLength(150, ErrorMessage = "Максимальное название - {1} символов")]
        public string Description { get; set; }
        [Range(0,5,ErrorMessage = "Максимум - {2} часов")]
        public uint Hours { get; set; }
        [Range(0, 59, ErrorMessage = "Максимум - {2} минут")]
        public uint Minutes { get; set; }
        [Require]
        public string Subject { get; set; }
        [Require]
        public string Category { get; set; }
        public SelectList Subjects { get; set; }
        public SelectList Categories { get; set; }
        public bool IsEdit { get; set; }
        [Require]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Start { get; set; }
        [FutureDate(2)]
        [Require]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime End { get; set; }
    }
}