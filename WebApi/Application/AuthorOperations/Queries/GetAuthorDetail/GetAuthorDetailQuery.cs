using System;
using System.Linq;
using AutoMapper;
using WebApi.DBOperations;

namespace WebApi.Application.AuthorOperations.Queries.GetAuthorDetail
{
    public class GetAuthorDetailQuery
    {
        private readonly IMapper _mapper;
        private readonly IBookStoreDbContext _context;

        public int Id { get; set; }
        public AuthorDetailViewModel model { get; set; }

        public GetAuthorDetailQuery(IMapper mapper, IBookStoreDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public AuthorDetailViewModel Handle()
        {
            var author = _context.Authors.Where(author => author.Id == Id).FirstOrDefault();
            if (author == null)
            {
                throw new InvalidOperationException("Yazar Bulunamadı");
            }
            else
            {
                AuthorDetailViewModel vm = _mapper.Map<AuthorDetailViewModel>(author);
                return vm;
            }
        }
    }
    public class AuthorDetailViewModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime BirthDate { get; set; }
    }
}