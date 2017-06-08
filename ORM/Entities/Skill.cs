using System.Collections.Generic;

namespace ORM.Entities
{
    public class Skill
    {
        public Skill()
        {
            Marks = new List<Mark>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public int FieldId { get; set; }
        public virtual Field Field { get; set; }

        public virtual ICollection<Mark> Marks { get; set; }
    }
}
