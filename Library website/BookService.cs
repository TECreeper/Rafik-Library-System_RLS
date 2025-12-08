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
        public async Task<int> GetTotalBooksAsync()
        {
            return await _context.Books.CountAsync();
        }
    } 
}

