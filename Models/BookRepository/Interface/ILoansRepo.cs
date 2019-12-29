using Library.Models.BookRepository.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Models.BookRepository.Interface
{
    interface ILoansRepo
    {
        IQueryable<Book_Loans> Loans { get; }

        string AddLoans(Book_Loans loans);
        bool DeleteLoans(int id);
        Book_Loans FindLoans(int id);


    }
}
