using System;
using System.Linq;
using AutoMapper;
using WebApi.DBOperations;

namespace WebApi.Application.GenreOperations.Commands.UpdateGenre
{
    public class UpdateGenreCommand
    {
        private readonly IMapper _mapper;
        private readonly BookStoreDbContext _context;
        public int GenreId;
        public UpdateGenreViewModel Model { get; set; }
        public UpdateGenreCommand(IMapper mapper, BookStoreDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public void Handle()
        {
            var genre = _context.Genres.SingleOrDefault(x => x.Id == GenreId);
            if (genre == null)
            {
                throw new InvalidOperationException("Tür Bulunamadı, güncelleme işleminde hata meydana geldi");
            }
            else
            {
                genre.Name = Model.Name != default ? Model.Name : genre.Name;
                genre.IsActive = Model.IsActive != default ? Model.IsActive : genre.IsActive;
                _context.SaveChanges();
            }
        }
    }
    public class UpdateGenreViewModel
    {
        public string Name { get; set; }
        public bool IsActive { get; set; }
    }
}