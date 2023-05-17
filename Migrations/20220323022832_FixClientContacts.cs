using Microsoft.EntityFrameworkCore.Migrations;

namespace BTAS.Data.Migrations
{
    public partial class FixClientContacts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbl_client_contact_details_tbl_client_header_tbl_client_head~",
                table: "tbl_client_contact_details");

            migrationBuilder.DropForeignKey(
                name: "FK_tbl_hawb_items_tbl_hawb_tbl_hawb_id",
                table: "tbl_hawb_items");

            migrationBuilder.AlterColumn<int>(
                name: "tbl_hawb_id",
                table: "tbl_hawb_items",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "tbl_client_header_id",
                table: "tbl_client_contact_details",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<bool>(
                name: "tbl_client_contact_details_active",
                table: "tbl_client_contact_details",
                type: "tinyint(1)",
                nullable: true,
                oldClrType: typeof(byte),
                oldType: "tinyint unsigned");

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_client_contact_details_tbl_client_header_tbl_client_head~",
                table: "tbl_client_contact_details",
                column: "tbl_client_header_id",
                principalTable: "tbl_client_header",
                principalColumn: "idtbl_client_header",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_hawb_items_tbl_hawb_tbl_hawb_id",
                table: "tbl_hawb_items",
                column: "tbl_hawb_id",
                principalTable: "tbl_hawb",
                principalColumn: "idtbl_hawb",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbl_client_contact_details_tbl_client_header_tbl_client_head~",
                table: "tbl_client_contact_details");

            migrationBuilder.DropForeignKey(
                name: "FK_tbl_hawb_items_tbl_hawb_tbl_hawb_id",
                table: "tbl_hawb_items");

            migrationBuilder.AlterColumn<int>(
                name: "tbl_hawb_id",
                table: "tbl_hawb_items",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "tbl_client_header_id",
                table: "tbl_client_contact_details",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<byte>(
                name: "tbl_client_contact_details_active",
                table: "tbl_client_contact_details",
                type: "tinyint unsigned",
                nullable: false,
                defaultValue: (byte)0,
                oldClrType: typeof(bool),
                oldType: "tinyint(1)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_client_contact_details_tbl_client_header_tbl_client_head~",
                table: "tbl_client_contact_details",
                column: "tbl_client_header_id",
                principalTable: "tbl_client_header",
                principalColumn: "idtbl_client_header",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_hawb_items_tbl_hawb_tbl_hawb_id",
                table: "tbl_hawb_items",
                column: "tbl_hawb_id",
                principalTable: "tbl_hawb",
                principalColumn: "idtbl_hawb",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
