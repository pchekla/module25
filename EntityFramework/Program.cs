using EntityFramework.Models;

namespace EntityFramework;
class Program
{
    static void Main(string[] args)
    {
        using (var db = new AppContext())
        {
            // Добавление пользователя
            var user = new User { Name = "Bob", Email = "bob@example.com" };
            db.Users.Add(user);
            db.SaveChanges();

            // Добавление книги
            var book1 = new Book { Title = "VS Code 2025", Year = 2025, UserId = user.Id };
            var book2 = new Book { Title = "Entity Framework Core", Year = 2022, UserId = user.Id };

            db.Books.AddRange(book1, book2);
            db.SaveChanges();

            // Вывод данных
            var users = db.Users.ToList();
            foreach (var u in users)
            {
                Console.WriteLine($"Пользователь: {u.Name}, Email: {u.Email}");

                var books = db.Books.Where(b => b.UserId == u.Id).ToList();
                foreach (var book in books)
                {
                    Console.WriteLine($" - Книга: {book.Title} ({book.Year})");
                }
            }
        }

    }
}