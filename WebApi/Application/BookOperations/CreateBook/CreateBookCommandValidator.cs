using System;
using FluentValidation;

namespace WebApi.Application.BookOperations.CreateBook
{
    public class CreateBookCommandValidator : AbstractValidator<CreateBookCommand>
    {
        public CreateBookCommandValidator()
        {
            RuleFor(command => command.Model.GenreId).GreaterThan(0).NotEmpty().NotNull();
            RuleFor(command => command.Model.PageCount).GreaterThan(0).NotEmpty().NotNull();
            RuleFor(command => command.Model.PublishDate.Date).NotEmpty().NotNull().LessThan(DateTime.Now.Date);
            RuleFor(command => command.Model.Title).NotEmpty().NotNull().MinimumLength(4);
        }
    }
}