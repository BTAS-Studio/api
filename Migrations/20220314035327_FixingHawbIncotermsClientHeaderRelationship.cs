using Microsoft.EntityFrameworkCore.Migrations;

namespace BTAS.Data.Migrations
{
    public partial class FixingHawbIncotermsClientHeaderRelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbl_client_header_tbl_hawb_incoterms_tbl_hawb_incoterms_id",
                table: "tbl_client_header");

            migrationBuilder.AlterColumn<int>(
                name: "tbl_hawb_incoterms_id",
                table: "tbl_client_header",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_client_header_tbl_hawb_incoterms_tbl_hawb_incoterms_id",
                table: "tbl_client_header",
                column: "tbl_hawb_incoterms_id",
                principalTable: "tbl_hawb_incoterms",
                principalColumn: "idtbl_hawb_incoterms",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbl_client_header_tbl_hawb_incoterms_tbl_hawb_incoterms_id",
                table: "tbl_client_header");

            migrationBuilder.AlterColumn<int>(
                name: "tbl_hawb_incoterms_id",
                table: "tbl_client_header",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_client_header_tbl_hawb_incoterms_tbl_hawb_incoterms_id",
                table: "tbl_client_header",
                column: "tbl_hawb_incoterms_id",
                principalTable: "tbl_hawb_incoterms",
                principalColumn: "idtbl_hawb_incoterms",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
