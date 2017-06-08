using System.Data.Entity.ModelConfiguration;
using ORM.Entities;

namespace ORM.Configurations
{
    public class ProfileConfig: EntityTypeConfiguration<Profile>
    {
        public ProfileConfig()
        {
            HasKey(p => p.Id);

            Property(p => p.ImageData)
                .IsOptional();

            Property(p => p.ImageMimeType)
                .IsOptional();
        }
    }
}
