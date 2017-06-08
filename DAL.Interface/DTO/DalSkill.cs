using System.Collections.Generic;

namespace DAL.Interface.DTO
{
    public class DalSkill: IEntity
    {
        public DalSkill()
        {
            Marks = new List<DalMark>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public int FieldId { get; set; }

        public virtual ICollection<DalMark> Marks { get; set; }
    }
}
