﻿using Library.Models.BookRepository.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Models.BookRepository
{
    public class LibraryDbContext : DbContext
    {
        public LibraryDbContext(DbContextOptions<LibraryDbContext> 
            options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder model)
        {
            model.Entity<BookLoansManyToMany>().HasKey(bl => new { bl.BookId, bl.Book_LoansId });
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Book_Authors> Authors { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Book_Loans> Loans { get; set; }
    }
}
