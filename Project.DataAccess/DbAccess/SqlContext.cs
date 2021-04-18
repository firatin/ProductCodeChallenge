using Microsoft.EntityFrameworkCore;
using Project.Entities.Object;

namespace Project.DataAccess.DbAccess {
    public class SqlContext : DbContext {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            //base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=LogiwaChallengeDb;Trusted_Connection=true;");

        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<Category>(builder => { builder.HasKey(x => x.Id); });
            modelBuilder.Entity<Product>(builder => { builder.HasKey(x => x.Id); });

            //modelBuilder.Entity<Product>().HasOne<Category>(x => x.Category).WithMany(x => x.Products).HasForeignKey(x => x.CategoryId);
        }
    }
}
