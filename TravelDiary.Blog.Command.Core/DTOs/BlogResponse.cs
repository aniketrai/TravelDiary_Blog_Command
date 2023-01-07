using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelDiaries.Blog.Command.Core.DTOs
{
    public class BlogResponse
    {
        public Guid Id { get; }
        public string Title { get; }

        public string HtmlTemplete { get; }


        public BlogResponse(Guid id, string title, string htmlTemplate)
        {
            Id = id;
            Title = title;
            HtmlTemplete = htmlTemplate;
        }

        public BlogResponse(string title, string htmlTemplate)
        {
            Title = title;
            HtmlTemplete = htmlTemplate;
        }
    }
}
