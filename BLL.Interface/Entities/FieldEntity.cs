using System.Collections.Generic;

namespace BLL.Interface.Entities
{
    public class FieldEntity
    {
        public FieldEntity()
        {
            Skills = new List<SkillEntity>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public IEnumerable<SkillEntity> Skills { get; set; }
    }
}
