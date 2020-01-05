using Library.Models.BookRepository;
using Library.Models.BookRepository.Model;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Models
{
    public class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            LibraryDbContext context = app.ApplicationServices.
                GetRequiredService<LibraryDbContext>();

            context.Database.Migrate();

            if (!context.Categories.Any())
            {
                context.Categories.AddRange(
                    new Category
                    {
                        CategoryId = 1,
                        Name = "Sci-fi"
                    },
                    new Category
                    {
                        CategoryId = 2,
                        Name = "Fantasy"
                    },
                    new Category
                    {
                        CategoryId = 3,
                        Name = "Horror"
                    });
                context.SaveChanges();
            }

            if (!context.Authors.Any())
            {
                context.Authors.AddRange(
                    new Book_Authors
                    {
                        AuthorId = 1,
                        Name = "Stanisław Lem"
                    },
                    new Book_Authors
                    {
                        AuthorId = 2,
                        Name = "John Ronald Reuel Tolkien"
                    },
                    new Book_Authors
                    {
                        AuthorId = 3,
                        Name = "Stephen King"
                    });
                context.SaveChanges();
            }

            if (!context.Books.Any())
            {
                context.Books.AddRange(
                    new Book
                    {
                        Id = 1,
                        Title = "Dzienniki gwiazdowe",
                        AuthorId = 1,
                        CategoryId = 1,
                    },
                    new Book
                    {
                        Id = 11,
                        Title = "Solaris",
                        AuthorId = 1,
                        CategoryId = 1
                    },
                    new Book
                    {
                        Id = 2,
                        Title = "Władca Pierścieni",
                        AuthorId = 2,
                        CategoryId = 2
                    },
                    new Book
                    {
                        Id = 22,
                        Title = "Hobbit",
                        AuthorId = 2,
                        CategoryId = 2
                    },
                    new Book
                    {
                        Id = 3,
                        Title = "Cujo",
                        AuthorId = 3,
                        CategoryId = 3
                    },
                    new Book
                    {
                        Id = 33,
                        Title = "Lśnienie",
                        AuthorId = 3,
                        CategoryId = 3
                    });
                context.SaveChanges();
            }
        }

    }
}
