using System.Collections.Generic;

namespace DAL.Interface.DTO
{
    public class DalField: IEntity
    {
        public DalField()
        {
            Skills = new List<DalSkill>();
            SubFields = new List<DalField>();
        }

        public int Id { get; set; }

        public int? ParentId { get; set; }

        public string Name { get; set; }

        public IEnumerable<DalSkill> Skills { get; set; }
        public IEnumerable<DalField> SubFields { get; set; }
    }
}
