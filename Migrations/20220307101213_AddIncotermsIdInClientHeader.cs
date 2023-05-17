using Microsoft.EntityFrameworkCore.Migrations;

namespace BTAS.Data.Migrations
{
    public partial class AddIncotermsIdInClientHeader : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "tbl_hawb_incoterms_id",
                table: "tbl_client_header",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_tbl_client_header_tbl_hawb_incoterms_id",
                table: "tbl_client_header",
                column: "tbl_hawb_incoterms_id");

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_client_header_tbl_hawb_incoterms_tbl_hawb_incoterms_id",
                table: "tbl_client_header",
                column: "tbl_hawb_incoterms_id",
                principalTable: "tbl_hawb_incoterms",
                principalColumn: "idtbl_hawb_incoterms",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbl_client_header_tbl_hawb_incoterms_tbl_hawb_incoterms_id",
                table: "tbl_client_header");

            migrationBuilder.DropIndex(
                name: "IX_tbl_client_header_tbl_hawb_incoterms_id",
                table: "tbl_client_header");

            migrationBuilder.DropColumn(
                name: "tbl_hawb_incoterms_id",
                table: "tbl_client_header");
        }
    }
}
