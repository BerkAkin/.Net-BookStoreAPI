using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using WebApi.BookOperations.CreateBook;
using WebApi.BookOperations.GetBooks;
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
        public IActionResult GetBooks()
        {
            GetBooksQuery query = new GetBooksQuery(_context);
            var result = query.Handle();
            return Ok(result);
        }

        [HttpGet("{Id}")]
        public Book GetBooksById(int Id)
        {
            var book = _context.Books.Where(book => book.Id == Id).SingleOrDefault();
            return book;
        }


        //Post ve Put Örnekleri

        //Book'un kalıbına uygun bir json gelmeli front-end tarafından body bilgisi olarak gelecek bu sayede otomatik olarak requesti alacak ve işlemleri yapacak
        [HttpPost]
        public IActionResult AddBook([FromBody] CreateBookModel newBook)
        {
            try
            {
                CreateBookCommand command = new CreateBookCommand(_context);
                command.Model = newBook;
                command.Handle();
                return Ok("Kitap Eklendi");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
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
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
    }
}