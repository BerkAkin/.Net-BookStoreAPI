using System;
using System.Linq;
using AutoMapper;
using WebApi.DBOperations;

namespace WebApi.Application.GenreOperations.Queries.GetGenreDetail
{
    public class GetGenresDetailQuery
    {

        public GenreDetailViewModel Model { get; set; }
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;
        public int GenreId { get; set; }

        public GetGenresDetailQuery(BookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public GenreDetailViewModel Handle()
        {
            var genre = _context.Genres.SingleOrDefault(x => x.Id == GenreId && x.IsActive);
            if (genre == null)
            {
                throw new InvalidOperationException("Tür Bulunamadı");
            }
            else
            {
                return _mapper.Map<GenreDetailViewModel>(genre);
            }
        }
    }
    public class GenreDetailViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }


}