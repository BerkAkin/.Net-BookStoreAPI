using System;
using System.Data;
using FluentValidation;

namespace WebApi.Application.AuthorOperations.Commands.CreateAuthor
{
    public class CreateAuthorCommandValidator : AbstractValidator<CreateAuthorCommand>
    {
        public CreateAuthorCommandValidator()
        {
            RuleFor(x => x.Model.Name).NotEmpty().MinimumLength(3);
            RuleFor(x => x.Model.Surname).NotEmpty().MinimumLength(3);
            RuleFor(x => x.Model.BirthDate).LessThan(DateTime.Now.Date);
        }
    }
}