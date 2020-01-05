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
                        Name = "Sci-fi"
                    },
                    new Category
                    {
                        Name = "Fantasy"
                    },
                    new Category
                    {
                        Name = "Horror"
                    });
                context.SaveChanges();
            }

            if (!context.Authors.Any())
            {
                context.Authors.AddRange(
                    new Book_Authors
                    {
                        Name = "Stanisław Lem"
                    },
                    new Book_Authors
                    {
                        Name = "John Ronald Reuel Tolkien"
                    },
                    new Book_Authors
                    {
                        Name = "Stephen King"
                    });
                context.SaveChanges();
            }

            if (!context.Books.Any())
            {
                context.Books.AddRange(
                    new Book
                    {
                        Title = "Dzienniki gwiazdowe",
                        AuthorId = 1,
                        CategoryId = 1
                    },
                    new Book
                    {
                        Title = "Solaris",
                        AuthorId = 1,
                        CategoryId = 1
                    },
                    new Book
                    {
                        Title = "Władca Pierścieni",
                        AuthorId = 2,
                        CategoryId = 2
                    },
                    new Book
                    {
                        Title = "Hobbit",
                        AuthorId = 2,
                        CategoryId = 2
                    },
                    new Book
                    {
                        Title = "Cujo",
                        AuthorId = 3,
                        CategoryId = 3
                    },
                    new Book
                    {
                        Title = "Lśnienie",
                        AuthorId = 3,
                        CategoryId = 3
                    });
                context.SaveChanges();
            }
        }

    }
}
