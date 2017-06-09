using System.Collections.Generic;

namespace ORM.Entities
{
    public class Skill
    {
        public int Id { get; set; }

        public string Rating { get; set; }

        public int FieldId { get; set; }
        public virtual Field Field { get; set; }

        public int UserId { get; set; }
        public virtual User User { get; set; }
    }
}
