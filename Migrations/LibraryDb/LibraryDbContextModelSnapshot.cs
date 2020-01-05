﻿// <auto-generated />
using System;
using Library.Models.BookRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Library.Migrations.LibraryDb
{
    [DbContext(typeof(LibraryDbContext))]
    partial class LibraryDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Library.Models.BookRepository.Model.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AuthorId");

                    b.Property<int>("CategoryId");

                    b.Property<int?>("LoansId");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.HasIndex("CategoryId");

                    b.HasIndex("LoansId");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("Library.Models.BookRepository.Model.Book_Authors", b =>
                {
                    b.Property<int>("AuthorId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("AuthorId");

                    b.ToTable("Authors");
                });

            modelBuilder.Entity("Library.Models.BookRepository.Model.Book_Copies", b =>
                {
                    b.Property<int>("CopiesId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BookId");

                    b.Property<int>("No_Of_Copies");

                    b.HasKey("CopiesId");

                    b.HasIndex("BookId")
                        .IsUnique();

                    b.ToTable("Book_Copies");
                });

            modelBuilder.Entity("Library.Models.BookRepository.Model.Book_Loans", b =>
                {
                    b.Property<int>("LoansId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date_In");

                    b.Property<DateTime>("Date_Out");

                    b.Property<string>("UserId");

                    b.HasKey("LoansId");

                    b.ToTable("Loans");
                });

            modelBuilder.Entity("Library.Models.BookRepository.Model.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("Library.Models.BookRepository.Model.Book", b =>
                {
                    b.HasOne("Library.Models.BookRepository.Model.Book_Authors", "Get_Book_Authors")
                        .WithMany("Books")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Library.Models.BookRepository.Model.Category", "Get_Category")
                        .WithMany("Books")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Library.Models.BookRepository.Model.Book_Loans", "Book_Loans")
                        .WithMany("Books")
                        .HasForeignKey("LoansId");
                });

            modelBuilder.Entity("Library.Models.BookRepository.Model.Book_Copies", b =>
                {
                    b.HasOne("Library.Models.BookRepository.Model.Book")
                        .WithOne("Get_Book_Copies")
                        .HasForeignKey("Library.Models.BookRepository.Model.Book_Copies", "BookId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
