using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Librarywebsite.Migrations
{
    /// <inheritdoc />
    public partial class AddedMemberLink : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "isBorrowing",
                table: "Members",
                newName: "IsBorrowing");

            migrationBuilder.RenameColumn(
                name: "isBorrowed",
                table: "Books",
                newName: "IsBorrowed");

            migrationBuilder.AddColumn<int>(
                name: "Age",
                table: "Members",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Members",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "MobileNumber",
                table: "Members",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "NationalId",
                table: "Members",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "Members",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Categyry",
                table: "Books",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "CurrentMemberId",
                table: "Books",
                type: "INTEGER",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Age",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "MobileNumber",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "NationalId",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "Role",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "Categyry",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "CurrentMemberId",
                table: "Books");

            migrationBuilder.RenameColumn(
                name: "IsBorrowing",
                table: "Members",
                newName: "isBorrowing");

            migrationBuilder.RenameColumn(
                name: "IsBorrowed",
                table: "Books",
                newName: "isBorrowed");
        }
    }
}
