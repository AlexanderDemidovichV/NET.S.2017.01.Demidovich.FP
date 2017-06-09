using System.Collections.Generic;

namespace BLL.Interface.Entities
{
    public class SkillEntity
    {
        public SkillEntity()
        {
            Ratings = new List<RatingEntity>();
        }

        public int Id { get; set; }
        public int FieldId { get; set; }

        public string Subject { get; set; }

        public IEnumerable<RatingEntity> Ratings { get; set; }
    }
}
