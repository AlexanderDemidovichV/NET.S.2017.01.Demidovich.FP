using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface.DTO
{
    public class DalRating: IEntity
    {
        public int Id { get; set; }
        public int Value { get; set; }

        public int UserId { get; set; }
        public int SkillId { get; set; }
    }
}
