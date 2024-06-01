
using System.Linq.Expressions;
using FluentValidation;

namespace Pajophone.Models.Validator;

public class ProductValidator : AbstractValidator<ProductModel>
{
    public ProductValidator()
    {
        BasicValidator<String>(p => p.Name);
        BasicValidator<String>(p => p.Description);
        BasicValidator<String>(p => p.Color);
        BasicValidator<byte[]>(p => p.Image);
    }

    private void BasicValidator<T>(Expression<Func<ProductModel,T>> expression)
    {
        RuleFor(expression)
            .NotEmpty().WithMessage($"{((MemberExpression)expression.Body).Member.Name} Cannot be Empty")
            .NotNull().WithMessage($"{((MemberExpression)expression.Body).Member.Name} Cannot be Null");
    }
}