using EntityFramework.Models;
using EntityFramework.Repositories;

namespace EntityFramework;
class Program
{
    static void Main(string[] args)
    {
        using (var db = new AppContext())
        {
            var userRepository = new UserRepository(db);
            var bookRepository = new BookRepository(db);
            var authorRepository = new AuthorRepository(db);
            var genreRepository = new GenreRepository(db);

            // Добавление данных
            var author = new Author { Name = "George Orwell" };
            authorRepository.Add(author);

            var genre = new Genre { Name = "Dystopian" };
            genreRepository.Add(genre);

            var user = new User { Name = "John Doe", Email = "john@example.com" };
            userRepository.Add(user);

            var book = new Book { Title = "1984", Year = 1949, Author = author, Genre = genre };
            bookRepository.Add(book);

            // Взятие книги на руки
            bookRepository.BorrowBook(user.Id, book.Id);
        }
    }
}