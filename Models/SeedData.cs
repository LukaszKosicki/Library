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
                Book book1 = new Book
                {
                    Title = "Dzienniki gwiazdowe",
                        AuthorId = 1,
                        CategoryId = 1,
                };
                Book_Copies copies1 = new Book_Copies();
                copies1.No_Of_Copies = 5;
                book1.Get_Book_Copies = copies1;
                context.Books.Add(book1);

                Book book2 = new Book
                {
                    Title = "Solaris",
                    AuthorId = 2,
                    CategoryId = 2
                };
                Book_Copies copies2 = new Book_Copies();
                copies2.No_Of_Copies = 6;
                book2.Get_Book_Copies = copies2;
                context.Books.Add(book2);

                Book book3 = new Book
                {
                    Title = "Władca Pierścieni",
                    AuthorId = 2,
                    CategoryId = 2
                };
                Book_Copies copies3 = new Book_Copies();
                copies3.No_Of_Copies = 4;
                book3.Get_Book_Copies = copies3;
                context.Books.Add(book3);

                Book book4 = new Book
                {
                    Title = "Hobbit",
                    AuthorId = 2,
                    CategoryId = 2
                };
                Book_Copies copies4 = new Book_Copies();
                copies4.No_Of_Copies = 8;
                book4.Get_Book_Copies = copies4;
                context.Books.Add(book4);

                Book book5 = new Book
                {
                    Title = "Cujo",
                    AuthorId = 3,
                    CategoryId = 3
                };
                Book_Copies copies5 = new Book_Copies();
                copies5.No_Of_Copies = 2;
                book5.Get_Book_Copies = copies5;
                context.Books.Add(book5);

                Book book6 = new Book
                {
                    Title = "Lśnienie",
                    AuthorId = 3,
                    CategoryId = 3
                };
                Book_Copies copies6 = new Book_Copies();
                copies6.No_Of_Copies = 9;
                book6.Get_Book_Copies = copies6;
                context.Books.Add(book6);

                context.SaveChanges();
            }

        }

    }
}
