using Library.Models.BookRepository.Interface;
using Library.Models.BookRepository.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Models.BookRepository.Repo
{
    public class LoansRepo : ILoansRepo
    {
        private LibraryDbContext context;

        public LoansRepo(LibraryDbContext ctx)
        {
            context = ctx;
        }

        public IQueryable<Book_Loans> Loans => context.Loans;

        public string AddLoans(Book_Loans loans)
        {
            if (loans != null)
            {
                context.Loans.Add(loans);
                context.SaveChanges();
                return "Wypożyczono książkę.";
            }
            return null;
        }

        public bool DeleteLoans(int id)
        {
            if (id != 0)
            {
                var deleteLoans = context.Loans.FirstOrDefault(b =>
                    b.LoansId == id);

                context.Loans.Remove(deleteLoans);
                context.SaveChanges();
                return true;
            }
            return false;
        }

        public Book_Loans FindLoans(int id)
        {
            if (id != 0)
            {
                var loans = context.Loans.FirstOrDefault(b =>
                    b.LoansId == id);
                if (loans != null)
                {
                    return loans;
                }
            }
            return null;
        }
    }
}
