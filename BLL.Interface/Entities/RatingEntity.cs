using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interface.Entities
{
    public class RatingEntity
    {
        public int Id { get; set; }
        public int SkillId { get; set; }
        public int UserId { get; set; }
        public int Value { get; set; }
    }
}
