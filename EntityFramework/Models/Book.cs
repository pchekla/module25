namespace EntityFramework.Models;
public class Book
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public int Year { get; set; }
    public int? UserId { get; set; } // Сделаем необязательным, если книга не выдана
    public User? User { get; set; }

    public int AuthorId { get; set; }
    public Author Author { get; set; } = null!;

    public int GenreId { get; set; }
    public Genre Genre { get; set; } = null!;
}