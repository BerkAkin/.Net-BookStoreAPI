
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WebApi.Entities;

//database Seeder'ıdır aslında

namespace WebApi.DBOperations
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new BookStoreDbContext(serviceProvider.GetRequiredService<DbContextOptions<BookStoreDbContext>>()))
            {
                if (context.Books.Any())
                {
                    return;
                }
                else
                {
                    context.Books.AddRange(
                      new Book
                      {
                          Title = "Lean Startup",
                          GenreId = 1,
                          PageCount = 200, //Personal Growth
                          PublishDate = new DateTime(2001, 09, 02),
                          Author = "Berk Akın"
                      }
                    );
                }
                context.SaveChanges();
            }
        }
    }
}