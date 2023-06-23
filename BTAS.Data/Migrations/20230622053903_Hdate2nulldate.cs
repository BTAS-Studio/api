using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BTAS.Data.Migrations
{
    /// <inheritdoc />
    public partial class Hdate2nulldate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "tbl_sea_shipment_weight",
                table: "tbl_sea_shipment",
                type: "decimal(10)",
                precision: 10,
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(10,30)",
                oldPrecision: 10,
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "tbl_sea_shipment_volume",
                table: "tbl_sea_shipment",
                type: "decimal(10)",
                precision: 10,
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(10,30)",
                oldPrecision: 10,
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "tbl_sea_shipment_value",
                table: "tbl_sea_shipment",
                type: "decimal(10)",
                precision: 10,
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(10,30)",
                oldPrecision: 10,
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "tbl_sea_shipment_UN",
                table: "tbl_sea_shipment",
                type: "decimal(10)",
                precision: 10,
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(10,30)",
                oldPrecision: 10,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "tbl_note_createdDate",
                table: "tbl_note",
                type: "datetime(6)",
                maxLength: 6,
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldMaxLength: 6);

            migrationBuilder.AlterColumn<DateTime>(
                name: "tbl_milestone_link_value",
                table: "tbl_milestone_link",
                type: "datetime(6)",
                maxLength: 6,
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldMaxLength: 6);

            migrationBuilder.AlterColumn<DateTime>(
                name: "tbl_milestone_link_createdDate",
                table: "tbl_milestone_link",
                type: "datetime(6)",
                maxLength: 6,
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldMaxLength: 6);

            migrationBuilder.AlterColumn<DateTime>(
                name: "tbl_milestone_header_createdDate",
                table: "tbl_milestone_header",
                type: "datetime(6)",
                maxLength: 6,
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldMaxLength: 6);

            migrationBuilder.AlterColumn<DateTime>(
                name: "tbl_house_deliveryDate",
                table: "tbl_house",
                type: "datetime(6)",
                maxLength: 6,
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldMaxLength: 6);

            migrationBuilder.AlterColumn<DateTime>(
                name: "tbl_house_createdDate",
                table: "tbl_house",
                type: "datetime(6)",
                maxLength: 6,
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldMaxLength: 6);

            migrationBuilder.AlterColumn<DateTime>(
                name: "tbl_document_createdDate",
                table: "tbl_documents",
                type: "datetime(6)",
                maxLength: 6,
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldMaxLength: 6);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "tbl_sea_shipment_weight",
                table: "tbl_sea_shipment",
                type: "decimal(10,30)",
                precision: 10,
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(10)",
                oldPrecision: 10,
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "tbl_sea_shipment_volume",
                table: "tbl_sea_shipment",
                type: "decimal(10,30)",
                precision: 10,
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(10)",
                oldPrecision: 10,
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "tbl_sea_shipment_value",
                table: "tbl_sea_shipment",
                type: "decimal(10,30)",
                precision: 10,
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(10)",
                oldPrecision: 10,
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "tbl_sea_shipment_UN",
                table: "tbl_sea_shipment",
                type: "decimal(10,30)",
                precision: 10,
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(10)",
                oldPrecision: 10,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "tbl_note_createdDate",
                table: "tbl_note",
                type: "datetime(6)",
                maxLength: 6,
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldMaxLength: 6,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "tbl_milestone_link_value",
                table: "tbl_milestone_link",
                type: "datetime(6)",
                maxLength: 6,
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldMaxLength: 6,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "tbl_milestone_link_createdDate",
                table: "tbl_milestone_link",
                type: "datetime(6)",
                maxLength: 6,
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldMaxLength: 6,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "tbl_milestone_header_createdDate",
                table: "tbl_milestone_header",
                type: "datetime(6)",
                maxLength: 6,
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldMaxLength: 6,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "tbl_house_deliveryDate",
                table: "tbl_house",
                type: "datetime(6)",
                maxLength: 6,
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldMaxLength: 6,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "tbl_house_createdDate",
                table: "tbl_house",
                type: "datetime(6)",
                maxLength: 6,
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldMaxLength: 6,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "tbl_document_createdDate",
                table: "tbl_documents",
                type: "datetime(6)",
                maxLength: 6,
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldMaxLength: 6,
                oldNullable: true);
        }
    }
}
