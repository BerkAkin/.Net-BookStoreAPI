using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]s")]
    public class BookController : ControllerBase
    {
        private static List<Book> BookList = new List<Book>(){
            new Book{
                Id=1,
                Title="Lean Startup",
                GenreId=1,
                PageCount=200, //Personal Growth
                PublishDate = new DateTime(2001,09,02),
                Author="Berk Akın"
            },
            new Book{
                Id=2,
                Title="Chess",
                GenreId=3, //Drama
                PageCount=102,
                PublishDate = new DateTime(1980,06,12),
                Author="Stefan Zweig"
            },
            new Book{
                Id=3,
                Title="Dune",
                GenreId=3, //Sci-fi
                PageCount=540,
                PublishDate = new DateTime(2045,02,22),
                Author="Stefan Zweig"
            },
        };

        [HttpGet]
        public List<Book> GetBooks()
        {
            var bookList = BookList.OrderBy(x => x.Id).ToList<Book>();
            return bookList;
        }

        [HttpGet("{Id}")]
        public Book GetBooksById(int Id)
        {
            var book = BookList.Where(book => book.Id == Id).SingleOrDefault();
            return book;
        }

        /*    ROUTE'TAN ALIR ID BİLGİSİNİ
                [HttpGet]
                public Book Get([FromQuery] string Id)
                {
                    var book = BookList.Where(book => book.Id == Convert.ToInt32(Id)).SingleOrDefault();
                    return book;
                } 
        */
    }
}