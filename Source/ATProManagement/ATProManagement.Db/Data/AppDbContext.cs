using Microsoft.EntityFrameworkCore;


namespace ATProManagement.Db
{
    public class AppDbContext : DbContext, IDbContext
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
