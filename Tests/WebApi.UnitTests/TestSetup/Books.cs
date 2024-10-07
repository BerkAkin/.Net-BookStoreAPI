using System;
using WebApi.DBOperations;
using WebApi.Entities;

namespace TestSetup
{
    public static class Books
    {
        public static void AddBooks(this BookStoreDbContext context)
        {

            context.Books.AddRange(
                new Book { Title = "Lean Startup", GenreId = 1, PageCount = 200, PublishDate = new DateTime(2001, 09, 02), AuthorId = 1 });

        }
    }
}