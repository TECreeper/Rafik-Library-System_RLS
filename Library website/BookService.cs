using Microsoft.EntityFrameworkCore;
using MyLibraryApp.Models;

namespace MyLibraryApp.Data
{
    public class BookService
    {

       

private readonly LibraryDbContext _context;

        public BookService(LibraryDbContext context)
        {
            _context = context;
        }

        // Get all books
        public async Task<List<Book>> GetBooksAsync()
        {
            return await _context.Books.ToListAsync();
        }

        // Add a book
        public async Task AddBookAsync(Book book)
        {
            _context.Books.Add(book);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteBookAsync(int id)
        {
            // 1. Find the book by its unique ID
            var book = await _context.Books.FindAsync(id);

            // 2. If found, remove it and save
            if (book != null)
            {
                _context.Books.Remove(book);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<int> GetCountBorrowingAsync(bool Borrowing)
        {
            // "b" represents one book. 
            // We are asking: Count every book WHERE the Category equals the one we passed in.
            return await _context.Books
                                 .CountAsync(b => b.IsBorrowed ==Borrowing);
        }
        public async Task CheckoutBookAsync(int bookId, int memberId)
        {
            var book = await _context.Books.FindAsync(bookId);

            if (book != null)
            {
                book.IsBorrowed = true;
                book.CurrentMemberId = memberId; // Link the member!
                await _context.SaveChangesAsync();
            }
        }
        public async Task<List<Book>> GetAvailableBooksAsync()
        {
            return await _context.Books
                                 .Where(b => b.IsBorrowed == false) // Filter!
                                 .ToListAsync();
        }

        public async Task ReturnBookAsync(int bookId)
        {
            var book = await _context.Books.FindAsync(bookId);

            if (book != null)
            {
                book.IsBorrowed = false;
                book.CurrentMemberId = null; // Remove the link to the member
                await _context.SaveChangesAsync();
            }
        }
        public async Task<string> CheckoutBookAsync(string bookInput, string memberInput, DateTime dueDate)
        {
            // A. Find the Book (Try ID first, then Title/ISBN)
            var book = await _context.Books
                .FirstOrDefaultAsync(b => b.Id.ToString() == bookInput || b.Title == bookInput );

            if (book == null) return "Book not found.";
            if (book.IsBorrowed) return "Book is already borrowed.";

            // B. Find the Member (Try ID first, then Name)
            var member = await _context.Members
                .FirstOrDefaultAsync(m => m.Id.ToString() == memberInput || m.Name == memberInput);

            if (member == null) return "Member not found.";

            // C. Process Transaction
            book.IsBorrowed = true;
            book.CurrentMemberId = member.Id;

            // >>> LOGGING DATES <<<
            book.BorrowDate = DateTime.Now; // Log today as borrow date
            book.DueDate = dueDate;         // Log the selected due date
            book.ReturnDate = null;         // Reset return date

            await _context.SaveChangesAsync();
            return "Success";
        }

        // 2. Return Book with Date Logging
        public async Task<string> ReturnBookAsync(string bookInput)
        {
            var book = await _context.Books
                .FirstOrDefaultAsync(b => b.Id.ToString() == bookInput || b.Title == bookInput );

            if (book == null) return "Book not found.";
            if (!book.IsBorrowed) return "Book is not currently borrowed.";

            // >>> LOGGING DATES <<<
            book.ReturnDate = DateTime.Now; // Log the actual return time

            book.IsBorrowed = false;
            book.CurrentMemberId = null;

            await _context.SaveChangesAsync();
            return "Success";
        }
        public async Task<int> GetTotalBooksAsync()
        {
            return await _context.Books.CountAsync();
        }
    } 
}

