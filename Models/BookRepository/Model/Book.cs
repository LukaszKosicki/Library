using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Models.BookRepository.Model
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public int AuthorId { get; set; }
        public Book_Authors Get_Book_Authors { get; set; }

        public int CategoryId { get; set; }
        public Category Get_Category { get; set; }

        public Book_Copies Get_Book_Copies { get; set; }

        public int? LoansId { get; set; }
        public Book_Loans Book_Loans { get; set; }
    }
}
