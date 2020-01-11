using Library.Models.BookRepository.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Models.BookRepository
{
    public class BookRepo : IBookRepo
    {
        private LibraryDbContext context;
        public BookRepo(LibraryDbContext ctx)
        {
            context = ctx;
        }

        public IQueryable<Book> Books => context.Books;

        public string AddBook(Book book)
        {
            if (book != null)
            {
                context.Books.Add(book);
                context.SaveChanges();
                return "Dodano książkę do zbioru";
            }
            return null;
        }

        public bool DeleteBook(int id)
        {
            if (id != 0)
            {
                var deleteBook = context.Books.FirstOrDefault(b =>
                    b.Id == id);

                context.Books.Remove(deleteBook);
                context.SaveChanges();
                return true;
            }
            return false;
        }

        public Book FindBook(int id)
        {
            if (id != 0)
            {
                var book = context.Books.FirstOrDefault(b =>
                    b.Id == id);
                if (book != null)
                {
                    return book;
                }
            }
            return null;
        }

        public bool AddBookNo(int id, int number)
        {
            Book book = new Book();
            book = context.Books.FirstOrDefault(b =>
                b.Id == id);
            book.Get_Book_Copies.No_Of_Copies = number;
            context.SaveChanges();
            return false;
        }
    }
}
