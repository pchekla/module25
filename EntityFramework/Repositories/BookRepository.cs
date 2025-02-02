using EntityFramework.Models;

namespace EntityFramework.Repositories;

public class BookRepository(AppContext context)
{
    private readonly AppContext _context = context;

    public Book? GetById(int id) => _context.Books.FirstOrDefault(b => b.Id == id);
    public List<Book> GetAll() => [.. _context.Books];
    public void Add(Book book) { _context.Books.Add(book); _context.SaveChanges(); }
    public void Delete(int id)
    {
        var book = GetById(id);
        if (book != null) { _context.Books.Remove(book); _context.SaveChanges(); }
    }
    public void BorrowBook(int userId, int bookId)
    {
        var book = GetById(bookId);
        var user = _context.Users.FirstOrDefault(u => u.Id == userId);

        if (book != null && user != null)
        {
            book.UserId = userId;
            book.User = user;
            _context.SaveChanges();
        }
    }
}