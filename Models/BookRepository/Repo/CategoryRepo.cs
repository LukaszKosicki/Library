using Library.Models.BookRepository.Interface;
using Library.Models.BookRepository.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Models.BookRepository.Repo
{
    public class CategoryRepo : ICategoryRepo
    {
        private LibraryDbContext context;

        public CategoryRepo(LibraryDbContext ctx)
        {
            context = ctx;
        }

        public IQueryable<Category> Categories => context.Categories;

        public string AddCategory(Category category)
        {
            if (category != null)
            {
                for (var i = 0; i < 10000; i++)
                {
                    Category cat = new Category()
                    {
                        Name = "Kategoria" + (999 + i).ToString()
                    };
                    context.Categories.Add(cat);
                    context.SaveChanges();
                }
                
                return "Dodano nową kategorię.";
            }
            return null;
        }

        public bool DeleteCategory(int id)
        {
            if (id != 0)
            {
                var deleteCategory = context.Categories.FirstOrDefault(b =>
                    b.CategoryId == id);

                context.Categories.Remove(deleteCategory);
                context.SaveChanges();
                return true;
            }
            return false;
        }

        public Category FindCategory(int id)
        {
            if (id != 0)
            {
                var category = context.Categories.FirstOrDefault(b =>
                    b.CategoryId == id);
                if (category != null)
                {
                    return category;
                }
            }
            return null;
        }
    }
}
