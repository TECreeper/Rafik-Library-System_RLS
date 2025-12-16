using System.Security.Cryptography;
using System.Text;
using Microsoft.EntityFrameworkCore;
using MyLibraryApp.Models;

namespace MyLibraryApp.Data
{
    public class UserService
    {
        private readonly LibraryDbContext _context;

        // 1. خاصية لتخزين المستخدم المسجل دخوله حالياً
        public User? CurrentUser { get; private set; }

        public UserService(LibraryDbContext context)
        {
            _context = context;
        }

        public async Task<string> RegisterUserAsync(User user)
        {
            if (await _context.Users.AnyAsync(u => u.Email == user.Email))
            {
                return "This email is already registered.";
            }

            user.Password = HashPassword(user.Password);
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return "Success";
        }

        public async Task<User?> LoginUserAsync(string email, string password)
        {
            string hashedPassword = HashPassword(password);

            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.Email == email && u.Password == hashedPassword);

            // 2. إذا نجح الدخول، احفظ المستخدم في المتغير
            if (user != null)
            {
                CurrentUser = user;
            }

            return user;
        }
        public async Task<User?> GetUserByIdAsync(int id)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
        }

        // دالة للخروج
        public void Logout()
        {
            CurrentUser = null;
        }

        private string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return Convert.ToBase64String(bytes);
            }

        }
    }
}