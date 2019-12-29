using Library.Models.BookRepository.Interface;
using Library.Models.BookRepository.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Models.BookRepository.Repo
{
    public class AuthorRepo : IAuthorRepo
    {
        private LibraryDbContext context;

        public AuthorRepo(LibraryDbContext ctx)
        {
            context = ctx;
        }

        public IQueryable<Book_Authors> Authors => context.Authors;

        public string AddAuthor(Book_Authors author)
        {
            if (author != null)
            {
                context.Authors.Add(author);
                context.SaveChanges();
                return "Dodano nowego autora.";
            }
            return null;
        }

        public bool DeleteAuthor(int id)
        {
            if (id != 0)
            {
                var deleteAuthor = context.Authors.FirstOrDefault(b =>
                    b.AuthorId == id);

                context.Authors.Remove(deleteAuthor);
                context.SaveChanges();
                return true;
            }
            return false;
        }

        public Book_Authors FindAuthor(int id)
        {
            if (id != 0)
            {
                var author = context.Authors.FirstOrDefault(b =>
                    b.AuthorId == id);
                if (author != null)
                {
                    return author;
                }
            }
            return null;
        }
    }
}
