namespace MyLibraryApp.Models
{
    public class Book
    {
        public int Id { get; set; } // Primary Key
        public string Title { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public int Price { get; set; }
        public bool IsBorrowed { get; set; }

        public string Categyry { get; set; } = string.Empty;
    }

    public class Member
    {
        public int Id { get; set; }

        // National IDs can be long and may include leading zeros — use string.
        public int NationalId { get; set; }

        public string Name { get; set; } = string.Empty;
        public bool IsBorrowing { get; set; }
        public int Age { get; set; }
        public string MobileNumber { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
    }
}

