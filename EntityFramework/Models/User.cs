namespace EntityFramework.Models;
public class User
{
    /// <summary>
    /// Идентификатор пользователя
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Имя пользователя
    /// </summary>
    public string Name { get; set; } = null!;

    /// <summary>
    /// Email пользователя
    /// </summary>
    public string Email { get; set; } = null!;

    /// <summary>
    /// Навигационное свойство для связи с книгами
    /// </summary>
    public List<Book> Books { get; set; } = [];
}