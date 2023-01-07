using TravelDiaries.Blog.Command.Core.DTOs;
using TravelDiaries.Blog.Command.Data;

namespace TravelDiary.Blog.Command.Data
{
    public interface IPostRepository
    {

        Task<Guid> Create(Post post, CancellationToken cancellationToken);

        Task<Post> GetById(Guid id, CancellationToken cancellationToken);

        Task<bool> Update(Post post, CancellationToken cancellationToken);
    }
}
