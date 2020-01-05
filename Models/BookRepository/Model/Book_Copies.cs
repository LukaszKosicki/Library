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
        public int CopiesId { get; set; }
        public int BookId { get; set; }
        public int No_Of_Copies { get; set; }

    }
}
