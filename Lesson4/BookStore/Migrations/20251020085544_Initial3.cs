using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookStore.Migrations
{
    /// <inheritdoc />
    public partial class Initial3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "author_id",
                table: "book",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "ix_book_author_id",
                table: "book",
                column: "author_id");

            migrationBuilder.AddForeignKey(
                name: "fk_book_author_author_id",
                table: "book",
                column: "author_id",
                principalTable: "author",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_book_author_author_id",
                table: "book");

            migrationBuilder.DropIndex(
                name: "ix_book_author_id",
                table: "book");

            migrationBuilder.DropColumn(
                name: "author_id",
                table: "book");
        }
    }
}
