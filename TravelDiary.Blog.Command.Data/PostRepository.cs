using Microsoft.EntityFrameworkCore;
using TravelDiaries.Blog.Command.Data;

namespace TravelDiary.Blog.Command.Data
{
    public class PostRepository : IPostRepository
    {
        private TravelDiaryContext _context;

        public PostRepository(TravelDiaryContext context)
        {
            _context = context;
        }

        public async Task<Guid> Create(Post post, CancellationToken cancellationToken)
        {
            var result = await _context.Set<Post>().AddAsync(post, cancellationToken);
            await _context.SaveChangesAsync();
            return result.Entity.Id;
        }

        public async Task<Post> GetById(Guid id, CancellationToken cancellationToken)
        {
            var result = await _context.Set<Post>().Where(x => x.Id == id).SingleOrDefaultAsync(cancellationToken);
            return result;
        }

        public async Task<bool> Update(Post post, CancellationToken cancellationToken)
        {
            try
            {
                _context.Set<Post>().Update(post);
                await _context.SaveChangesAsync(cancellationToken);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
