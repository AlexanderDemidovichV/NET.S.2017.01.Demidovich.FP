using System.Collections.Generic;

namespace ORM.Entities
{
    public class Field
    {
        public Field()
        {
            SubFields = new List<Field>();
            Skills = new List<Skill>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public int? ParentFieldId { get; set; }
        public virtual Field ParentField { get; set; }

        public virtual ICollection<Skill> Skills { get; set; }
        public virtual ICollection<Field> SubFields { get; set; }
    }
}
