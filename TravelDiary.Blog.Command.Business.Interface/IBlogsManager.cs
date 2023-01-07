using TravelDiaries.Blog.Command.Core;
using TravelDiaries.Blog.Command.Core.DTOs;
using TravelDiaries.Blog.Command.Data;

namespace TravelDiaries.Blog.Command.Business.Interface
{
    public interface IBlogsManager
    {

        /// <summary>
        /// Method to submit/upload blog for approval.
        /// </summary>
        /// <param name="blogRequest"></param>
        /// <returns></returns>
        public Task<ApiResponse<BlogResponse>> CreateBlog(BlogRequest blogRequest, CancellationToken cancellationToken);


        Task<ApiResponse<BlogResponse>> UpdateBlog(Guid id, BlogRequest blogRequest, CancellationToken cancellationToken);

        Task<ApiResponse<BlogResponse>> GetById(Guid id, CancellationToken cancellationToken);
    }
}
