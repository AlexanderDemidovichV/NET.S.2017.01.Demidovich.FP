using ORM.Entities;
using System.Data.Entity.ModelConfiguration;

namespace ORM.Configurations
{
    public class MarkConfig: EntityTypeConfiguration<Mark>
    {
        public MarkConfig()
        {
            HasKey(m => m.Id);

            Property(m => m.Value)
                .IsRequired();

            HasRequired(m => m.User)
                .WithMany(u => u.Marks)
                .HasForeignKey(m => m.UserId)
                .WillCascadeOnDelete(false);
        }
    }
}
