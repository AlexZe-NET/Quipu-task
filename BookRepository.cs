using Quipu_task.Models;

namespace Quipu_task
{
    // Persistence Layer

    // Interface for Book repository
    public interface IBookRepository
    {
        Task<int> AddAsync(Book book);
        Task<Book> GetByIdAsync(int id);
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
    }
}
