using ATProManagement.Db.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace ATProManagement.Db
{
    public class AppDbContext : IdentityDbContext<EntityUser>, IDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public IRepository<T> Repo<T>() where T : class
        {
            return new Repository<T>(this);
        }

        public DbSet<EntityCourse> Courses { get; set; }

        public DbSet<EntityClient> Clients { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                if (!typeof(EntityBase)
                 .IsAssignableFrom(entityType.ClrType))
                    continue;
                var entity = modelBuilder
                      .Entity(entityType.ClrType);

                entity.Property(nameof(EntityBase.Guid))
                      .HasColumnOrder(0);

                entity.Property(nameof(EntityBase.TimeCreated))
                      .HasColumnOrder(1);

                entity.Property(nameof(EntityBase.UserCreated))
                      .HasColumnOrder(2);

                entity.Property(nameof(EntityBase.TimeModified))
                      .HasColumnOrder(3);

                entity.Property(nameof(EntityBase.UserModified))
                      .HasColumnOrder(4);
            }
            modelBuilder.Entity<IdentityRole>(entity =>
            {
                entity.Property(x => x.Name)
                    .HasMaxLength(191);

                entity.Property(x => x.NormalizedName)
                    .HasMaxLength(191);
            });

            modelBuilder.Entity<EntityCourse>()
               .Property(x => x.Name)
               .IsRequired()
               .HasMaxLength(200);

            modelBuilder.Entity<EntityClient>()
             .Property(x => x.Name)
             .IsRequired()
             .HasMaxLength(200);
        }
    }
}
