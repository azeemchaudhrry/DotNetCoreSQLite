using dotNetCoreSQLite.Model;
using Microsoft.EntityFrameworkCore;

namespace dotNetCoreSQLite.Config
{
    public class QuoteDbContext : DbContext
    {
        public DbSet<Quote> quotes { get; set; }
        public DbSet<Author> authors { get; set; }
        public DbSet<QuoteType> quote_types { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("Data Source=testdb.db");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Quote>()
            //    .HasOne(e => e.author)
            //    .WithMany(c => c.quotes)
            //    .HasForeignKey(x => x.author_id);

            //modelBuilder.Entity<Quote>()
            //    .HasOne(g => g.quote_type)
            //    .WithMany(x => x.quotes)
            //    .HasForeignKey(x => x.quote_type_id);

            //modelBuilder.Entity<Author>()
            //    .HasMany(qt => qt.quotes)
            //    .WithOne(q => q.author)
            //    .HasForeignKey(x => x.author_id);

            //modelBuilder.Entity<QuoteType>()
            //    .HasMany(qt => qt.quotes)
            //    .WithOne(q => q.quote_type)
            //    .HasForeignKey(x => x.quote_type_id);
        }
    }
}
