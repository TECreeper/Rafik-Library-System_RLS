using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Librarywebsite.Migrations
{
    /// <inheritdoc />
    public partial class AddedMemberLi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateOnly>(
                name: "BorrowDate",
                table: "Books",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BorrowDate",
                table: "Books");
        }
    }
}
