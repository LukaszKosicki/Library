using Library.Models.BookRepository;
using Library.Models.BookRepository.Interface;
using Library.Models.BookRepository.Model;
using Library.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Controllers
{
    [Route("api/[controller]")]
    public class BookController : Controller
    {
        private IBookRepo bookRepo;
        private IAuthorRepo authorRepo;
        private ICategoryRepo categoryRepo;

        public BookController(IBookRepo repo,
            IAuthorRepo authorRp, ICategoryRepo categoryRp)
        {
            bookRepo = repo;
            authorRepo = authorRp;
            categoryRepo = categoryRp;
        }

        [HttpGet]
        public JsonResult GetBookList()
        {
            var result = bookRepo.Books.Include(b => b.Get_Book_Authors).Select(b => new
            {
                b.Id,
                b.Title,
                Author = b.Get_Book_Authors.Name,
                Category = b.Get_Category.Name,
                CopiesNo = b.Get_Book_Copies.No_Of_Copies
            });
            return Json(result);
        }

        [HttpGet("{id}")]
        public JsonResult GetOneBook(int id)
        {
            if (id != 0)
            {
                Book book = bookRepo.FindBook(id);
                if (book != null)
                {
                    // dodać zapytanie Linq o zwrot książki z autorem itp

                    return Json(book);
                }
            }
            return Json(new { Msg = "Nie znaleziono książki o danym id.", Result = false });
        }

        [HttpPost]
        public JsonResult CreateBook([FromBody] BookViewModel model)
        {
            if (model != null)
            {
                Book_Authors author = authorRepo.FindAuthor(model.AuthorId);

                Category category = categoryRepo.FindCategory(model.CategoryId);

                Book_Copies copies = new Book_Copies();
                copies.No_Of_Copies = model.CopiesNo;

                Book book = new Book();
                book.Title = model.Title;
                book.Get_Book_Authors = author;
                book.Get_Category = category;
                book.Get_Book_Copies = copies;

                var result = bookRepo.AddBook(book);
                if (result != null)
                {
                    return Json(new { Msg = result, Result = true });
                }
            }
            return Json(new { Msg = "Nie udało się utworzyć książki.", Result = false });
        }

        [HttpDelete]
        public JsonResult DeleteBook([FromBody] BookViewModel model)
        {
            if (model != null)
            {
                var result = bookRepo.DeleteBook(model.BookId);
                if(result == true)
                {
                    return Json(new { Msg = "Usunięto książkę ze zbioru.", Result = true });
                }
                return Json(new { Msg = "Książka nie istnieje.", Result = false });
            }
            return Json(new { Msg = "Nie przekazano książki.", Result = true });
        }


    }
}
