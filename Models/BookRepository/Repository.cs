using Library.Models.BookRepository.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Models.BookRepository
{
    public class Repository : IRepository
    {
        private LibraryDbContext context;
        public Repository(LibraryDbContext ctx)
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

            var editBook = context.Books.FirstOrDefault(b =>
                b.Id == book.Id);
            if (editBook != null)
            {
                editBook.Title = book.Title;
                editBook.Get_Category.Name = book.Get_Category.Name;
                editBook.Get_Book_Copies.No_Of_Copies = book.Get_Book_Copies.No_Of_Copies;
                editBook.Get_Book_Authors.Name = book.Get_Book_Authors.Name;
                context.SaveChanges();
                return "Pomyślnie zapisano zmiany";
            }
            return null;
        }

        public bool DeleteBook(string id)
        {
            if (id != null)
            {
                var deleteBook = context.Books.FirstOrDefault(b =>
                    b.Id == id);

                context.Books.Remove(deleteBook);
                context.SaveChanges();
                return true;
            }
            return false;
        }

        public Book FindBook(string id)
        {
            if (id != null)
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
    }
}
