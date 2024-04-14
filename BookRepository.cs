using Microsoft.EntityFrameworkCore;
using Quipu_task.Models;

namespace Quipu_task
{
    // Persistence Layer

    // Interface for Book repository
    public interface IBookRepository
    {
        Task<int> AddAsync(Book book);
        Task<Book> GetByIdAsync(int id);
        Task<List<Book>> GetAllAsync();
        Task UpdateAsync(Book book);
        Task DeleteAsync(Book book);
    }

    // EF Core implementation of Book repository
    public class BookRepository : IBookRepository
    {
        private readonly QuipuDbContext _context;

        public BookRepository(QuipuDbContext context)
        {
            _context = context;
        }

        public async Task<int> AddAsync(Book book)
        {
            _context.Books.Add(book);
            await _context.SaveChangesAsync();
            return book.BookId;
        }

        public async Task<Book> GetByIdAsync(int id)
        {
            return await _context.Books.FindAsync(id);
        }

        public async Task<List<Book>> GetAllAsync()
        {
            return await _context.Books.ToListAsync();
        }

        public async Task UpdateAsync(Book book)
        {
            _context.Entry(book).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Book book)
        {
            _context.Books.Remove(book);
            await _context.SaveChangesAsync();
        }
    }
}
