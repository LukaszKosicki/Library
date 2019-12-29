using Library.Models.BookRepository.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Models.BookRepository.Interface
{
    public interface ICategoryRepo
    {
        IQueryable<Category> Categories { get; }

        string AddCategory(Category category);
        bool DeleteCategory(int id);
        Category FindCategory(int id);



    }
}
