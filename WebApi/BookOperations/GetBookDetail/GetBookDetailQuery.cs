using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using WebApi.Common;
using WebApi.DBOperations;

namespace WebApi.BookOperations.GetBooks
{
    public class GetBookDetailQuery
    {
        public BookDetailViewModel model { get; set; }
        public int BookId { get; set; }
        private readonly BookStoreDbContext _dbContext;
        public GetBookDetailQuery(BookStoreDbContext context)
        {
            _dbContext = context;
        }

        public BookDetailViewModel Handle()
        {
            var book = _dbContext.Books.Where(book => book.Id == BookId).SingleOrDefault();
            if (book is not null)
            {
                BookDetailViewModel vm = new BookDetailViewModel();
                vm.Title = book.Title;
                vm.PublishDate = book.PublishDate.ToString("dd/MM/yyyy");
                vm.PageCount = book.PageCount;
                vm.Genre = ((GenreEnum)book.GenreId).ToString();
                return vm;
            }
            else
            {
                throw new InvalidOperationException("Kitap Bulunamadı");
            }

        }

    }

    public class BookDetailViewModel
    {
        public string Title { get; set; }
        public int PageCount { get; set; }
        public string PublishDate { get; set; }
        public string Genre { get; set; }
    }
}