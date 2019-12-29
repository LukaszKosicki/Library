using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Models.BookRepository.Model
{
    public class Book
    {
        public string Id { get; set; }
        public string Title { get; set; }

        public Book_Authors Get_Book_Authors { get; set; }
        public Category Get_Category { get; set; }
        public Book_Copies Get_Book_Copies { get; set; }
        public Book_Loans Book_Loans { get; set; }
    }
}
