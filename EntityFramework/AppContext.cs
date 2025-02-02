using EntityFramework.Models;
using Microsoft.EntityFrameworkCore;

namespace EntityFramework;
public class AppContext : DbContext
{
    /// <summary>
    /// Пользователи
    /// </summary>
    public DbSet<User> Users { get; set; } = null!;

    /// <summary>
    /// Книги
    /// </summary>
    public DbSet<Book> Books { get; set; } = null!;

    /// <summary>
    /// Авторы
    /// </summary>
    public DbSet<Author> Authors { get; set; } = null!;

    /// <summary>
    /// Жанры
    /// </summary>
    public DbSet<Genre> Genres { get; set; } = null!;

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="optionsBuilder"></param>
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Server=PC-WIN\SQLEXPRESS;Database=EF;Trusted_Connection=True;TrustServerCertificate=True;");
    }
}
