using System.Collections.Generic;

namespace MvcPL.Models
{
    public class SkillViewModel
    {
        public SkillViewModel()
        {
            Ratings = new List<RatingViewModel>();
        }

        public int Id { get; set; }

        public int FieldId { get; set; }

        public string Subject { get; set; }

        public int RatingCount { get; set; }

        public List<RatingViewModel> Ratings { get; set; }
    }
}