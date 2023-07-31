using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BTAS.Data.Migrations
{
    /// <inheritdoc />
    public partial class ChangeNCtableName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "tbl_tbl_note_category",
                newName: "tbl_note_category");

            migrationBuilder.RenameIndex(
                name: "IX_tbl_tbl_note_category_tbl_note_category_name",
                table: "tbl_note_category",
                newName: "IX_tbl_note_category_tbl_note_category_name");

            migrationBuilder.RenameIndex(
                name: "IX_tbl_tbl_note_category_tbl_note_category_code",
                table: "tbl_note_category",
                newName: "IX_tbl_note_category_tbl_note_category_code");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "tbl_note_category",
                newName: "tbl_tbl_note_category");

            migrationBuilder.RenameIndex(
                name: "IX_tbl_note_category_tbl_note_category_name",
                table: "tbl_tbl_note_category",
                newName: "IX_tbl_tbl_note_category_tbl_note_category_name");

            migrationBuilder.RenameIndex(
                name: "IX_tbl_note_category_tbl_note_category_code",
                table: "tbl_tbl_note_category",
                newName: "IX_tbl_tbl_note_category_tbl_note_category_code");
        }
    }
}
