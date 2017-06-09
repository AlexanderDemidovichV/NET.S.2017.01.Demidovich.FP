using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ORM.Entities;

namespace ORM.Configurations
{
    public class RatingConfig: EntityTypeConfiguration<Rating>
    {
        public RatingConfig()
        {
            HasKey(r => r.Id);

            Property(r => r.Value)
                .IsRequired();

            HasRequired(r => r.User)
                .WithMany(u => u.Ratings)
                .HasForeignKey(r => r.UserId)
                .WillCascadeOnDelete(false);
        }
    }
}
