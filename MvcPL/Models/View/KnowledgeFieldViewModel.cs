using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcPL.Models.Input;

namespace MvcPL.Models.View
{
    public class KnowledgeFieldViewModel
    {
        public KnowledgeFieldViewModel()
        {
            ParentFields = new List<FieldViewModel>();
            FieldInput = new FieldInputModel();
            SkillInput = new SkillInputModel();
        }

        public FieldViewModel Field { get; set; }

        public List<FieldViewModel> ParentFields { get; set; }

        public FieldInputModel FieldInput { get; set; }
        public SkillInputModel SkillInput { get; set; }
    }
}