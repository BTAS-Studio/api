using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BTAS.Data.Migrations
{
    public partial class FixMawbNullableFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<int>(
                name: "tbl_client_header_origin_id",
                table: "tbl_mawb",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "tbl_client_header_destination_id",
                table: "tbl_mawb",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "tbl_client_header_creditor_id",
                table: "tbl_mawb",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "tbl_client_header_carrier_id",
                table: "tbl_mawb",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_mawb_tbl_client_header_tbl_client_header_carrier_id",
                table: "tbl_mawb",
                column: "tbl_client_header_carrier_id",
                principalTable: "tbl_client_header",
                principalColumn: "idtbl_client_header",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_mawb_tbl_client_header_tbl_client_header_creditor_id",
                table: "tbl_mawb",
                column: "tbl_client_header_creditor_id",
                principalTable: "tbl_client_header",
                principalColumn: "idtbl_client_header",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_mawb_tbl_client_header_tbl_client_header_destination_id",
                table: "tbl_mawb",
                column: "tbl_client_header_destination_id",
                principalTable: "tbl_client_header",
                principalColumn: "idtbl_client_header",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_mawb_tbl_client_header_tbl_client_header_origin_id",
                table: "tbl_mawb",
                column: "tbl_client_header_origin_id",
                principalTable: "tbl_client_header",
                principalColumn: "idtbl_client_header",
                onDelete: ReferentialAction.Restrict);
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

            migrationBuilder.AlterColumn<int>(
                name: "tbl_client_header_origin_id",
                table: "tbl_mawb",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "tbl_client_header_destination_id",
                table: "tbl_mawb",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "tbl_client_header_creditor_id",
                table: "tbl_mawb",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "tbl_client_header_carrier_id",
                table: "tbl_mawb",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

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
    }
}
