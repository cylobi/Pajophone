
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Pajophone.Utils;

public static class ValidatorExtentions
{
    public static void AddToModelState(this ValidationResult result, ModelStateDictionary modelState) 
    {
        foreach (var error in result.Errors) 
        {
            modelState.AddModelError(error.PropertyName, error.ErrorMessage);
        }
    }
}