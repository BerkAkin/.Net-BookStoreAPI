using System.Data;
using FluentValidation;

namespace WebApi.Application.GenreOperations.Queries.GetGenreDetail
{
    public class GetGenresDetailQueryValidator : AbstractValidator<GetGenresDetailQuery>
    {
        public GetGenresDetailQueryValidator()
        {
            RuleFor(query => query.GenreId).GreaterThan(0).NotEmpty().NotNull();
        }
    }
}