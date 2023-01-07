using System.Net;

namespace TravelDiaries.Blog.Command.Core
{
    public class ApiResponse<T> where T : class
    {
        public HttpStatusCode StatusCode { get; set; }

        public string? Message { get; set; }

        public IEnumerable<T>? Results { get; set; }

        public T? Result { get; set; }


        public ApiResponse()
        {
            StatusCode = HttpStatusCode.OK;
        }
    }
}
