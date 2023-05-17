using Microsoft.EntityFrameworkCore.Migrations;

namespace BTAS.Data.Migrations
{
    public partial class FixMawbClientHeaderRelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbl_client_header_tbl_mawb_tbl_mawb_carrier_id",
                table: "tbl_client_header");

            migrationBuilder.DropForeignKey(
                name: "FK_tbl_client_header_tbl_mawb_tbl_mawb_creditor_id",
                table: "tbl_client_header");

            migrationBuilder.DropForeignKey(
                name: "FK_tbl_client_header_tbl_mawb_tbl_mawb_destination_id",
                table: "tbl_client_header");

            migrationBuilder.DropForeignKey(
                name: "FK_tbl_client_header_tbl_mawb_tbl_mawb_origin_id",
                table: "tbl_client_header");

            migrationBuilder.DropIndex(
                name: "IX_tbl_client_header_tbl_mawb_carrier_id",
                table: "tbl_client_header");

            migrationBuilder.DropIndex(
                name: "IX_tbl_client_header_tbl_mawb_creditor_id",
                table: "tbl_client_header");

            migrationBuilder.DropIndex(
                name: "IX_tbl_client_header_tbl_mawb_destination_id",
                table: "tbl_client_header");

            migrationBuilder.DropIndex(
                name: "IX_tbl_client_header_tbl_mawb_origin_id",
                table: "tbl_client_header");

            migrationBuilder.DropColumn(
                name: "tbl_mawb_carrier_id",
                table: "tbl_client_header");

            migrationBuilder.DropColumn(
                name: "tbl_mawb_creditor_id",
                table: "tbl_client_header");

            migrationBuilder.DropColumn(
                name: "tbl_mawb_destination_id",
                table: "tbl_client_header");

            migrationBuilder.DropColumn(
                name: "tbl_mawb_origin_id",
                table: "tbl_client_header");

            migrationBuilder.AddColumn<int>(
                name: "tbl_client_header_carrier_id",
                table: "tbl_mawb",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "tbl_client_header_creditor_id",
                table: "tbl_mawb",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "tbl_client_header_destination_id",
                table: "tbl_mawb",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "tbl_client_header_origin_id",
                table: "tbl_mawb",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_tbl_mawb_tbl_client_header_carrier_id",
                table: "tbl_mawb",
                column: "tbl_client_header_carrier_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_mawb_tbl_client_header_creditor_id",
                table: "tbl_mawb",
                column: "tbl_client_header_creditor_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_mawb_tbl_client_header_destination_id",
                table: "tbl_mawb",
                column: "tbl_client_header_destination_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_mawb_tbl_client_header_origin_id",
                table: "tbl_mawb",
                column: "tbl_client_header_origin_id");

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_mawb_tbl_client_header_tbl_client_header_carrier_id",
                table: "tbl_mawb",
                column: "tbl_client_header_carrier_id",
                principalTable: "tbl_client_header",
                principalColumn: "idtbl_client_header",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_mawb_tbl_client_header_tbl_client_header_creditor_id",
                table: "tbl_mawb",
                column: "tbl_client_header_creditor_id",
                principalTable: "tbl_client_header",
                principalColumn: "idtbl_client_header",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_mawb_tbl_client_header_tbl_client_header_destination_id",
                table: "tbl_mawb",
                column: "tbl_client_header_destination_id",
                principalTable: "tbl_client_header",
                principalColumn: "idtbl_client_header",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_mawb_tbl_client_header_tbl_client_header_origin_id",
                table: "tbl_mawb",
                column: "tbl_client_header_origin_id",
                principalTable: "tbl_client_header",
                principalColumn: "idtbl_client_header",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbl_mawb_tbl_client_header_tbl_client_header_carrier_id",
                table: "tbl_mawb");

            migrationBuilder.DropForeignKey(
                name: "FK_tbl_mawb_tbl_client_header_tbl_client_header_creditor_id",
                table: "tbl_mawb");

            migrationBuilder.DropForeignKey(
                name: "FK_tbl_mawb_tbl_client_header_tbl_client_header_destination_id",
                table: "tbl_mawb");

            migrationBuilder.DropForeignKey(
                name: "FK_tbl_mawb_tbl_client_header_tbl_client_header_origin_id",
                table: "tbl_mawb");

            migrationBuilder.DropIndex(
                name: "IX_tbl_mawb_tbl_client_header_carrier_id",
                table: "tbl_mawb");

            migrationBuilder.DropIndex(
                name: "IX_tbl_mawb_tbl_client_header_creditor_id",
                table: "tbl_mawb");

            migrationBuilder.DropIndex(
                name: "IX_tbl_mawb_tbl_client_header_destination_id",
                table: "tbl_mawb");

            migrationBuilder.DropIndex(
                name: "IX_tbl_mawb_tbl_client_header_origin_id",
                table: "tbl_mawb");

            migrationBuilder.DropColumn(
                name: "tbl_client_header_carrier_id",
                table: "tbl_mawb");

            migrationBuilder.DropColumn(
                name: "tbl_client_header_creditor_id",
                table: "tbl_mawb");

            migrationBuilder.DropColumn(
                name: "tbl_client_header_destination_id",
                table: "tbl_mawb");

            migrationBuilder.DropColumn(
                name: "tbl_client_header_origin_id",
                table: "tbl_mawb");

            migrationBuilder.AddColumn<int>(
                name: "tbl_mawb_carrier_id",
                table: "tbl_client_header",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "tbl_mawb_creditor_id",
                table: "tbl_client_header",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "tbl_mawb_destination_id",
                table: "tbl_client_header",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "tbl_mawb_origin_id",
                table: "tbl_client_header",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_tbl_client_header_tbl_mawb_carrier_id",
                table: "tbl_client_header",
                column: "tbl_mawb_carrier_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_client_header_tbl_mawb_creditor_id",
                table: "tbl_client_header",
                column: "tbl_mawb_creditor_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_client_header_tbl_mawb_destination_id",
                table: "tbl_client_header",
                column: "tbl_mawb_destination_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_client_header_tbl_mawb_origin_id",
                table: "tbl_client_header",
                column: "tbl_mawb_origin_id");

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_client_header_tbl_mawb_tbl_mawb_carrier_id",
                table: "tbl_client_header",
                column: "tbl_mawb_carrier_id",
                principalTable: "tbl_mawb",
                principalColumn: "idtbl_mawb",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_client_header_tbl_mawb_tbl_mawb_creditor_id",
                table: "tbl_client_header",
                column: "tbl_mawb_creditor_id",
                principalTable: "tbl_mawb",
                principalColumn: "idtbl_mawb",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_client_header_tbl_mawb_tbl_mawb_destination_id",
                table: "tbl_client_header",
                column: "tbl_mawb_destination_id",
                principalTable: "tbl_mawb",
                principalColumn: "idtbl_mawb",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_client_header_tbl_mawb_tbl_mawb_origin_id",
                table: "tbl_client_header",
                column: "tbl_mawb_origin_id",
                principalTable: "tbl_mawb",
                principalColumn: "idtbl_mawb",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
