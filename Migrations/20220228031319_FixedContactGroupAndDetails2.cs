using Microsoft.EntityFrameworkCore.Migrations;

namespace BTAS.Data.Migrations
{
    public partial class FixedContactGroupAndDetails2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbl_client_header_tbl_hawb_tbl_hawb_id",
                table: "tbl_client_header");

            migrationBuilder.DropIndex(
                name: "IX_tbl_client_header_tbl_hawb_id",
                table: "tbl_client_header");

            migrationBuilder.DropColumn(
                name: "tbl_hawb_id",
                table: "tbl_client_header");

            migrationBuilder.AddColumn<int>(
                name: "tbl_client_header_id",
                table: "tbl_hawb",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_tbl_hawb_tbl_client_header_id",
                table: "tbl_hawb",
                column: "tbl_client_header_id");

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_hawb_tbl_client_header_tbl_client_header_id",
                table: "tbl_hawb",
                column: "tbl_client_header_id",
                principalTable: "tbl_client_header",
                principalColumn: "idtbl_client_header",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbl_hawb_tbl_client_header_tbl_client_header_id",
                table: "tbl_hawb");

            migrationBuilder.DropIndex(
                name: "IX_tbl_hawb_tbl_client_header_id",
                table: "tbl_hawb");

            migrationBuilder.DropColumn(
                name: "tbl_client_header_id",
                table: "tbl_hawb");

            migrationBuilder.AddColumn<int>(
                name: "tbl_hawb_id",
                table: "tbl_client_header",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_tbl_client_header_tbl_hawb_id",
                table: "tbl_client_header",
                column: "tbl_hawb_id");

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_client_header_tbl_hawb_tbl_hawb_id",
                table: "tbl_client_header",
                column: "tbl_hawb_id",
                principalTable: "tbl_hawb",
                principalColumn: "idtbl_hawb",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
