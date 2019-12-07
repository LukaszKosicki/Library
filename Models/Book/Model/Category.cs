using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Models.Book.Model
{
    public class Category
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public Book Book { get; set; }
    }
}
