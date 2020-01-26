using Library.Models.BookRepository.Interface;
using Library.Models.BookRepository.Model;
using Library.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Controllers
{
    [Route("api/[controller]")]
    public class AuthorController : Controller
    {
        private IAuthorRepo repository;

        public AuthorController(IAuthorRepo repo)
        {
            repository = repo;
        }

        [HttpGet]
        public JsonResult GetAuthorList()
        {
            return Json(repository.Authors);
        }

        [HttpGet("{id}")]
        public JsonResult GetOneAuthor(int id)
        {
            if (id != 0)
            {
                Book_Authors author = repository.FindAuthor(id);
                if (author != null)
                {
                    return Json(author);
                }
            }
            return Json(new { Msg = "Nie znaleziono autora o danym id.", Result = false });
        }

        [HttpPost]
        public JsonResult CreateAuthor([FromBody] AuthorViewModel model)
        {
            if (model != null)
            {
                Book_Authors author = new Book_Authors();
                author.Name = model.Name;

                var result = repository.AddAuthor(author);
                if (result != null)
                {
                    return Json(new { Msg = result, Result = true });
                }
            }
            return Json(new { Msg = "Nie udało się utworzyć autora.", Result = false });
        }

        [HttpDelete("{id}")]
        public JsonResult DeleteAuthor(int id)
        {          
                var result = repository.DeleteAuthor(id);
                if (result == true)
                {
                    return Json(new { Msg = "Usunięto autora z bazy.", Result = true });
                }
                return Json(new { Msg = "Autor nie istnieje.", Result = false });       
        }
    }
}
