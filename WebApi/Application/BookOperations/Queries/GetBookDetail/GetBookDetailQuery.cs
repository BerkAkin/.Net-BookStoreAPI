using System;
using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.DBOperations;

namespace WebApi.Application.BookOperations.Queries.GetBooks
{
    public class GetBookDetailQuery
    {
        public BookDetailViewModel model { get; set; }
        public int BookId { get; set; }
        private readonly BookStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        public GetBookDetailQuery(BookStoreDbContext context, IMapper mapper)
        {
            _dbContext = context;
            _mapper = mapper;
        }

        public BookDetailViewModel Handle()
        {
            var book = _dbContext.Books.Include(x => x.Genre).Include(a => a.Author).Where(book => book.Id == BookId).SingleOrDefault();
            if (book is not null)
            {
                BookDetailViewModel vm = _mapper.Map<BookDetailViewModel>(book);
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
        public string Author { get; set; }
    }
}