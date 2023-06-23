using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BTAS.Data.Migrations
{
    /// <inheritdoc />
    public partial class PropertiesTypeChange2Nullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "tbl_voyage_etd",
                table: "tbl_voyage",
                type: "datetime(6)",
                maxLength: 6,
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldMaxLength: 6);

            migrationBuilder.AlterColumn<DateTime>(
                name: "tbl_voyage_eta",
                table: "tbl_voyage",
                type: "datetime(6)",
                maxLength: 6,
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldMaxLength: 6);

            migrationBuilder.AlterColumn<DateTime>(
                name: "tbl_voyage_atd",
                table: "tbl_voyage",
                type: "datetime(6)",
                maxLength: 6,
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldMaxLength: 6);

            migrationBuilder.AlterColumn<DateTime>(
                name: "tbl_voyage_ata",
                table: "tbl_voyage",
                type: "datetime(6)",
                maxLength: 6,
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldMaxLength: 6);

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

            migrationBuilder.AlterColumn<decimal>(
                name: "tbl_receptacle_width",
                table: "tbl_receptacle",
                type: "decimal(12,3)",
                precision: 12,
                scale: 3,
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(12,3)",
                oldPrecision: 12,
                oldScale: 3);

            migrationBuilder.AlterColumn<decimal>(
                name: "tbl_receptacle_weight",
                table: "tbl_receptacle",
                type: "decimal(12,3)",
                precision: 12,
                scale: 3,
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(12,3)",
                oldPrecision: 12,
                oldScale: 3);

            migrationBuilder.AlterColumn<int>(
                name: "tbl_receptacle_qty",
                table: "tbl_receptacle",
                type: "int(11)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int(11)");

            migrationBuilder.AlterColumn<decimal>(
                name: "tbl_receptacle_length",
                table: "tbl_receptacle",
                type: "decimal(12,3)",
                precision: 12,
                scale: 3,
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(12,3)",
                oldPrecision: 12,
                oldScale: 3);

            migrationBuilder.AlterColumn<decimal>(
                name: "tbl_receptacle_height",
                table: "tbl_receptacle",
                type: "decimal(12,3)",
                precision: 12,
                scale: 3,
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(12,3)",
                oldPrecision: 12,
                oldScale: 3);

            migrationBuilder.AlterColumn<DateTime>(
                name: "tbl_receptacle_createdDate",
                table: "tbl_receptacle",
                type: "datetime(6)",
                maxLength: 6,
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldMaxLength: 6);

            migrationBuilder.AlterColumn<byte>(
                name: "tbl_note_status",
                table: "tbl_note",
                type: "tinyint(3) unsigned",
                nullable: true,
                oldClrType: typeof(byte),
                oldType: "tinyint(3) unsigned");

            migrationBuilder.AlterColumn<decimal>(
                name: "tbl_items_width",
                table: "tbl_item_sku",
                type: "decimal(12,3)",
                precision: 12,
                scale: 3,
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(12,3)",
                oldPrecision: 12,
                oldScale: 3);

            migrationBuilder.AlterColumn<decimal>(
                name: "tbl_items_weight",
                table: "tbl_item_sku",
                type: "decimal(12,3)",
                precision: 12,
                scale: 3,
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(12,3)",
                oldPrecision: 12,
                oldScale: 3);

            migrationBuilder.AlterColumn<decimal>(
                name: "tbl_items_volume",
                table: "tbl_item_sku",
                type: "decimal(12,3)",
                precision: 12,
                scale: 3,
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(12,3)",
                oldPrecision: 12,
                oldScale: 3);

            migrationBuilder.AlterColumn<decimal>(
                name: "tbl_items_value",
                table: "tbl_item_sku",
                type: "decimal(12,2)",
                precision: 12,
                scale: 2,
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(12,2)",
                oldPrecision: 12,
                oldScale: 2);

            migrationBuilder.AlterColumn<int>(
                name: "tbl_items_qty",
                table: "tbl_item_sku",
                type: "int(11)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int(11)");

            migrationBuilder.AlterColumn<decimal>(
                name: "tbl_items_length",
                table: "tbl_item_sku",
                type: "decimal(12,3)",
                precision: 12,
                scale: 3,
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(12,3)",
                oldPrecision: 12,
                oldScale: 3);

            migrationBuilder.AlterColumn<decimal>(
                name: "tbl_items_height",
                table: "tbl_item_sku",
                type: "decimal(12,3)",
                precision: 12,
                scale: 3,
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(12,3)",
                oldPrecision: 12,
                oldScale: 3);

            migrationBuilder.AlterColumn<byte>(
                name: "tbl_items_dangerousGoods",
                table: "tbl_item_sku",
                type: "tinyint(3) unsigned",
                nullable: true,
                oldClrType: typeof(byte),
                oldType: "tinyint(3) unsigned");

            migrationBuilder.AlterColumn<decimal>(
                name: "tbl_house_width",
                table: "tbl_house",
                type: "decimal(12,3)",
                precision: 12,
                scale: 3,
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(12,3)",
                oldPrecision: 12,
                oldScale: 3);

            migrationBuilder.AlterColumn<decimal>(
                name: "tbl_house_weight",
                table: "tbl_house",
                type: "decimal(12,3)",
                precision: 12,
                scale: 3,
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(12,3)",
                oldPrecision: 12,
                oldScale: 3);

            migrationBuilder.AlterColumn<decimal>(
                name: "tbl_house_value",
                table: "tbl_house",
                type: "decimal(12,2)",
                precision: 12,
                scale: 2,
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(12,2)",
                oldPrecision: 12,
                oldScale: 2);

            migrationBuilder.AlterColumn<byte>(
                name: "tbl_house_tailLiftO",
                table: "tbl_house",
                type: "tinyint(3) unsigned",
                nullable: true,
                oldClrType: typeof(byte),
                oldType: "tinyint(3) unsigned");

            migrationBuilder.AlterColumn<byte>(
                name: "tbl_house_tailLiftD",
                table: "tbl_house",
                type: "tinyint(3) unsigned",
                nullable: true,
                oldClrType: typeof(byte),
                oldType: "tinyint(3) unsigned");

            migrationBuilder.AlterColumn<int>(
                name: "tbl_house_qty",
                table: "tbl_house",
                type: "int(11)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int(11)");

            migrationBuilder.AlterColumn<decimal>(
                name: "tbl_house_length",
                table: "tbl_house",
                type: "decimal(12,3)",
                precision: 12,
                scale: 3,
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(12,3)",
                oldPrecision: 12,
                oldScale: 3);

            migrationBuilder.AlterColumn<decimal>(
                name: "tbl_house_height",
                table: "tbl_house",
                type: "decimal(12,3)",
                precision: 12,
                scale: 3,
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(12,3)",
                oldPrecision: 12,
                oldScale: 3);

            migrationBuilder.AlterColumn<byte>(
                name: "tbl_house_coo",
                table: "tbl_house",
                type: "tinyint(3) unsigned",
                nullable: true,
                oldClrType: typeof(byte),
                oldType: "tinyint(3) unsigned");

            migrationBuilder.AlterColumn<byte>(
                name: "tbl_house_FTA",
                table: "tbl_house",
                type: "tinyint(3) unsigned",
                nullable: true,
                oldClrType: typeof(byte),
                oldType: "tinyint(3) unsigned");

            migrationBuilder.AlterColumn<byte>(
                name: "tbl_house_DG",
                table: "tbl_house",
                type: "tinyint(3) unsigned",
                nullable: true,
                oldClrType: typeof(byte),
                oldType: "tinyint(3) unsigned");

            migrationBuilder.AlterColumn<byte>(
                name: "tbl_doucument_internalAccess",
                table: "tbl_documents",
                type: "tinyint(3) unsigned",
                nullable: true,
                oldClrType: typeof(byte),
                oldType: "tinyint(3) unsigned");

            migrationBuilder.AlterColumn<byte>(
                name: "tbl_doucument_externalAccess",
                table: "tbl_documents",
                type: "tinyint(3) unsigned",
                nullable: true,
                oldClrType: typeof(byte),
                oldType: "tinyint(3) unsigned");

            migrationBuilder.AlterColumn<byte>(
                name: "tbl_document_status",
                table: "tbl_documents",
                type: "tinyint(3) unsigned",
                nullable: true,
                oldClrType: typeof(byte),
                oldType: "tinyint(3) unsigned");

            migrationBuilder.AlterColumn<bool>(
                name: "tbl_client_header_is_receivable",
                table: "tbl_client_header",
                type: "tinyint(1)",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "tinyint(1)");

            migrationBuilder.AlterColumn<bool>(
                name: "tbl_client_header_is_payable",
                table: "tbl_client_header",
                type: "tinyint(1)",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "tinyint(1)");

            migrationBuilder.AlterColumn<bool>(
                name: "tbl_client_header_is_consignor",
                table: "tbl_client_header",
                type: "tinyint(1)",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "tinyint(1)");

            migrationBuilder.AlterColumn<bool>(
                name: "tbl_client_header_is_consignee",
                table: "tbl_client_header",
                type: "tinyint(1)",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "tinyint(1)");

            migrationBuilder.AlterColumn<bool>(
                name: "tbl_client_header_is_carrier",
                table: "tbl_client_header",
                type: "tinyint(1)",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "tinyint(1)");

            migrationBuilder.AlterColumn<bool>(
                name: "tbl_client_header_is_broker",
                table: "tbl_client_header",
                type: "tinyint(1)",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "tinyint(1)");

            migrationBuilder.AlterColumn<bool>(
                name: "tbl_client_header_is_agent",
                table: "tbl_client_header",
                type: "tinyint(1)",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "tinyint(1)");

            migrationBuilder.AlterColumn<bool>(
                name: "tbl_client_header_active",
                table: "tbl_client_header",
                type: "tinyint(1)",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "tinyint(1)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "tbl_voyage_etd",
                table: "tbl_voyage",
                type: "datetime(6)",
                maxLength: 6,
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldMaxLength: 6,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "tbl_voyage_eta",
                table: "tbl_voyage",
                type: "datetime(6)",
                maxLength: 6,
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldMaxLength: 6,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "tbl_voyage_atd",
                table: "tbl_voyage",
                type: "datetime(6)",
                maxLength: 6,
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldMaxLength: 6,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "tbl_voyage_ata",
                table: "tbl_voyage",
                type: "datetime(6)",
                maxLength: 6,
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldMaxLength: 6,
                oldNullable: true);

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

            migrationBuilder.AlterColumn<decimal>(
                name: "tbl_receptacle_width",
                table: "tbl_receptacle",
                type: "decimal(12,3)",
                precision: 12,
                scale: 3,
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(12,3)",
                oldPrecision: 12,
                oldScale: 3,
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "tbl_receptacle_weight",
                table: "tbl_receptacle",
                type: "decimal(12,3)",
                precision: 12,
                scale: 3,
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(12,3)",
                oldPrecision: 12,
                oldScale: 3,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "tbl_receptacle_qty",
                table: "tbl_receptacle",
                type: "int(11)",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int(11)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "tbl_receptacle_length",
                table: "tbl_receptacle",
                type: "decimal(12,3)",
                precision: 12,
                scale: 3,
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(12,3)",
                oldPrecision: 12,
                oldScale: 3,
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "tbl_receptacle_height",
                table: "tbl_receptacle",
                type: "decimal(12,3)",
                precision: 12,
                scale: 3,
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(12,3)",
                oldPrecision: 12,
                oldScale: 3,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "tbl_receptacle_createdDate",
                table: "tbl_receptacle",
                type: "datetime(6)",
                maxLength: 6,
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldMaxLength: 6,
                oldNullable: true);

            migrationBuilder.AlterColumn<byte>(
                name: "tbl_note_status",
                table: "tbl_note",
                type: "tinyint(3) unsigned",
                nullable: false,
                defaultValue: (byte)0,
                oldClrType: typeof(byte),
                oldType: "tinyint(3) unsigned",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "tbl_items_width",
                table: "tbl_item_sku",
                type: "decimal(12,3)",
                precision: 12,
                scale: 3,
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(12,3)",
                oldPrecision: 12,
                oldScale: 3,
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "tbl_items_weight",
                table: "tbl_item_sku",
                type: "decimal(12,3)",
                precision: 12,
                scale: 3,
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(12,3)",
                oldPrecision: 12,
                oldScale: 3,
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "tbl_items_volume",
                table: "tbl_item_sku",
                type: "decimal(12,3)",
                precision: 12,
                scale: 3,
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(12,3)",
                oldPrecision: 12,
                oldScale: 3,
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "tbl_items_value",
                table: "tbl_item_sku",
                type: "decimal(12,2)",
                precision: 12,
                scale: 2,
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(12,2)",
                oldPrecision: 12,
                oldScale: 2,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "tbl_items_qty",
                table: "tbl_item_sku",
                type: "int(11)",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int(11)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "tbl_items_length",
                table: "tbl_item_sku",
                type: "decimal(12,3)",
                precision: 12,
                scale: 3,
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(12,3)",
                oldPrecision: 12,
                oldScale: 3,
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "tbl_items_height",
                table: "tbl_item_sku",
                type: "decimal(12,3)",
                precision: 12,
                scale: 3,
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(12,3)",
                oldPrecision: 12,
                oldScale: 3,
                oldNullable: true);

            migrationBuilder.AlterColumn<byte>(
                name: "tbl_items_dangerousGoods",
                table: "tbl_item_sku",
                type: "tinyint(3) unsigned",
                nullable: false,
                defaultValue: (byte)0,
                oldClrType: typeof(byte),
                oldType: "tinyint(3) unsigned",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "tbl_house_width",
                table: "tbl_house",
                type: "decimal(12,3)",
                precision: 12,
                scale: 3,
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(12,3)",
                oldPrecision: 12,
                oldScale: 3,
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "tbl_house_weight",
                table: "tbl_house",
                type: "decimal(12,3)",
                precision: 12,
                scale: 3,
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(12,3)",
                oldPrecision: 12,
                oldScale: 3,
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "tbl_house_value",
                table: "tbl_house",
                type: "decimal(12,2)",
                precision: 12,
                scale: 2,
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(12,2)",
                oldPrecision: 12,
                oldScale: 2,
                oldNullable: true);

            migrationBuilder.AlterColumn<byte>(
                name: "tbl_house_tailLiftO",
                table: "tbl_house",
                type: "tinyint(3) unsigned",
                nullable: false,
                defaultValue: (byte)0,
                oldClrType: typeof(byte),
                oldType: "tinyint(3) unsigned",
                oldNullable: true);

            migrationBuilder.AlterColumn<byte>(
                name: "tbl_house_tailLiftD",
                table: "tbl_house",
                type: "tinyint(3) unsigned",
                nullable: false,
                defaultValue: (byte)0,
                oldClrType: typeof(byte),
                oldType: "tinyint(3) unsigned",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "tbl_house_qty",
                table: "tbl_house",
                type: "int(11)",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int(11)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "tbl_house_length",
                table: "tbl_house",
                type: "decimal(12,3)",
                precision: 12,
                scale: 3,
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(12,3)",
                oldPrecision: 12,
                oldScale: 3,
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "tbl_house_height",
                table: "tbl_house",
                type: "decimal(12,3)",
                precision: 12,
                scale: 3,
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(12,3)",
                oldPrecision: 12,
                oldScale: 3,
                oldNullable: true);

            migrationBuilder.AlterColumn<byte>(
                name: "tbl_house_coo",
                table: "tbl_house",
                type: "tinyint(3) unsigned",
                nullable: false,
                defaultValue: (byte)0,
                oldClrType: typeof(byte),
                oldType: "tinyint(3) unsigned",
                oldNullable: true);

            migrationBuilder.AlterColumn<byte>(
                name: "tbl_house_FTA",
                table: "tbl_house",
                type: "tinyint(3) unsigned",
                nullable: false,
                defaultValue: (byte)0,
                oldClrType: typeof(byte),
                oldType: "tinyint(3) unsigned",
                oldNullable: true);

            migrationBuilder.AlterColumn<byte>(
                name: "tbl_house_DG",
                table: "tbl_house",
                type: "tinyint(3) unsigned",
                nullable: false,
                defaultValue: (byte)0,
                oldClrType: typeof(byte),
                oldType: "tinyint(3) unsigned",
                oldNullable: true);

            migrationBuilder.AlterColumn<byte>(
                name: "tbl_doucument_internalAccess",
                table: "tbl_documents",
                type: "tinyint(3) unsigned",
                nullable: false,
                defaultValue: (byte)0,
                oldClrType: typeof(byte),
                oldType: "tinyint(3) unsigned",
                oldNullable: true);

            migrationBuilder.AlterColumn<byte>(
                name: "tbl_doucument_externalAccess",
                table: "tbl_documents",
                type: "tinyint(3) unsigned",
                nullable: false,
                defaultValue: (byte)0,
                oldClrType: typeof(byte),
                oldType: "tinyint(3) unsigned",
                oldNullable: true);

            migrationBuilder.AlterColumn<byte>(
                name: "tbl_document_status",
                table: "tbl_documents",
                type: "tinyint(3) unsigned",
                nullable: false,
                defaultValue: (byte)0,
                oldClrType: typeof(byte),
                oldType: "tinyint(3) unsigned",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "tbl_client_header_is_receivable",
                table: "tbl_client_header",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "tinyint(1)",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "tbl_client_header_is_payable",
                table: "tbl_client_header",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "tinyint(1)",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "tbl_client_header_is_consignor",
                table: "tbl_client_header",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "tinyint(1)",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "tbl_client_header_is_consignee",
                table: "tbl_client_header",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "tinyint(1)",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "tbl_client_header_is_carrier",
                table: "tbl_client_header",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "tinyint(1)",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "tbl_client_header_is_broker",
                table: "tbl_client_header",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "tinyint(1)",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "tbl_client_header_is_agent",
                table: "tbl_client_header",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "tinyint(1)",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "tbl_client_header_active",
                table: "tbl_client_header",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "tinyint(1)",
                oldNullable: true);
        }
    }
}
