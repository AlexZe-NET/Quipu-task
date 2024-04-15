using Microsoft.EntityFrameworkCore;
using Quipu_task.Models;

namespace Quipu_task
{
    public interface IAuthorRepository
    {
        Task<int> AddAsync(Author author);
        Task UpdateAsync(Author author);
        Task DeleteAsync(Author author);
        Task<Author> GetByIdAsync(int id);
        Task<List<Author>> GetAllAsync();
    }
    public class AuthorRepository : IAuthorRepository
    {
        private readonly QuipuDbContext _context;

        public AuthorRepository(QuipuDbContext context)
        {
            _context = context;
        }

        public async Task<int> AddAsync(Author author)
        {
            _context.Authors.Add(author);
            await _context.SaveChangesAsync();
            return author.AuthorId;
        }

        public async Task UpdateAsync(Author author)
        {
            _context.Authors.Update(author);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Author author)
        {
            _context.Authors.Remove(author);
            await _context.SaveChangesAsync();
        }

        public async Task<Author> GetByIdAsync(int id)
        {
            return await _context.Authors.FindAsync(id);
        }

        public async Task<List<Author>> GetAllAsync()
        {
            return await _context.Authors.ToListAsync();
        }
    }
}
