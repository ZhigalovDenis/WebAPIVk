using WebAPIVk.Data;
using WebAPIVk.Models;

namespace WebAPIVk.Repositories
{
    public class LetterFromPostRepository : IBaseRepository<LetterFromPost>
    {

        private readonly ApplicationDbContext _db;
        public LetterFromPostRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<LetterFromPost> Insert(LetterFromPost entity)
        {
            await _db.LetterFromPosts.AddAsync(entity);
            return entity;
        }

        public async Task Save()
        {
            await _db.SaveChangesAsync();
        }
    }
}
