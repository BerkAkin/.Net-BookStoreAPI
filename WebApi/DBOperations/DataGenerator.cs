
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

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
                          Id = 1,
                          Title = "Lean Startup",
                          GenreId = 1,
                          PageCount = 200, //Personal Growth
                          PublishDate = new DateTime(2001, 09, 02),
                          Author = "Berk Akın"
                      },
                        new Book
                        {
                            Id = 2,
                            Title = "Chess",
                            GenreId = 3, //Drama
                            PageCount = 102,
                            PublishDate = new DateTime(1980, 06, 12),
                            Author = "Stefan Zweig"
                        },
                        new Book
                        {
                            Id = 3,
                            Title = "Dune",
                            GenreId = 3, //Sci-fi
                            PageCount = 540,
                            PublishDate = new DateTime(2045, 02, 22),
                            Author = "Stefan Zweig"
                        }
                    );
                }
                context.SaveChanges();
            }
        }
    }
}