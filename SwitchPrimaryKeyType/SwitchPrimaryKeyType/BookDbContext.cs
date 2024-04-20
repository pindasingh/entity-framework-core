using Microsoft.EntityFrameworkCore;
using SwitchPrimaryKeyDataType.Entities;

namespace SwitchPrimaryKeyDataType;

public class BookDbContext : DbContext
{
    public DbSet<Book> Books { get; set; }

    public DbSet<BookDetail> BookDetails { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(
            @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SwitchPrimaryKeyDataType;Integrated Security=True;Connect Timeout=30;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Book>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Author).IsRequired();
            entity.Property(e => e.Title).IsRequired();
            entity.Property(e => e.Year).IsRequired();
        });


        modelBuilder.Entity<BookDetail>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Description);

            // Relationship with Book entity
            entity.HasOne(d => d.Book)
                  .WithMany(p => p.BookDetails)
                  .HasForeignKey(d => d.BookId)
                  .OnDelete(DeleteBehavior.Cascade);
        });
    }
}
