using Library.Models.BookRepository.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Models.BookRepository.Interface
{
    public interface IAuthorRepo
    {
        IQueryable<Book_Authors> Authors { get; }

        string AddAuthor(Book_Authors author);
        bool DeleteAuthor(int id);
        Book_Authors FindAuthor(int id);



    }
}
