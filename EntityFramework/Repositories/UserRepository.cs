using EntityFramework.Models;

namespace EntityFramework.Repositories;

public class UserRepository(AppContext context)
{
    private readonly AppContext _context = context;

    public User? GetById(int id) => _context.Users.FirstOrDefault(u => u.Id == id);
    public List<User> GetAll() => [.. _context.Users];
    public void Add(User user) { _context.Users.Add(user); _context.SaveChanges(); }
    public void Delete(int id)
    {
        var user = GetById(id);
        if (user != null) { _context.Users.Remove(user); _context.SaveChanges(); }
    }
    public void UpdateName(int id, string newName)
    {
        var user = GetById(id);
        if (user != null) { user.Name = newName; _context.SaveChanges(); }
    }
}