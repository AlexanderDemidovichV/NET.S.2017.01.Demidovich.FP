using System.Collections.Generic;

namespace DAL.Interface.DTO
{
    public class DalField: IEntity
    {
        public DalField()
        {
            Skills = new List<DalSkill>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public IEnumerable<DalSkill> Skills { get; set; }
    }
}
