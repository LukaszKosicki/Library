using Library.Models.BookRepository;
using Library.Models.BookRepository.Interface;
using Library.Models.BookRepository.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Controllers
{
    [Route("api/[controller]")]
    public class LoansController : Controller
    {
        private IBookRepo repositoryBook;
        private ILoansRepo repositoryLoans;

        public LoansController(IBookRepo repo,
            ILoansRepo repoLoans)
        {
            repositoryBook = repo;
            repositoryLoans = repoLoans;
        }

        [HttpPost]
        public JsonResult ReservationBook(string userId, int bookId)
        {
            Book reservBook = repositoryBook.FindBook(bookId);
            if (reservBook != null)
            {
                var bookCopies = repositoryBook.Books.Include(b => b.Get_Book_Copies)
                    .FirstOrDefault(b => b.Id == bookId);

                if (bookCopies.Get_Book_Copies.No_Of_Copies > 0)
                {
                    Book_Loans loans = new Book_Loans();
                    loans.UserId = userId;
                    var result = repositoryLoans.AddLoans(loans);
                    return Json(new { Msg = result, Result = true });
                }
            }
            return Json(new { Msg = "Nieprzekazano książki.", Result = false });
        }




    }
}
