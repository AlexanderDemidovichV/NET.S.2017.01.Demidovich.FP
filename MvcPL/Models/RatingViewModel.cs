namespace MvcPL.Models
{
    public class RatingViewModel
    {
        public int Id { get; set; }

        public int SkillId { get; set; }

        public UserViewModel User { get; set; }

        public int Value { get; set; }
    }
}