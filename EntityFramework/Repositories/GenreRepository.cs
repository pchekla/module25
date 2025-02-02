using EntityFramework.Models;

namespace EntityFramework.Repositories;
public class GenreRepository(AppContext context)
{
    private readonly AppContext _context = context;

    public void Add(Genre genre) { _context.Genres.Add(genre); _context.SaveChanges(); }
}