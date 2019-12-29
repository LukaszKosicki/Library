using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Models.BookRepository.Model
{
    public class Category
    {
        [Key]
        public string CategoryId { get; set; }
        public string BookId { get; set; }
        public string Name { get; set; }
    }
}
