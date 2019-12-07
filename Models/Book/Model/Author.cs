using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Models.Book.Model
{
    public class Author
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        public Book Book { get; set; }
    }
}
