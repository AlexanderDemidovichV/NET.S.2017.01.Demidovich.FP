namespace ORM.Entities
{
    public class Mark
    {
        public int Id { get; set; }
        public byte Value { get; set; }

        public int UserId { get; set; }
        public virtual User User { get; set; }

        public int SkillId { get; set; }
        public virtual Skill Skill { get; set; }
    }
}
