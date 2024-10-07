using System;
using System.Linq;
using AutoMapper;
using WebApi.DBOperations;

namespace WebApi.Application.GenreOperations.Commands.UpdateGenre
{
    public class UpdateGenreCommand
    {
        private readonly IMapper _mapper;
        private readonly IBookStoreDbContext _context;
        public int GenreId;
        public UpdateGenreViewModel Model { get; set; }
        public UpdateGenreCommand(IMapper mapper, IBookStoreDbContext context)
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
            if (_context.Genres.Any(x => x.Name.ToLower() == Model.Name.ToLower() && x.Id != GenreId))
            {
                throw new InvalidOperationException("Aynı isimli bir tür var");
            }

            genre.Name = Model.Name.Trim() != default ? Model.Name : genre.Name;
            genre.IsActive = Model.IsActive;
            _context.SaveChanges();
        }
    }
    public class UpdateGenreViewModel
    {
        public string Name { get; set; }
        public bool IsActive { get; set; } = true;
    }
}