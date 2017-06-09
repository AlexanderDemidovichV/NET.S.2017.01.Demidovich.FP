using System.Collections.Generic;

namespace BLL.Interface.Entities
{
    public class FieldEntity
    {
        public FieldEntity()
        {
            Skills = new List<SkillEntity>();
            SubFields = new List<FieldEntity>();
        }

        public int Id { get; set; }

        public int? ParentId { get; set; }

        public string Name { get; set; }

        public IEnumerable<SkillEntity> Skills { get; set; }
        public IEnumerable<FieldEntity> SubFields { get; set; }
    }
}
