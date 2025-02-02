namespace EntityFramework.Models;
public class User
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Email { get; set; } = null!;

    // Навигационное свойство для связи с книгами
    public List<Book> Books { get; set; } = [];
}