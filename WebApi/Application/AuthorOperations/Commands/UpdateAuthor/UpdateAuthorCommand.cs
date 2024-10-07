using System;
using System.Linq;
using AutoMapper;
using WebApi.DBOperations;
using WebApi.Entities;


namespace WebApi.Application.AuthorOperations.Commands.UpdateAuthor
{
    public class UpdateAuthorCommand
    {

        private readonly IBookStoreDbContext _context;
        private readonly IMapper _mapper;
        public int Id { get; set; }
        public UpdateAuthorViewModel Model { get; set; }

        public UpdateAuthorCommand(IBookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Handle()
        {
            var author = _context.Authors.SingleOrDefault(x => x.Id == Id);
            if (author == null)
            {
                throw new InvalidOperationException("Güncellenecek yazar bulunamadı");
            }
            else
            {
                author.Name = Model.Name != default ? Model.Name : author.Name;
                author.Surname = Model.Surname != default ? Model.Surname : author.Surname;
                author.BirthDate = Model.BirthDate != default ? Model.BirthDate : author.BirthDate;
                _context.SaveChanges();
            }
        }
    }

    public class UpdateAuthorViewModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime BirthDate { get; set; }
    }
}