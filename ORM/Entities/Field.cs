using System.Collections.Generic;

namespace ORM.Entities
{
    public class Field
    {
        public Field()
        {
            Skills = new List<Skill>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Skill> Skills { get; set; }
    }
}
