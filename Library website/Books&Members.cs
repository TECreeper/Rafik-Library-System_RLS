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

            public int NationalId { get; set; }
           public string Name { get; set; } = string.Empty;
            public bool IsBorrowing { get; set; }
            public int Age { get; set; }
            public string MobileNumber { get; set; }
            public string Email { get; set; }
        public string Role { get; set; }

    }
}

