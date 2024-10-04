using System;
using System.Linq;
using System.Reflection.Metadata;
using AutoMapper;
using WebApi.DBOperations;

namespace WebApi.Application.AuthorOperations.Commands.DeleteAuthor
{
    public class DeleteAuthorCommand
    {
        private readonly BookStoreDbContext _context;
        public int Id { get; set; }
        public DeleteAuthorCommand(BookStoreDbContext context)
        {
            _context = context;
        }

        public void Handle()
        {
            var author = _context.Authors.SingleOrDefault(x => x.Id == Id);
            if (author == null)
            {
                throw new InvalidOperationException("Silinecek yazar bulunamadı");
            }
            else
            {
                _context.Remove(author);
                _context.SaveChanges();
            }
        }
    }
}