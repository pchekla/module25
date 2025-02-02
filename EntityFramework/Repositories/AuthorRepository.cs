using EntityFramework.Models;

namespace EntityFramework.Repositories;
public class AuthorRepository(AppContext context)
{
    private readonly AppContext _context = context;

    public void Add(Author author) { _context.Authors.Add(author); _context.SaveChanges(); }
}