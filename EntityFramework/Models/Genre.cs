namespace EntityFramework.Models;
public class Genre
{
    /// <summary>
    /// Идентификатор жанра
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Название жанра
    /// </summary>
    public string Name { get; set; } = null!;

    /// <summary>
    /// Навигационное свойство для связи с книгами
    /// </summary>
    public List<Book> Books { get; set; } = [];
}