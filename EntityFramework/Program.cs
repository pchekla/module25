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
            Console.WriteLine("Пользователи:");
            int userCounter = 1;
            foreach (var u in users)
            {
                Console.WriteLine($"{userCounter++}. {u.Name}, Email: {u.Email}");
            }

            Console.WriteLine("\nКниги:");
            var books = db.Books.ToList();
            int bookCounter = 1;

            foreach (var book in books)
            {
                Console.WriteLine($"{bookCounter++}. {book.Title} ({book.Year})");
            }
        }

    }
}