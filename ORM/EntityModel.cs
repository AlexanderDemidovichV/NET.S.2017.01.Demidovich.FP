using System.Data.Entity;
using ORM.Entities;
using ORM.Initializers;

namespace ORM
{
    public class EntityModel: DbContext
    {
        static EntityModel()
        {
            Database.SetInitializer(new KnowledgeSystemDbInitializer());
        }

        public EntityModel()
            : base()
        {
        }

        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Profile> Profiles { get; set; }

        public virtual DbSet<Skill> Skills { get; set; }
        public virtual DbSet<Field> Fields { get; set; }
        public virtual DbSet<Mark> Marks { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.Add(new Configurations.RoleConfig());
            modelBuilder.Configurations.Add(new Configurations.UserConfig());
            modelBuilder.Configurations.Add(new Configurations.ProfileConfig());
            modelBuilder.Configurations.Add(new Configurations.MarkConfig());
            modelBuilder.Configurations.Add(new Configurations.SkillConfig());
            modelBuilder.Configurations.Add(new Configurations.FieldConfig());
        }
    }
}
