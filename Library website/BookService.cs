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
        public async Task<int> GetTotalBooksAsync()
        {
            return await _context.Books.CountAsync();
        }
    } 
}

