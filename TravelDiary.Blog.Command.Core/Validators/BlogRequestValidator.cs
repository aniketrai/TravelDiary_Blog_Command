using FluentValidation;
using TravelDiaries.Blog.Command.Core.DTOs;

namespace TravelDiary.Blog.Command.Core.Validators
{
    public class BlogRequestValidator : AbstractValidator<BlogRequest>
    {


        public BlogRequestValidator()
        {
            RuleFor(blog => blog.Title)
                .NotNull()
                .NotEmpty()
                .WithMessage("Please ensure title is not empty")
                .MinimumLength(5)
                .WithMessage("Please ensure title is minimum 10 characters");
            RuleFor(blog => blog.HtmlTemplete)
                .NotNull()
                .NotEmpty()
                .MinimumLength(5)
                .WithMessage("Please ensure title is minimum 10 characters"); ;
        }
    }
}
