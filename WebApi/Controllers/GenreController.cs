using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using WebApi.Application.GenreOperations.Commands.CreateGenre;
using WebApi.Application.GenreOperations.Commands.DeleteGenre;
using WebApi.Application.GenreOperations.Commands.UpdateGenre;
using WebApi.Application.GenreOperations.Queries.GetGenreDetail;
using WebApi.Application.GenreOperations.Queries.GetGenres;
using WebApi.DBOperations;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]s")]
    public class GenreController : ControllerBase
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;
        public GenreController(BookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }



        [HttpGet]
        public ActionResult GetGenres()
        {
            GetGenresQuery query = new GetGenresQuery(_context, _mapper);
            var obj = query.Handle();
            return Ok(obj);
        }





        [HttpGet("{id}")]
        public ActionResult GetGenreById(int id)
        {
            GetGenresDetailQuery query = new GetGenresDetailQuery(_context, _mapper);
            query.GenreId = id;
            GetGenresDetailQueryValidator validator = new GetGenresDetailQueryValidator();
            validator.ValidateAndThrow(query);
            var obj = query.Handle();
            return Ok(obj);
        }





        [HttpPost]
        public ActionResult AddGenre([FromBody] CreateGenreViewModel newGenre)
        {
            CreateGenreCommand command = new CreateGenreCommand(_context);
            command.Model = newGenre;
            CreateGenreCommandValidator validator = new CreateGenreCommandValidator();
            validator.ValidateAndThrow(command);
            command.Handle();
            return Ok();
        }





        [HttpPut("{id}")]
        public ActionResult UpdateGenre(int id, [FromBody] UpdateGenreViewModel updateGenre)
        {
            UpdateGenreCommand command = new UpdateGenreCommand(_mapper, _context);
            command.GenreId = id;
            command.Model = updateGenre;

            UpdateGenreCommandValidator validator = new UpdateGenreCommandValidator();
            validator.ValidateAndThrow(command);

            command.Handle();
            return Ok();
        }





        [HttpDelete("{id}")]
        public ActionResult DeleteGenre(int id)
        {
            DeleteGenreCommand command = new DeleteGenreCommand(_context);
            DeleteGenreCommandValidator validator = new DeleteGenreCommandValidator();
            command.GenreId = id;
            validator.ValidateAndThrow(command);
            command.Handle();
            return Ok();
        }




    }
}