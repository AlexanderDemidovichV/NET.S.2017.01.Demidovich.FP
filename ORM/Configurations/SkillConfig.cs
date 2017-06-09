using System.Data.Entity.ModelConfiguration;
using ORM.Entities;

namespace ORM.Configurations
{
    public class SkillConfig: EntityTypeConfiguration<Skill>
    {
        public SkillConfig()
        {
            HasKey(s => s.Id);

            Property(s => s.Subject)
                .IsRequired()
                .HasMaxLength(200);

            HasMany(s => s.Ratings)
                .WithRequired(r => r.Skill)
                .HasForeignKey(r => r.SkillId);
        }
    }
}
