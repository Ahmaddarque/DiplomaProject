using Olympiads.WEB.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Olympiads.WEB.Models.Admin
{
    public class EditTestViewModel
    {
        public int Id { get; set; }
        [StringLength(40,ErrorMessage = "Максимальное количество символов - {1}")]
        [Require]
        public string Name { get; set; }
        [StringLength(75, ErrorMessage = "Максимальное количество символов - {1}")]
        public string Description { get; set; }
        public string Subject { get; set; }
        public SelectList AvailableSubjects { get; set; }
        public string Category { get; set; }
        public SelectList AvailableCategories { get; set; }
        public bool IsEdit { get; set; }
    }
}