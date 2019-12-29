﻿using Library.Models.BookRepository;
using Library.Models.BookRepository.Model;
using Library.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
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
            //********************************************** naprawić, linq - ustawić tabele
            return Json(repository.Books);
        }

        [HttpGet("{id}")]
        public JsonResult GetOneBook(int id)
        {
            if (id != 0)
            {
                Book book = repository.FindBook(id);
                if (book != null)
                {
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

        [HttpPatch]
        public JsonResult EditBook([FromBody] BookViewModel model)
        {
            if (model != null)
            {
                Book editBook = repository.FindBook(model.BookId);
                if (editBook != null)
                {
                    editBook.Title = model.Title;
                    editBook.Get_Book_Authors.Name = model.Author;
                    editBook.Get_Category.Name = model.Category;
                    editBook.Get_Book_Copies.No_Of_Copies = model.CopiesNo;

                    var result = repository.AddBook(editBook);
                    if (result != null)
                    {
                        return Json(new { Msg = result, Result = true });
                    }
                }
                return Json(new { Msg = "Nie znaleziono książki o podanym id.", Result = false });
            }
            return Json(new { Msg = "Nie przekazano książki.", Result = false });
        }

        [HttpDelete]
        public JsonResult DeleteBook([FromBody] BookViewModel model)
        {
            if (model != null)
            {
                var result = repository.DeleteBook(model.BookId);
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