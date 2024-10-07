using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using WebApi.Application.AuthorOperations.Commands.CreateAuthor;
using WebApi.Application.AuthorOperations.Commands.DeleteAuthor;
using WebApi.Application.AuthorOperations.Commands.UpdateAuthor;
using WebApi.Application.AuthorOperations.Queries.GetAuthorDetail;
using WebApi.Application.AuthorOperations.Queries.GetAuthors;
using WebApi.DBOperations;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]s")]
    public class AuthorController : ControllerBase
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;

        public AuthorController(BookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }




        [HttpGet]
        public IActionResult GetAuthor()
        {
            GetAuthorsQuery query = new GetAuthorsQuery(_mapper, _context);
            var result = query.Handle();
            return Ok(result);
        }





        [HttpGet("{id}")]
        public IActionResult GetAuthorById(int id)
        {
            AuthorDetailViewModel result;
            GetAuthorDetailQuery query = new GetAuthorDetailQuery(_mapper, _context);
            query.Id = id;
            result = query.Handle();
            return Ok(result);
        }





        [HttpPost]
        public IActionResult AddAuthor([FromBody] CreateAuthorViewModel author)
        {
            CreateAuthorCommand command = new CreateAuthorCommand(_mapper, _context);
            CreateAuthorCommandValidator validator = new CreateAuthorCommandValidator();
            command.Model = author;
            validator.ValidateAndThrow(command);
            command.Handle();
            return Ok("Ekleme Başarılı");
        }




        [HttpPut("{id}")]
        public IActionResult UpdateAuthor([FromBody] UpdateAuthorViewModel updatedAuthor, int id)
        {
            UpdateAuthorCommand command = new UpdateAuthorCommand(_context, _mapper);
            command.Id = id;
            command.Model = updatedAuthor;
            UpdateAuthorCommandValidator validator = new UpdateAuthorCommandValidator();
            validator.ValidateAndThrow(command);
            command.Handle();
            return Ok("Güncelleme Başarılı");
        }



        [HttpDelete("{id}")]
        public IActionResult DeleteAuthor(int id)
        {
            DeleteAuthorCommand command = new DeleteAuthorCommand(_context);
            command.Id = id;
            command.Handle();
            return Ok("Silme Başarılı");
        }
    }
}
