using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace TravelDiary.Blog.Command.Core.Extensions
{
    public static class ModelStateExtension
    {
        public static void AddToModelState(this ValidationResult result, ModelStateDictionary modelState)
        {
            foreach (var error in result.Errors)
            {
                modelState.AddModelError(error.PropertyName, error.ErrorMessage);
            }
        }
    }

}
