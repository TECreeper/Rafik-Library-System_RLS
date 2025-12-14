using System.Security.Cryptography;
using System.Text;
using Microsoft.EntityFrameworkCore;
using MyLibraryApp.Models;

namespace MyLibraryApp.Data
{
    public class UserService
    {
        private readonly LibraryDbContext _context;

        public UserService(LibraryDbContext context)
        {
            _context = context;
        }

        // 1. دالة تسجيل حساب جديد
        public async Task<string> RegisterUserAsync(User user)
        {
            // نتأكد أولاً أن الإيميل غير مستخدم من قبل
            if (await _context.Users.AnyAsync(u => u.Email == user.Email))
            {
                return "This email is already registered.";
            }

            // نشفر الباسوورد قبل الحفظ
            user.Password = HashPassword(user.Password);

            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return "Success";
        }

        // 2. دالة تسجيل الدخول
        public async Task<User?> LoginUserAsync(string email, string password)
        {
            // نشفر الباسوورد المدخل لنقارنه بالمحفوظ في الداتا بيز
            string hashedPassword = HashPassword(password);

            // نبحث عن مستخدم يطابق الإيميل والباسوورد المشفر
            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.Email == email && u.Password == hashedPassword);

            return user;
        }

        // دالة التشفير (تمنع قراءة الباسوورد لو تم سرقة الداتا بيز)
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