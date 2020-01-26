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
    public class CategoryController : Controller
    {
        private ICategoryRepo repository;

        public CategoryController(ICategoryRepo repo)
        {
            repository = repo;
        }


        [HttpGet]
        public JsonResult GetCategoryList()
        {
            return Json(repository.Categories);
        }

        [HttpGet("{id}")]
        public JsonResult GetOneCategory(int id)
        {
            if (id != 0)
            {
                Category category = repository.FindCategory(id);
                if (category != null)
                {
                    return Json(category);
                }
            }
            return Json(new { Msg = "Nie znaleziono kategorii o danym id.", Result = false });
        }

        [HttpPost]
        public JsonResult CreateCategory([FromBody] CategoryViewModel model)
        {
            if (model != null)
            {
                Category category = new Category();
                category.Name = model.Name;
                string result = "";
               
               
                    result = repository.AddCategory(category);
                
                
                if (result != null)
                {
                    return Json(new { Msg = category, Result = true });
                }
            }
            return Json(new { Msg = "Nie udało się utworzyć kategorii.", Result = false });
        }


        [HttpDelete("{id}")]
        public JsonResult DeleteCategory(int id)
        {     
                var result = repository.DeleteCategory(id);
                if (result == true)
                {
                    return Json(new { Msg = "Usunięto kategorię z bazy.", Result = true });
                }
                return Json(new { Msg = "Kategoria nie istnieje.", Result = false });
           
        }
    }
}
