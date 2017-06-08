using System.Data.Entity.ModelConfiguration;
using ORM.Entities;

namespace ORM.Configurations
{
    public class RoleConfig: EntityTypeConfiguration<Role>
    {
        public RoleConfig()
        {
            HasKey(r => r.Id);

            Property(r => r.Name)
                .IsRequired()
                .HasMaxLength(20);

            Property(r => r.Description)
                .IsOptional()
                .HasMaxLength(200);
        }
    }
}
