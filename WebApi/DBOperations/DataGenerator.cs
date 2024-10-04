
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
                    context.Genres.AddRange(
                        new Genre
                        {
                            Name = "Personal Growth",
                        },
                        new Genre
                        {
                            Name = "Science Fiction"
                        },
                        new Genre
                        {
                            Name = "Romance"
                        },
                        new Genre
                        {
                            Name = "Horror"
                        },
                        new Genre
                        {
                            Name = "Documentary"
                        },
                        new Genre
                        {
                            Name = "Action"
                        },
                        new Genre
                        {
                            Name = "Adventure"
                        }
                    );

                    context.Books.AddRange(
                      new Book
                      {
                          Title = "Lean Startup",
                          GenreId = 1,
                          PageCount = 200, //Personal Growth
                          PublishDate = new DateTime(2001, 09, 02),
                          AuthorId = 1
                      }
                    );

                    context.Authors.AddRange(
                        new Author
                        {
                            Name = "Stefan",
                            Surname = "Zweig",
                            BirthDate = new DateTime(1948, 2, 3)
                        },
                        new Author
                        {
                            Name = "John",
                            Surname = "Milton",
                            BirthDate = new DateTime(1978, 4, 12)
                        }
                    );
                }
                context.SaveChanges();
            }
        }
    }
}