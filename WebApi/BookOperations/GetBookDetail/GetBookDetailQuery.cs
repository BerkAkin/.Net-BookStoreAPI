using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
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
        private readonly IMapper _mapper;
        public GetBookDetailQuery(BookStoreDbContext context, IMapper mapper)
        {
            _dbContext = context;
            _mapper = mapper;
        }

        public BookDetailViewModel Handle()
        {
            var book = _dbContext.Books.Where(book => book.Id == BookId).SingleOrDefault();
            if (book is not null)
            {
                BookDetailViewModel vm = _mapper.Map<BookDetailViewModel>(book);
                /*  
                    new BookDetailViewModel();   
                    vm.Title = book.Title;
                    vm.PublishDate = book.PublishDate.ToString("dd/MM/yyyy");
                    vm.PageCount = book.PageCount;
                    vm.Genre = ((GenreEnum)book.GenreId).ToString(); 
                */
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