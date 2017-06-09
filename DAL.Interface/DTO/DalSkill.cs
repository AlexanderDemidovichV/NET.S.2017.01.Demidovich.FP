using System.Collections.Generic;

namespace DAL.Interface.DTO
{
    public class DalSkill: IEntity
    {
        public DalSkill()
        {
            Ratings = new List<DalRating>();
        }

        public int Id { get; set; }

        public string Subject { get; set; }

        public int FieldId { get; set; }

        public IEnumerable<DalRating> Ratings { get; set; }
    }
}
