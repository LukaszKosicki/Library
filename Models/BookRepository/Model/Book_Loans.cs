using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Models.BookRepository.Model
{
    public class Book_Loans
    {
        [Key]
        public int LoansId { get; set; }
        public string UserId { get; set; }
        public DateTime Date_Out { get; set; }
        public DateTime Date_In { get; set; }

        public IList<BookLoansManyToMany> BookLoansManyToManies { get; set; }
    }
}
