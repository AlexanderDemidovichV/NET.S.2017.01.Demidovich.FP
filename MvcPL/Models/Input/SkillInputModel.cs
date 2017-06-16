using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcPL.Models.Input
{
    public class SkillInputModel
    {
        [ScaffoldColumn(false)]
        public int FieldId { get; set; }

        [Display(Name = "Subject")]
        [Required(ErrorMessage = "Please enter your skill subject.")]
        [StringLength(300, ErrorMessage = "The skill subject must contain at least {2} characters.", MinimumLength = 5)]
        public string Subject { get; set; }
    }
}