using Microsoft.EntityFrameworkCore.Migrations;

namespace BTAS.Data.Migrations
{
    public partial class ClientHeaderNamingCorrection : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_tbl_client_header_tbl_mawb_tbl_mawb_destionation_id",
            //    table: "tbl_client_header");

            migrationBuilder.RenameColumn(
                name: "tbl_mawb_destionation_id",
                table: "tbl_client_header",
                newName: "tbl_mawb_destination_id");

            migrationBuilder.RenameIndex(
                name: "IX_tbl_client_header_tbl_mawb_destionation_id",
                table: "tbl_client_header",
                newName: "IX_tbl_client_header_tbl_mawb_destination_id");

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_client_header_tbl_mawb_tbl_mawb_destination_id",
                table: "tbl_client_header",
                column: "tbl_mawb_destination_id",
                principalTable: "tbl_mawb",
                principalColumn: "idtbl_mawb",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_tbl_client_header_tbl_mawb_tbl_mawb_destination_id",
            //    table: "tbl_client_header");

            migrationBuilder.RenameColumn(
                name: "tbl_mawb_destination_id",
                table: "tbl_client_header",
                newName: "tbl_mawb_destionation_id");

            migrationBuilder.RenameIndex(
                name: "IX_tbl_client_header_tbl_mawb_destination_id",
                table: "tbl_client_header",
                newName: "IX_tbl_client_header_tbl_mawb_destionation_id");

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_client_header_tbl_mawb_tbl_mawb_destionation_id",
                table: "tbl_client_header",
                column: "tbl_mawb_destionation_id",
                principalTable: "tbl_mawb",
                principalColumn: "idtbl_mawb",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
