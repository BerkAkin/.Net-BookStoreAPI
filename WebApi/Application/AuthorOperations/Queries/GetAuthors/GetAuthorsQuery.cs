using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using WebApi.DBOperations;
using WebApi.Entities;

namespace WebApi.Application.AuthorOperations.Queries.GetAuthors
{
    public class GetAuthorsQuery
    {
        private readonly IMapper _mapper;
        private readonly IBookStoreDbContext _context;
        public GetAuthorsQuery(IMapper mapper, IBookStoreDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public List<AuthorsViewModel> Handle()
        {
            List<Author> authors = _context.Authors.ToList<Author>();
            List<AuthorsViewModel> vm = _mapper.Map<List<AuthorsViewModel>>(authors);
            return vm;
        }
    }

    public class AuthorsViewModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime BirthDate { get; set; }
    }
}