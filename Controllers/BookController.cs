using Library.Models.BookRepository;
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
        private IBookRepo repository;

        public BookController(IBookRepo repo)
        {
            repository = repo;
        }

        [HttpGet]
        public JsonResult GetBookList()
        {
            var result = repository.Books.Include(b => b.Get_Book_Authors).Select(b => new
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
                Book book = repository.FindBook(id);
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
                Book book = new Book();
                book.Title = model.Title;
                book.Get_Book_Authors.Name = model.Author;
                book.Get_Category.Name = model.Category;
                book.Get_Book_Copies.No_Of_Copies = model.CopiesNo;

                var result = repository.AddBook(book);
                if (result != null)
                {
                    return Json(new { Msg = result, Result = true });
                }
            }
            return Json(new { Msg = "Nie udało się utworzyć książki.", Result = false });
        }

        [HttpDelete("{id}")]
        public JsonResult DeleteBook(int id)
        {
                var result = repository.DeleteBook(id);

                if(result == true)
                {
                    return Json(new { Msg = "Usunięto książkę ze zbioru.", Result = true });
                }
                return Json(new { Msg = "Książka nie istnieje.", Result = false });
        }


    }
}
