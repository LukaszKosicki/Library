using Library.Models;
using Library.Models.BookRepository;
using Library.Models.BookRepository.Interface;
using Library.Models.BookRepository.Model;
using Library.Models.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Controllers
{
    [Route("api/[controller]")]
    public class AdminController : Controller
    {
        private UserManager<AppUser> userManager;
        private IBookRepo bookRepo;
        private ILoansRepo loansRepo;

        public AdminController(UserManager<AppUser> userMgr,
            IBookRepo bookRp, ILoansRepo loansRp)
        {
            userManager = userMgr;
            bookRepo = bookRp;
            loansRepo = loansRp;
        }

        [HttpGet]
        public JsonResult GetReservationBook()
        {
            var reservation = loansRepo.Loans.Where(l => l.Date_Out == null);
            if (reservation != null)
            {
                return Json(reservation);
            }
            return Json(null);
        }

        [HttpPatch]
        public JsonResult BorrowBook([FromBody] LoansViewModel model)
        {
            if (model != null)
            {
                Book_Loans book_Loans = loansRepo.FindLoans(model.LoansId);
                if (book_Loans != null)
                {
                    book_Loans.Date_Out = model.DateOut;
                    book_Loans.Date_In = model.DateIn;
                    var resultLoans = loansRepo.AddLoans(book_Loans);
                    return Json(new { Msg = resultLoans, Result = true });
                }
            }
            return Json(new { Msg = "Nie przekazano zamówienia.", Result = false });
        }
    }
}
