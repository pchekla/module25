using EntityFramework.Models;
using EntityFramework.Repositories;

namespace EntityFramework;
class Program
{
    static void Main(string[] args)
    {
        using (var db = new AppContext())
        {
            db.Database.EnsureDeleted();
            db.Database.EnsureCreated();
            var userRepository = new UserRepository(db);
            var bookRepository = new BookRepository(db);
            var authorRepository = new AuthorRepository(db);
            var genreRepository = new GenreRepository(db);

            ///summary
            ///Добавление автора
            ///summary
            ///param name="Stephen King "
            var author = new Author { Name = "Stephen King " };
            authorRepository.Add(author);

            ///summary
            ///Добавление жанра
            ///summary
            ///param name="Horror"
            var genre = new Genre { Name = "Horror" };
            genreRepository.Add(genre);

            ///summary
            ///Добавление пользователя
            ///summary
            ///param name="Vik Tor"
            var user = new User { Name = "Vik Tor", Email = "vik@example.com" };
            userRepository.Add(user);

            ///summary
            ///Добавление книги
            ///summary
            ///param Title="Shining"
            ///param Year="1977"
            var book = new Book { Title = "Shining", Year = 1977, Author = author, Genre = genre };
            bookRepository.Add(book);

            ///summary
            ///Взять книгу
            ///summary
            ///param user.Id
            ///param book.Id
            bookRepository.BorrowBook(user.Id, book.Id);
        }
    }
}