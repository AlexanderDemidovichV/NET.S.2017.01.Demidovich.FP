using System.Data.Entity.ModelConfiguration;
using ORM.Entities;

namespace ORM.Configurations
{
    public class FieldConfig: EntityTypeConfiguration<Field>
    {
        public FieldConfig()
        {
            HasKey(f => f.Id);

            Property(f => f.Name)
                .IsRequired()
                .HasMaxLength(20);

            HasMany(f => f.Skills)
                .WithRequired(s => s.Field)
                .HasForeignKey(s => s.FieldId);
        }
    }
}
