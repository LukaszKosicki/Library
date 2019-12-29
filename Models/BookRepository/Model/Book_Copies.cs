using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Models.BookRepository.Model
{
    public class Book_Copies
    {
        [Key]
        public string CopiesId { get; set; }
        public string BookId { get; set; }
        public int No_Of_Copies { get; set; }

    }
}
