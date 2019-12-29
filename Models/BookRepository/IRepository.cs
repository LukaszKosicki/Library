using Library.Models.BookRepository.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Models.BookRepository
{
    public interface IRepository
    {
        IQueryable<Book> Books { get; }

        string AddBook(Book book);
        bool DeleteBook(string id);
        Book FindBook(string id);
    }
}
