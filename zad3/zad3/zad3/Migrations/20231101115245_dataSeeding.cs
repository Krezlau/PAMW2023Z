using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace zad3.Migrations
{
    /// <inheritdoc />
    public partial class dataSeeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "rating",
                table: "Books",
                newName: "Rating");

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "Rating", "Synopsis", "Title" },
                values: new object[,]
                {
                    { new Guid("1e98c12e-7270-4396-bca4-96b79e9ecb49"), "J.R.R. Tolkien", 5.0, "The Lord of the Rings is an epic fantasy novel written by English author J. R. R. Tolkien.", "The Lord of the Rings" },
                    { new Guid("552ede80-1162-4c2b-9099-9fa3ca872e2c"), "Suzanne Collins", 2.5, "Catching Fire is a 2009 science fiction young adult novel by the American novelist Suzanne Collins, the second book in The Hunger Games series.", "Catching Fire" },
                    { new Guid("55418966-489d-43f8-acb0-16d387e5da1e"), "J.R.R. Tolkien", 5.0, "The Hobbit, or There and Back Again is a children's fantasy novel by English author J. R. R. Tolkien.", "The Hobbit" },
                    { new Guid("6ef8a11b-8252-4062-b37e-8282d4a951e1"), "Andy Weir", 3.2999999999999998, "The Martian is a 2011 science fiction novel written by Andy Weir. It was his debut novel under his own name. It was originally self-published in 2011; Crown Publishing purchased the rights and re-released it in 2014.", "The Martian" },
                    { new Guid("8b114d65-5742-4d71-858e-35f57ef34d86"), "Dan Brown", 3.8999999999999999, "The Da Vinci Code is a 2003 mystery thriller novel by Dan Brown. It is Brown's second novel to include the character Robert Langdon: the first was his 2000 novel Angels & Demons.", "The Da Vinci Code" },
                    { new Guid("b5c1957c-4e2f-4fa6-86bb-4f1affb307de"), "J.K. Rowling", 4.5, "Harry Potter is a series of seven fantasy novels written by British author J. K. Rowling.", "Harry Potter" },
                    { new Guid("b68dcf1a-2ca6-4558-920a-e265bd83cd88"), "Suzanne Collins", 4.9000000000000004, "The Hunger Games is a 2008 dystopian novel by the American writer Suzanne Collins. It is written in the voice of 16-year-old Katniss Everdeen, who lives in the future, post-apocalyptic nation of Panem in North America.", "The Hunger Games" },
                    { new Guid("d059416a-54e7-41b8-9bcf-15386abf5796"), "Dan Brown", 4.0999999999999996, "The Lost Symbol is a 2009 novel written by American writer Dan Brown. It is a thriller set in Washington, D.C., after the events of The Da Vinci Code, and relies on Freemasonry for both its recurring theme and its major characters.", "The Lost Symbol" },
                    { new Guid("e6937dc0-b98f-4114-8d3b-48be886b72c4"), "Dan Brown", 4.7000000000000002, "Angels & Demons is a 2000 bestselling mystery-thriller novel written by American author Dan Brown and published by Pocket Books and then by Corgi Books.", "Angels & Demons" },
                    { new Guid("e8d8c843-d7cb-4e2f-9e04-ab97aa1cc442"), "Suzanne Collins", 4.7000000000000002, "Mockingjay is a 2010 science fiction novel by American author Suzanne Collins. It is the last installment of The Hunger Games, following 2008's The Hunger Games and 2009's Catching Fire.", "Mockingjay" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("1e98c12e-7270-4396-bca4-96b79e9ecb49"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("552ede80-1162-4c2b-9099-9fa3ca872e2c"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("55418966-489d-43f8-acb0-16d387e5da1e"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("6ef8a11b-8252-4062-b37e-8282d4a951e1"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("8b114d65-5742-4d71-858e-35f57ef34d86"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("b5c1957c-4e2f-4fa6-86bb-4f1affb307de"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("b68dcf1a-2ca6-4558-920a-e265bd83cd88"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("d059416a-54e7-41b8-9bcf-15386abf5796"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("e6937dc0-b98f-4114-8d3b-48be886b72c4"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("e8d8c843-d7cb-4e2f-9e04-ab97aa1cc442"));

            migrationBuilder.RenameColumn(
                name: "Rating",
                table: "Books",
                newName: "rating");
        }
    }
}
