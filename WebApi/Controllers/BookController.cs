using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using WebApi.DBOperations;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]s")]
    public class BookController : ControllerBase
    {
        private readonly BookStoreDbContext _context;
        public BookController(BookStoreDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public List<Book> GetBooks()
        {
            var bookList = _context.Books.OrderBy(x => x.Id).ToList<Book>();
            return bookList;
        }

        [HttpGet("{Id}")]
        public Book GetBooksById(int Id)
        {
            var book = _context.Books.Where(book => book.Id == Id).SingleOrDefault();
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

        //Post ve Put Örnekleri

        //Book'un kalıbına uygun bir json gelmeli front-end tarafından body bilgisi olarak gelecek bu sayede otomatik olarak requesti alacak ve işlemleri yapacak
        [HttpPost]
        public IActionResult AddBook([FromBody] Book newBook)
        {
            var book = _context.Books.SingleOrDefault(x => x.Title == newBook.Title);
            if (book is not null)
            {
                return BadRequest();
            }
            else
            {
                _context.Books.Add(newBook);
                _context.SaveChanges();
                return Ok();
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id, [FromBody] Book updatedBook)
        {
            var book = _context.Books.SingleOrDefault(x => x.Id == id);
            if (book is not null)
            {
                book.Title = updatedBook.Title != default ? updatedBook.Title : book.Title;
                book.Author = updatedBook.Author != default ? updatedBook.Author : book.Author;
                book.PublishDate = updatedBook.PublishDate != default ? updatedBook.PublishDate : book.PublishDate;
                book.GenreId = updatedBook.GenreId != default ? updatedBook.GenreId : book.GenreId;
                book.PageCount = updatedBook.PageCount != default ? updatedBook.PageCount : book.PageCount;
                _context.SaveChanges();
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {
            var book = _context.Books.SingleOrDefault(x => x.Id == id);
            if (book is not null)
            {
                _context.Books.Remove(book);
                _context.SaveChanges();
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
    }
}