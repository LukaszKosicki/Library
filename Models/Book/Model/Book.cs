using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Models.Book.Model
{
    public class Book
    {
        public string Id { get; set; }
        public string Title { get; set; }

        public ICollection<Author> Authors { get; set; }
        public ICollection<Category> Categories { get; set; }
    }
}
