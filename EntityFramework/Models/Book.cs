namespace EntityFramework.Models;
public class Book
{
    /// <summary>
    /// Идентификатор книги
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Название книги
    /// </summary>
    public string Title { get; set; } = null!;

    /// <summary>
    /// Год издания книги
    /// </summary>
    public int Year { get; set; }

    /// <summary>
    /// Идентификатор пользователя
    /// </summary>
    public int? UserId { get; set; }

    /// <summary>
    /// Навигационное свойство для связи с пользователем
    /// </summary>
    public User? User { get; set; }

    /// <summary>
    /// Идентификатор автора
    /// </summary>
    public int AuthorId { get; set; }

    /// <summary>
    /// Навигационное свойство для связи с автором
    /// </summary>
    public Author Author { get; set; } = null!;

    /// <summary>
    /// Идентификатор жанра
    /// </summary>
    public int GenreId { get; set; }

    /// <summary>
    /// Навигационное свойство для связи с жанром
    /// </summary>
    public Genre Genre { get; set; } = null!;
}