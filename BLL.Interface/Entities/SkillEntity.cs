using System.Collections.Generic;

namespace BLL.Interface.Entities
{
    public class SkillEntity
    {
        public SkillEntity()
        {
            Marks = new List<MarkEntity>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public IEnumerable<MarkEntity> Marks { get; set; }
    }
}
