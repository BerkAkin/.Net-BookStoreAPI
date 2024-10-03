using System;
using System.Linq;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using WebApi.Application.BookOperations.Queries.GetBooks;
using WebApi.DBOperations;

namespace WebApi.Application.BookOperations.Commands.UpdateBook
{
    public class UpdateBookCommand
    {
        private readonly BookStoreDbContext _dbContext;
        public int BookId;
        public UpdateBookModel Model { get; set; }
        public UpdateBookCommand(BookStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Handle()
        {
            var book = _dbContext.Books.SingleOrDefault(x => x.Id == BookId);
            if (book is not null)
            {
                book.Title = Model.Title != default ? Model.Title : book.Title;
                book.GenreId = Model.GenreId != default ? Model.GenreId : book.GenreId;
                _dbContext.SaveChanges();
            }
            else
            {
                throw new InvalidOperationException("Kitap bulunamadı. Güncelleme İşleminde Hata Oldu");
            }
        }


    }

    public class UpdateBookModel
    {
        public string Title { get; set; }
        public int GenreId { get; set; }
    }
}