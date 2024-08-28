using FluentValidation;
using FluentValidation.Results;

using TodoList.Api.Models;

namespace TodoList.Api.Validators;

public class TodoItemValidator : AbstractValidator<TodoItemModel>
{
    public TodoItemValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("{PropertyName} is required");
    }
}
