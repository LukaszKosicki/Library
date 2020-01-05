using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Models.BookRepository.Model
{
    public class BookLoansManyToMany
    {
        public int BookId { get; set; }
        public Book Book { get; set; }


        public int Book_LoansId { get; set; }
        public Book_Loans Book_Loans { get; set; }
    }
}
