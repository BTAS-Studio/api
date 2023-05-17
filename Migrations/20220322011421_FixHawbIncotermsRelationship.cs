using Microsoft.EntityFrameworkCore.Migrations;

namespace BTAS.Data.Migrations
{
    public partial class FixHawbIncotermsRelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbl_hawb_tbl_hawb_incoterms_tbl_hawb_incoterms_id",
                table: "tbl_hawb");

            migrationBuilder.DropIndex(
                name: "IX_tbl_hawb_tbl_hawb_incoterms_id",
                table: "tbl_hawb");

            migrationBuilder.DropColumn(
                name: "tbl_hawb_incoterms_id",
                table: "tbl_hawb");

            migrationBuilder.AddColumn<int>(
                name: "tbl_hawb_id",
                table: "tbl_hawb_incoterms",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_tbl_hawb_incoterms_tbl_hawb_id",
                table: "tbl_hawb_incoterms",
                column: "tbl_hawb_id");

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_hawb_incoterms_tbl_hawb_tbl_hawb_id",
                table: "tbl_hawb_incoterms",
                column: "tbl_hawb_id",
                principalTable: "tbl_hawb",
                principalColumn: "idtbl_hawb",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbl_hawb_incoterms_tbl_hawb_tbl_hawb_id",
                table: "tbl_hawb_incoterms");

            migrationBuilder.DropIndex(
                name: "IX_tbl_hawb_incoterms_tbl_hawb_id",
                table: "tbl_hawb_incoterms");

            migrationBuilder.DropColumn(
                name: "tbl_hawb_id",
                table: "tbl_hawb_incoterms");

            migrationBuilder.AddColumn<int>(
                name: "tbl_hawb_incoterms_id",
                table: "tbl_hawb",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_tbl_hawb_tbl_hawb_incoterms_id",
                table: "tbl_hawb",
                column: "tbl_hawb_incoterms_id");

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_hawb_tbl_hawb_incoterms_tbl_hawb_incoterms_id",
                table: "tbl_hawb",
                column: "tbl_hawb_incoterms_id",
                principalTable: "tbl_hawb_incoterms",
                principalColumn: "idtbl_hawb_incoterms",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
