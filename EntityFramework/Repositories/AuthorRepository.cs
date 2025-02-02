using EntityFramework.Models;

namespace EntityFramework.Repositories;
/// <summary>
/// Репозиторий для работы с авторами
/// </summary>
/// <param name="context"></param>
public class AuthorRepository(AppContext context)
{
    private readonly AppContext _context = context;

    /// <summary>
    /// Получение автора по id
    /// </summary>
    /// <param name="id"></param>
    public void Add(Author author) { _context.Authors.Add(author); _context.SaveChanges(); }
}