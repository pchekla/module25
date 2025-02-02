using EntityFramework.Models;
using Microsoft.EntityFrameworkCore;

namespace EntityFramework;
public class AppContext : DbContext
{
    // Объекты таблицы Users и Books
    public DbSet<User> Users { get; set; } = null!;
    public DbSet<Book> Books { get; set; } = null!;
    public DbSet<Author> Authors { get; set; } = null!;
    public DbSet<Genre> Genres { get; set; } = null!;

    public AppContext()
    {
        Database.EnsureDeleted(); // Удаление БД при каждом запуске
        Database.EnsureCreated();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Server=PC-WIN\SQLEXPRESS;Database=EF;Trusted_Connection=True;TrustServerCertificate=True;");
    }
}
