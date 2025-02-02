using EntityFramework.Models;

namespace EntityFramework.Repositories;

public class UserRepository(AppContext context)
{
    private readonly AppContext _context = context;

    /// <summary>
    /// Получение пользователя по id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public User? GetById(int id) => _context.Users.FirstOrDefault(u => u.Id == id);

    /// <summary>
    /// Получение всех пользователей
    /// </summary>
    /// <returns></returns>
    public List<User> GetAll() => [.. _context.Users];

    /// <summary>
    /// Добавление пользователя
    /// </summary>
    /// <param name="user"></param>
    public void Add(User user) { _context.Users.Add(user); _context.SaveChanges(); }

    /// <summary>
    /// Удаление пользователя
    /// </summary>
    /// <param name="id"></param>
    public void Delete(int id)
    {
        var user = GetById(id);
        if (user != null) { _context.Users.Remove(user); _context.SaveChanges(); }
    }

    /// <summary>
    /// Обновление имени пользователя
    /// </summary>
    /// <param name="id"></param>
    /// <param name="newName"></param>
    public void UpdateName(int id, string newName)
    {
        var user = GetById(id);
        if (user != null) { user.Name = newName; _context.SaveChanges(); }
    }
}