using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Library.Migrations.LibraryDb
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Book_Authors",
                columns: table => new
                {
                    AuthorId = table.Column<string>(nullable: false),
                    BookId = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Book_Authors", x => x.AuthorId);
                    table.ForeignKey(
                        name: "FK_Book_Authors_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Book_Copies",
                columns: table => new
                {
                    CopiesId = table.Column<string>(nullable: false),
                    BookId = table.Column<string>(nullable: true),
                    No_Of_Copies = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Book_Copies", x => x.CopiesId);
                    table.ForeignKey(
                        name: "FK_Book_Copies_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Book_Loans",
                columns: table => new
                {
                    LoansId = table.Column<string>(nullable: false),
                    BookId = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: true),
                    Date_Out = table.Column<DateTime>(nullable: false),
                    Date_In = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Book_Loans", x => x.LoansId);
                    table.ForeignKey(
                        name: "FK_Book_Loans_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    CategoryId = table.Column<string>(nullable: false),
                    BookId = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.CategoryId);
                    table.ForeignKey(
                        name: "FK_Category_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Book_Authors_BookId",
                table: "Book_Authors",
                column: "BookId",
                unique: true,
                filter: "[BookId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Book_Copies_BookId",
                table: "Book_Copies",
                column: "BookId",
                unique: true,
                filter: "[BookId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Book_Loans_BookId",
                table: "Book_Loans",
                column: "BookId",
                unique: true,
                filter: "[BookId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Category_BookId",
                table: "Category",
                column: "BookId",
                unique: true,
                filter: "[BookId] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Book_Authors");

            migrationBuilder.DropTable(
                name: "Book_Copies");

            migrationBuilder.DropTable(
                name: "Book_Loans");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "Books");
        }
    }
}
