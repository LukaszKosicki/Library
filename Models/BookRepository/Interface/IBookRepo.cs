using Library.Models.BookRepository.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Models.BookRepository
{
    public interface IBookRepo
    {
        IQueryable<Book> Books { get; }

        string AddBook(Book book);
        bool DeleteBook(int id);
        Book FindBook(int id);
    }
}
