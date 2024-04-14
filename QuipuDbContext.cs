namespace Quipu_task
{
    using Microsoft.EntityFrameworkCore;
    using Quipu_task.Models;

    public class QuipuDbContext : DbContext
    {
        public QuipuDbContext(DbContextOptions<QuipuDbContext> options) : base(options)
        {
        }
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>()
                .HasOne(b => b.Author)
                .WithMany() // Assuming an author can have many books
                .HasForeignKey(b => b.AuthorId);
        }
    }
}
