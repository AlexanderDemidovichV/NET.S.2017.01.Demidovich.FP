using System.Data.Entity.ModelConfiguration;
using ORM.Entities;

namespace ORM.Configurations
{
    public class SkillConfig: EntityTypeConfiguration<Skill>
    {
        public SkillConfig()
        {
            HasKey(s => s.Id);

            Property(s => s.Rating)
                .IsRequired();

            HasRequired(s => s.User)
                .WithMany(u => u.Skills)
                .HasForeignKey(m => m.UserId)
                .WillCascadeOnDelete(false);
        }
    }
}
