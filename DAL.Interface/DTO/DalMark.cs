namespace DAL.Interface.DTO
{
    public class DalMark: IEntity
    {
        public int Id { get; set; }
        public int SkillId { get; set; }
        public int UserId { get; set; }
        public byte Value { get; set; }
    }
}
