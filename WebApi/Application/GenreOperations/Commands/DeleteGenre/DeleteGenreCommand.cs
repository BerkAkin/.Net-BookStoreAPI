using System;
using System.Linq;
using WebApi.DBOperations;

namespace WebApi.Application.GenreOperations.Commands.DeleteGenre
{
    public class DeleteGenreCommand
    {
        private readonly BookStoreDbContext _context;
        public int GenreId { get; set; }

        public DeleteGenreCommand(BookStoreDbContext context)
        {
            _context = context;
        }

        public void Handle()
        {
            var genre = _context.Genres.Where(x => x.Id == GenreId).FirstOrDefault();
            if (genre == null)
            {
                throw new InvalidOperationException("Tür Bulunamadı, silme başarısız");
            }
            else
            {
                _context.Genres.Remove(genre);
                _context.SaveChanges();
            }
        }
    }
}