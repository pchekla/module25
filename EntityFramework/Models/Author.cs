namespace EntityFramework.Models;
public class Author
{
    /// <summary>
    /// Идентификатор автора
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Имя автора
    /// </summary>
    public string Name { get; set; } = null!;

    /// <summary>
    /// Навигационное свойство для связи с книгами
    /// </summary>
    public List<Book> Books { get; set; } = [];
}