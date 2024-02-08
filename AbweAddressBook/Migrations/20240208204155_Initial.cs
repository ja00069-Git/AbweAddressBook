using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AbweAddressBook.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    ContactId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NickName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.ContactId);
                });

            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "ContactId", "DateCreated", "FirstName", "LastName", "NickName", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 12, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "John", "Doe", "JD", "123-456-7890" },
                    { 2, new DateTime(2024, 1, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jane", "Smith", "JS", "124-379-5860" },
                    { 3, new DateTime(2024, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "John", "Smith", "JS", "140-256-7893" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contacts");
        }
    }
}
