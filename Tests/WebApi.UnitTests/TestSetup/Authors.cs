using System;
using WebApi.DBOperations;
using WebApi.Entities;

namespace TestSetup
{
    public static class Authors
    {
        public static void AddAuthor(this BookStoreDbContext context)
        {
            context.Authors.AddRange(
                new Author { Name = "Stefan", Surname = "Zweig", BirthDate = new DateTime(1948, 2, 3) });
        }
    }
}