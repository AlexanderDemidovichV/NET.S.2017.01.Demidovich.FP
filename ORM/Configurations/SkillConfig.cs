using System.Data.Entity.ModelConfiguration;
using ORM.Entities;

namespace ORM.Configurations
{
    public class SkillConfig: EntityTypeConfiguration<Skill>
    {
        public SkillConfig()
        {
            HasKey(s => s.Id);

            Property(s => s.Name)
                .IsRequired()
                .HasMaxLength(200);

            HasMany(s => s.Marks)
                .WithRequired(m => m.Skill)
                .HasForeignKey(m => m.SkillId);
        }
    }
}
