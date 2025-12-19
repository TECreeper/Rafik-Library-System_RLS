using System.ComponentModel.DataAnnotations;

namespace MyLibraryApp.Models
{
    public class Book
    {
        public int Id { get; set; } // Primary Key
        public string Title { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;

        public int Price { get; set; }
        public bool IsBorrowed { get; set; }
        public DateTime? BorrowDate { get; set; } // When it was issued
        public DateTime? DueDate { get; set; }    // When it should be back
        public DateTime? ReturnDate { get; set; } // Log when it was actually returned
        public string Categyry { get; set; } = string.Empty;
        public int? CurrentMemberId { get; set; }
    }

    public class Member
    {
        public int Id { get; set; }

        
        public string NationalId { get; set; }

        public string Name { get; set; } = string.Empty;
        public bool IsBorrowing { get; set; }
        public int Age { get; set; }
        public string MobileNumber { get; set; } = string.Empty;
     
        public string Email { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
    }
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required] // مطلوب
        public string FullName { get; set; } = "";

        [Required]
        [EmailAddress] // يجب أن يكون صيغة إيميل صحيحة
        public string Email { get; set; } = "";

        [Required]
        public string Password { get; set; } = ""; // سيتم حفظها مشفرة وليست نصاً عادياً

        public string Role { get; set; } = "Admin"; // لتحديد الصلاحيات مستقبلاً
    }
}

