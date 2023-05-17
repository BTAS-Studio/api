using Microsoft.EntityFrameworkCore.Migrations;

namespace BTAS.Data.Migrations
{
    public partial class FixMawbVoyageRelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbl_mawb_tbl_voyage_tbl_mawb_voyage_id",
                table: "tbl_mawb");

            migrationBuilder.DropIndex(
                name: "IX_tbl_mawb_tbl_mawb_voyage_id",
                table: "tbl_mawb");

            migrationBuilder.DropColumn(
                name: "tbl_mawb_voyage_id",
                table: "tbl_mawb");

            migrationBuilder.AddColumn<int>(
                name: "tbl_mawb_id",
                table: "tbl_voyage",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_tbl_voyage_tbl_mawb_id",
                table: "tbl_voyage",
                column: "tbl_mawb_id");

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_voyage_tbl_mawb_tbl_mawb_id",
                table: "tbl_voyage",
                column: "tbl_mawb_id",
                principalTable: "tbl_mawb",
                principalColumn: "idtbl_mawb",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbl_voyage_tbl_mawb_tbl_mawb_id",
                table: "tbl_voyage");

            migrationBuilder.DropIndex(
                name: "IX_tbl_voyage_tbl_mawb_id",
                table: "tbl_voyage");

            migrationBuilder.DropColumn(
                name: "tbl_mawb_id",
                table: "tbl_voyage");

            migrationBuilder.AddColumn<int>(
                name: "tbl_mawb_voyage_id",
                table: "tbl_mawb",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_tbl_mawb_tbl_mawb_voyage_id",
                table: "tbl_mawb",
                column: "tbl_mawb_voyage_id");

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_mawb_tbl_voyage_tbl_mawb_voyage_id",
                table: "tbl_mawb",
                column: "tbl_mawb_voyage_id",
                principalTable: "tbl_voyage",
                principalColumn: "idtbl_voyage",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
