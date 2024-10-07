using System;
using System.Linq;
using AutoMapper;
using WebApi.DBOperations;
using WebApi.Entities;

namespace WebApi.Application.AuthorOperations.Commands.CreateAuthor
{
    public class CreateAuthorCommand
    {
        private readonly IMapper _mapper;
        private readonly IBookStoreDbContext _context;
        public CreateAuthorViewModel Model { get; set; }

        public CreateAuthorCommand(IMapper mapper, IBookStoreDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }
        public void Handle()
        {
            var author = _context.Authors.SingleOrDefault(x => x.Name == Model.Name && x.Surname == Model.Surname);
            if (author != null)
            {
                throw new InvalidOperationException("Yazar Zaten Mevcut");
            }
            else
            {
                author = _mapper.Map<Author>(Model);
                _context.Authors.Add(author);
                _context.SaveChanges();
            }
        }
    }

    public class CreateAuthorViewModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime BirthDate { get; set; }
    }
}