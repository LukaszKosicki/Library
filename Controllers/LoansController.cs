using Library.Models.BookRepository;
using Library.Models.BookRepository.Interface;
using Library.Models.BookRepository.Model;
using Microsoft.AspNetCore.Mvc;
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
            if (reservBook.Get_Book_Copies.No_Of_Copies > 0) // nie wiem czy to zadziała ************************ 
            {
                Book_Loans loans = new Book_Loans();
                loans.UserId = userId;
                var result = repositoryLoans.AddLoans(loans);
                return Json(new { Msg = result, Result = true });
            }
            return Json(new { Msg = "Nieprzekazano książki.", Result = false });
        }




    }
}
