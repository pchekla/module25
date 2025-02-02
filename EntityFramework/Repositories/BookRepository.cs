using EntityFramework.Models;

namespace EntityFramework.Repositories;

public class BookRepository(AppContext context)
{
    private readonly AppContext _context = context;

    public Book? GetById(int id)
        {
            return _context.Books.FirstOrDefault(b => b.Id == id);
        }

    public List<Book> GetAll()
    {
        return [.. _context.Books];
    }

    public void Add(Book book)
    {
        _context.Books.Add(book);
        _context.SaveChanges();
    }

    public void Delete(int id)
    {
        var book = GetById(id);
        if (book != null)
        {
            _context.Books.Remove(book);
            _context.SaveChanges();
        }
    }

    public void UpdateYear(int id, int newYear)
    {
        var book = GetById(id);
        if (book != null)
        {
            book.Year = newYear;
            _context.SaveChanges();
        }
    }
}