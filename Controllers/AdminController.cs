using Library.Models;
using Library.Models.BookRepository;
using Library.Models.BookRepository.Interface;
using Library.Models.BookRepository.Model;
using Library.Models.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        public JsonResult GetReservationBook(int czy)
        {
            //var reservation = from l in loansRepo.Loans
            //          join b in bookRepo.Books on l.BookId equals b.Id 
            //          select new
            //          {
            //              LoannsId = l.LoansId,
            //              LoansOut = l.Date_Out,
            //              LoansIn = l.Date_In,
            //              AuthorName = from a in bookRepo.Books
            //                           join a in 
            //              BookTitle = b.Title
            //          };
       
            if (czy == 0)
            {

                var reservation = loansRepo.Loans.Include(l => l.Book)
                    .ThenInclude(b => b.Get_Book_Authors).Where(l => l.Date_Out == null && l.Date_In == null);
                var r = reservation.Select(y => new
                {
                    Id = y.LoansId,
                    Name = y.Book.Get_Book_Authors.Name,
                    Title = y.Book.Title
                });

                if (r != null)
                {
                    return Json(r);
                }
                return Json(null);
            }
            else if (czy == 1)
            {

                var reservation = loansRepo.Loans.Include(l => l.Book)
                    .ThenInclude(b => b.Get_Book_Authors).Where(l => l.Date_Out != null && l.Date_In == null);
                var r = reservation.Select(y => new
                {
                    Id = y.LoansId,
                    Name = y.Book.Get_Book_Authors.Name,
                    Title = y.Book.Title
                });

                if (r != null)
                {
                    return Json(r);
                }
                return Json(null);
            } else
            {
                var reservation = loansRepo.Loans.Include(l => l.Book)
                   .ThenInclude(b => b.Get_Book_Authors).Where(l => l.Date_Out != null && l.Date_In != null);
                var r = reservation.Select(y => new
                {
                    Id = y.LoansId,
                    Name = y.Book.Get_Book_Authors.Name,
                    Title = y.Book.Title,
                    Zwrot = y.Date_In,
                    Wyp = y.Date_Out
                });

                if (r != null)
                {
                    return Json(r);
                }
                return Json(null);
            }

        }

        [HttpPatch]
        public JsonResult BorrowBook(int id, bool czy)
        {
         
                Book_Loans book_Loans = loansRepo.FindLoans(id);
                if (book_Loans != null)
                {
                if (czy)
                {
                    book_Loans.Date_Out = DateTime.Now;
                } else
                {
                    book_Loans.Date_In = DateTime.Now;
                }              
                    
                    var resultLoans = loansRepo.AddLoans(book_Loans);
                    return Json(new { Msg = resultLoans, Result = true });
                }
            
            return Json(new { Msg = "Nie przekazano zamówienia.", Result = false });
        }
    }
}
