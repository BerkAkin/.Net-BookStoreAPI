using System.Collections.Generic;
using AutoMapper;
using WebApi.Application.BookOperations.Commands.CreateBook;
using WebApi.Application.BookOperations.Queries.GetBooks;
using WebApi.Application.GenreOperations.Queries.GetGenres;
using WebApi.Application.GenreOperations.Queries.GetGenreDetail;
using WebApi.Entities;
using WebApi.Application.GenreOperations.Commands.CreateGenre;
namespace WebApi.Common
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Book, BookDetailViewModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => ((GenreEnum)src.GenreId).ToString()));
            CreateMap<Book, BooksViewModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => ((GenreEnum)src.GenreId).ToString()));
            CreateMap<CreateBookModel, Book>();

            CreateMap<Genre, GenresViewModel>();
            CreateMap<Genre, GenreDetailViewModel>();
        }
    }
}