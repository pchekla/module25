using EntityFramework.Models;

namespace EntityFramework.Repositories;
public class GenreRepository(AppContext context)
{
    private readonly AppContext _context = context;

    /// <summary>
    /// Получение жанра по id
    /// </summary>
    /// <param name="genre"></param>
    public void Add(Genre genre) { _context.Genres.Add(genre); _context.SaveChanges(); }
}