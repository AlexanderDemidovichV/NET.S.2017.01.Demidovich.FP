using System.ComponentModel.DataAnnotations;

namespace MvcPL.Models.Input
{
    public class RatingInputModel
    {
        [ScaffoldColumn(false)]
        public int SkillId { get; set; }

        [Display(Name = "Rating")]
        [Required(ErrorMessage = "Please enter your rating.")]
        public int Value { get; set; }
    }
}