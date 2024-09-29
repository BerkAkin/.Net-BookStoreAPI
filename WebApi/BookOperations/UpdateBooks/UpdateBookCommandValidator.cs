using FluentValidation;
using WebApi.BookOperations.UpdateBook;
using System;

namespace WebApi.BookOperations.UpdateBooks
{
    public class UpdateBookCommandValidator : AbstractValidator<UpdateBookCommand>
    {
        public UpdateBookCommandValidator()
        {
            RuleFor(command => command.Model.Title).NotEmpty().MinimumLength(4).NotNull();
            RuleFor(command => command.Model.GenreId).NotEmpty().GreaterThan(-1);
        }
    }
}