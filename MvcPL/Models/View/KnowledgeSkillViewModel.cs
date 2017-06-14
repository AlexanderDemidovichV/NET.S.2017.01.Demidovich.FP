using System.Collections.Generic;
using MvcPL.Models.Input;

namespace MvcPL.Models.View
{
    public class KnowledgeSkillViewModel
    {
        public KnowledgeSkillViewModel()
        {
            ParentFields = new List<FieldViewModel>();
            RatingInput = new RatingInputModel();
        }

        public SkillViewModel Skill { get; set; }

        public List<FieldViewModel> ParentFields { get; set; }

        public RatingInputModel RatingInput { get; set; }
    }
}