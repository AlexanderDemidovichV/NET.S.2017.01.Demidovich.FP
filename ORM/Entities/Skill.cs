using System.Collections.Generic;

namespace ORM.Entities
{
    public class Skill
    {
        public Skill()
        {
            Ratings = new List<Rating>();
        }

        public int Id { get; set; }

        public string Subject { get; set; }

        public int FieldId { get; set; }
        public virtual Field Field { get; set; }

        public virtual ICollection<Rating> Ratings { get; set; }
    }
}
