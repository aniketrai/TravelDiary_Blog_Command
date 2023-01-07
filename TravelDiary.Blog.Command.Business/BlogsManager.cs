using System.Net;
using TravelDiaries.Blog.Command.Business.Interface;
using TravelDiaries.Blog.Command.Core;
using TravelDiaries.Blog.Command.Core.DTOs;
using TravelDiaries.Blog.Command.Data;
using TravelDiary.Blog.Command.Data;

namespace TravelDiaries.Blog.Command.Business
{
    public class BlogsManager : IBlogsManager
    {
        private IPostRepository _repository;

        public BlogsManager(IPostRepository repositroy)
        {
            _repository = repositroy;
        }

        public async Task<ApiResponse<BlogResponse>> CreateBlog(BlogRequest blogRequest, CancellationToken cancellationToken)
        {
            var post = new Post() { Title = blogRequest.Title, HtmlTemplete = blogRequest.HtmlTemplete, CreatedBy = "Admin", CreatedOn = DateTime.Now, };

            var id = await _repository.Create(post, cancellationToken);

            var response = new ApiResponse<BlogResponse>();

            if (Guid.Empty.Equals(id))
            {
                response.Message = "Error occurred while submitting the post.";
                response.StatusCode = HttpStatusCode.BadRequest;

            }

            response.Result = new BlogResponse(id, blogRequest.Title, blogRequest.HtmlTemplete);
            response.Message = "Submitted post successfully";
            response.StatusCode = HttpStatusCode.Created;

            return response;
        }

        public async Task<ApiResponse<BlogResponse>> UpdateBlog(Guid id, BlogRequest blogRequest, CancellationToken cancellationToken)
        {
            if (Guid.Empty.Equals(id))
            {
                throw new ArgumentException($"Blog {nameof(id)} is not valid.");
            }

            var blog = await _repository.GetById(id, cancellationToken);

            if (blog == null)
            {
                return new ApiResponse<BlogResponse>()
                {
                    Message = "Blog does not exists",
                    StatusCode = HttpStatusCode.BadRequest
                };
            }


            blog.HtmlTemplete = blogRequest.HtmlTemplete;
            blog.Title = blogRequest.Title;
            blog.UpdatedOn = DateTime.Now;
            blog.UpdatedBy = "Admin";


            var result = await _repository.Update(blog, cancellationToken);


            if (result)
            {
                return new ApiResponse<BlogResponse>()
                {
                    StatusCode = HttpStatusCode.NoContent
                };
            }

            return new ApiResponse<BlogResponse>()
            {
                StatusCode = HttpStatusCode.BadRequest,
                Message = "Update failed."
            };


        }

        public async Task<ApiResponse<BlogResponse>> GetById(Guid id, CancellationToken cancellationToken)
        {
            if (Guid.Empty.Equals(id))
            {
                throw new ArgumentException($"Blog {nameof(id)} is not valid.");
            }

            var blog = await _repository.GetById(id, cancellationToken);

            if (blog == null)
            {
                return new ApiResponse<BlogResponse>()
                {
                    Message = "Blog does not exists",
                    StatusCode = HttpStatusCode.NotFound
                };
            }

            var result = new BlogResponse(blog.Title, blog.HtmlTemplete);

            return new ApiResponse<BlogResponse>()
            {
                StatusCode = HttpStatusCode.OK,
                Result = result
            };

        }

    }
}
