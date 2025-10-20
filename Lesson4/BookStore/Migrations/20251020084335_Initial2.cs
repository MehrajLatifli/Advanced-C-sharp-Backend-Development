using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookStore.Migrations
{
    /// <inheritdoc />
    public partial class Initial2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_book",
                table: "book");

            migrationBuilder.DropPrimaryKey(
                name: "PK_author",
                table: "author");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "book",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "book",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "PageCount",
                table: "book",
                newName: "page_count");

            migrationBuilder.RenameColumn(
                name: "City",
                table: "author",
                newName: "city");

            migrationBuilder.RenameColumn(
                name: "Address",
                table: "author",
                newName: "address");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "author",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "author",
                newName: "last_name");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "author",
                newName: "first_name");

            migrationBuilder.AddPrimaryKey(
                name: "pk_book",
                table: "book",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_author",
                table: "author",
                column: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "pk_book",
                table: "book");

            migrationBuilder.DropPrimaryKey(
                name: "pk_author",
                table: "author");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "book",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "book",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "page_count",
                table: "book",
                newName: "PageCount");

            migrationBuilder.RenameColumn(
                name: "city",
                table: "author",
                newName: "City");

            migrationBuilder.RenameColumn(
                name: "address",
                table: "author",
                newName: "Address");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "author",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "last_name",
                table: "author",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "first_name",
                table: "author",
                newName: "FirstName");

            migrationBuilder.AddPrimaryKey(
                name: "PK_book",
                table: "book",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_author",
                table: "author",
                column: "Id");
        }
    }
}
