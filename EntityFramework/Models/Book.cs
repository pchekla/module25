namespace EntityFramework.Models;
public class Book
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public int Year { get; set; }

        // Внешний ключ для связи с пользователем
    public int UserId { get; set; }
    public User User { get; set; } = null!;
}