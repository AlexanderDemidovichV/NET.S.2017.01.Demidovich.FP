using System.Collections.Generic;

namespace MvcPL.Models
{
    public class FieldViewModel
    {
        public FieldViewModel()
        {
            SubFields = new List<FieldViewModel>();
            Skills = new List<SkillViewModel>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public List<FieldViewModel> SubFields { get; set; }
        public List<SkillViewModel> Skills { get; set; }

    }
}