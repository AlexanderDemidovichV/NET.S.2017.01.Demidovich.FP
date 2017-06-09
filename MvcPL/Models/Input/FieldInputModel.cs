using System.ComponentModel.DataAnnotations;

namespace MvcPL.Models.Input
{
    public class FieldInputModel
    {
        [ScaffoldColumn(false)]
        public int ParentId { get; set; }

        [Display(Name = "Name")]
        [Required(ErrorMessage = "Please enter your field name.")]
        [StringLength(300, ErrorMessage = "The field name must contain at least {2} characters.", MinimumLength = 5)]
        public string Name { get; set; }
    }
}