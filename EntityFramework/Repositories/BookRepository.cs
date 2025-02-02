using EntityFramework.Models;

namespace EntityFramework.Repositories;
/// <summary>
/// Репозиторий для работы с книгами
/// </summary>
/// <param name="context"></param>
/// <returns></returns>
public class BookRepository(AppContext context)
{
    private readonly AppContext _context = context;

    /// <summary>
    /// Получение книги по id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public Book? GetById(int id) => _context.Books.FirstOrDefault(b => b.Id == id);

    /// <summary>
    /// Получение всех книг
    /// </summary>
    /// <returns></returns>
    public List<Book> GetAll() => [.. _context.Books];

    /// <summary>
    /// Добавление книги
    /// </summary>
    /// <param name="book"></param>
    public void Add(Book book) { _context.Books.Add(book); _context.SaveChanges(); }

    /// <summary>
    /// Удаление книги
    /// </summary>
    /// <param name="id"></param>
    public void Delete(int id)
    {
        var book = GetById(id);
        if (book != null) { _context.Books.Remove(book); _context.SaveChanges(); }
    }

    /// <summary>
    /// Обновление названия книги
    /// </summary>
    /// <param name="userId"></param>
    /// <param name="bookId"></param>
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

        /// <summary>
        /// 1. Получение списка книг по жанру и году
        /// </summary>
        /// <param name="genreId"></param>
        /// <param name="startYear"></param>
        /// <param name="endYear"></param>
        /// <returns></returns>
        public List<Book> GetBooksByGenreAndYearRange(int genreId, int startYear, int endYear)
        {
            return _context.Books.Where(b => b.GenreId == genreId && b.Year >= startYear && b.Year <= endYear).ToList();
        }

        /// <summary>
        /// 2. Получение количества книг по id автора
        /// </summary>
        /// <param name="authorId"></param>
        /// <returns></returns>
        public int GetBookCountByAuthor(int authorId)
        {
            return _context.Books.Count(b => b.AuthorId == authorId);
        }

        /// <summary>
        /// 3. Количество книг определенного жанра
        /// </summary>
        /// <param name="genreId"></param>
        /// <returns></returns>
        public int GetBookCountByGenre(int genreId)
        {
            return _context.Books.Count(b => b.GenreId == genreId);
        }

        /// <summary>
        /// 4. Проверка наличия книги по автору и названию
        /// </summary>
        /// <param name="authorId"></param>
        /// <param name="title"></param>
        /// <returns></returns>
        public bool IsBookAvailableByAuthorAndTitle(int authorId, string title)
        {
            return _context.Books.Any(b => b.AuthorId == authorId && b.Title == title);
        }

        /// <summary>
        /// 5. Проверка, есть ли книга на руках у пользователя
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="bookId"></param>
        /// <returns></returns>
        public bool IsBookBorrowedByUser(int userId, int bookId)
        {
            return _context.Books.Any(b => b.Id == bookId && b.UserId == userId);
        }

        /// <summary>
        /// 6. Количество книг на руках у пользователя
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public int GetBorrowedBookCountByUser(int userId)
        {
            return _context.Books.Count(b => b.UserId == userId);
        }

        /// <summary>
        /// 7. Получение последней вышедшей книги
        /// </summary>
        /// <returns></returns>
        public Book? GetLatestPublishedBook()
        {
            return _context.Books.OrderByDescending(b => b.Year).FirstOrDefault();
        }

        /// <summary>
        /// 8. Список всех книг в алфавитном порядке
        /// </summary>
        /// <returns></returns>
        public List<Book> GetAllBooksSortedByTitle()
        {
            return _context.Books.OrderBy(b => b.Title).ToList();
        }

        /// <summary>
        /// 9. Список всех книг по убыванию года
        /// </summary>
        /// <returns></returns>
        public List<Book> GetAllBooksSortedByYearDesc()
        {
            return _context.Books.OrderByDescending(b => b.Year).ToList();
        }
}