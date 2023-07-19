using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BTAS.Data.Migrations
{
    /// <inheritdoc />
    public partial class UniqueContrainsAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_tbl_voyage_tbl_voyage_number_tbl_voyage_carrierCode_tbl_voya~",
                table: "tbl_voyage");

            migrationBuilder.DropIndex(
                name: "IX_tbl_shipment_tbl_shipment_trackingNo_tbl_shipment_referenceNo",
                table: "tbl_shipment");

            migrationBuilder.DropIndex(
                name: "IX_tbl_master_tbl_master_billNumber_tbl_master_status",
                table: "tbl_master");

            migrationBuilder.DropIndex(
                name: "IX_tbl_house_tbl_house_billNumber_tbl_house_value",
                table: "tbl_house");

            migrationBuilder.DropIndex(
                name: "IX_tbl_container_tbl_container_number_tbl_container_sealNumber",
                table: "tbl_container");

            migrationBuilder.DropIndex(
                name: "IX_tbl_client_header_tbl_client_header_companyName_tbl_client_h~",
                table: "tbl_client_header");

            migrationBuilder.DropIndex(
                name: "IX_tbl_address_tbl_address_companyName_tbl_address_postcode_tbl~",
                table: "tbl_address");

            migrationBuilder.UpdateData(
                table: "tbl_voyage",
                keyColumn: "tbl_voyage_number",
                keyValue: null,
                column: "tbl_voyage_number",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "tbl_voyage_number",
                table: "tbl_voyage",
                type: "varchar(30)",
                maxLength: 30,
                nullable: false,
                collation: "utf8mb4_general_ci",
                oldClrType: typeof(string),
                oldType: "varchar(30)",
                oldMaxLength: 30,
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("Relational:Collation", "utf8mb4_general_ci");

            migrationBuilder.AlterColumn<DateTime>(
                name: "tbl_voyage_etd",
                table: "tbl_voyage",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "tbl_voyage",
                keyColumn: "tbl_voyage_carrierCode",
                keyValue: null,
                column: "tbl_voyage_carrierCode",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "tbl_voyage_carrierCode",
                table: "tbl_voyage",
                type: "varchar(30)",
                maxLength: 30,
                nullable: false,
                collation: "utf8mb4_general_ci",
                oldClrType: typeof(string),
                oldType: "varchar(30)",
                oldMaxLength: 30,
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("Relational:Collation", "utf8mb4_general_ci");

            migrationBuilder.UpdateData(
                table: "tbl_tbl_note_category",
                keyColumn: "tbl_note_category_name",
                keyValue: null,
                column: "tbl_note_category_name",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "tbl_note_category_name",
                table: "tbl_tbl_note_category",
                type: "varchar(50)",
                maxLength: 50,
                nullable: false,
                collation: "utf8mb4_general_ci",
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldMaxLength: 50,
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("Relational:Collation", "utf8mb4_general_ci");

            migrationBuilder.UpdateData(
                table: "tbl_shipment",
                keyColumn: "tbl_shipment_trackingNo",
                keyValue: null,
                column: "tbl_shipment_trackingNo",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "tbl_shipment_trackingNo",
                table: "tbl_shipment",
                type: "varchar(50)",
                maxLength: 50,
                nullable: false,
                collation: "utf8mb4_general_ci",
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldMaxLength: 50,
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("Relational:Collation", "utf8mb4_general_ci");

            migrationBuilder.UpdateData(
                table: "tbl_shipment",
                keyColumn: "tbl_shipment_referenceNo",
                keyValue: null,
                column: "tbl_shipment_referenceNo",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "tbl_shipment_referenceNo",
                table: "tbl_shipment",
                type: "varchar(50)",
                maxLength: 50,
                nullable: false,
                collation: "utf8mb4_general_ci",
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldMaxLength: 50,
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("Relational:Collation", "utf8mb4_general_ci");

            migrationBuilder.UpdateData(
                table: "tbl_milestone_header",
                keyColumn: "tbl_milestone_header_name",
                keyValue: null,
                column: "tbl_milestone_header_name",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "tbl_milestone_header_name",
                table: "tbl_milestone_header",
                type: "varchar(50)",
                maxLength: 50,
                nullable: false,
                collation: "utf8mb4_general_ci",
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldMaxLength: 50,
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("Relational:Collation", "utf8mb4_general_ci");

            migrationBuilder.UpdateData(
                table: "tbl_master",
                keyColumn: "tbl_master_status",
                keyValue: null,
                column: "tbl_master_status",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "tbl_master_status",
                table: "tbl_master",
                type: "varchar(50)",
                maxLength: 50,
                nullable: false,
                collation: "utf8mb4_general_ci",
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldMaxLength: 50,
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("Relational:Collation", "utf8mb4_general_ci");

            migrationBuilder.UpdateData(
                table: "tbl_master",
                keyColumn: "tbl_master_billNumber",
                keyValue: null,
                column: "tbl_master_billNumber",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "tbl_master_billNumber",
                table: "tbl_master",
                type: "varchar(50)",
                maxLength: 50,
                nullable: false,
                collation: "utf8mb4_general_ci",
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldMaxLength: 50,
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("Relational:Collation", "utf8mb4_general_ci");

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

            migrationBuilder.UpdateData(
                table: "tbl_house",
                keyColumn: "tbl_house_billNumber",
                keyValue: null,
                column: "tbl_house_billNumber",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "tbl_house_billNumber",
                table: "tbl_house",
                type: "varchar(50)",
                maxLength: 50,
                nullable: false,
                collation: "utf8mb4_general_ci",
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldMaxLength: 50,
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("Relational:Collation", "utf8mb4_general_ci");

            migrationBuilder.UpdateData(
                table: "tbl_container",
                keyColumn: "tbl_container_sealNumber",
                keyValue: null,
                column: "tbl_container_sealNumber",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "tbl_container_sealNumber",
                table: "tbl_container",
                type: "varchar(50)",
                maxLength: 50,
                nullable: false,
                collation: "utf8mb4_general_ci",
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldMaxLength: 50,
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("Relational:Collation", "utf8mb4_general_ci");

            migrationBuilder.UpdateData(
                table: "tbl_container",
                keyColumn: "tbl_container_number",
                keyValue: null,
                column: "tbl_container_number",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "tbl_container_number",
                table: "tbl_container",
                type: "varchar(50)",
                maxLength: 50,
                nullable: false,
                collation: "utf8mb4_general_ci",
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldMaxLength: 50,
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("Relational:Collation", "utf8mb4_general_ci");

            migrationBuilder.UpdateData(
                table: "tbl_client_header",
                keyColumn: "tbl_client_header_postcode",
                keyValue: null,
                column: "tbl_client_header_postcode",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "tbl_client_header_postcode",
                table: "tbl_client_header",
                type: "varchar(50)",
                maxLength: 50,
                nullable: false,
                collation: "utf8mb4_general_ci",
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldMaxLength: 50,
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("Relational:Collation", "utf8mb4_general_ci");

            migrationBuilder.UpdateData(
                table: "tbl_client_header",
                keyColumn: "tbl_client_header_companyName",
                keyValue: null,
                column: "tbl_client_header_companyName",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "tbl_client_header_companyName",
                table: "tbl_client_header",
                type: "varchar(150)",
                maxLength: 150,
                nullable: false,
                collation: "utf8mb4_general_ci",
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldMaxLength: 100,
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("Relational:Collation", "utf8mb4_general_ci");

            migrationBuilder.UpdateData(
                table: "tbl_client_header",
                keyColumn: "tbl_client_header_address1",
                keyValue: null,
                column: "tbl_client_header_address1",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "tbl_client_header_address1",
                table: "tbl_client_header",
                type: "varchar(150)",
                maxLength: 150,
                nullable: false,
                collation: "utf8mb4_general_ci",
                oldClrType: typeof(string),
                oldType: "varchar(150)",
                oldMaxLength: 150,
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("Relational:Collation", "utf8mb4_general_ci");

            migrationBuilder.UpdateData(
                table: "tbl_address",
                keyColumn: "tbl_address_postcode",
                keyValue: null,
                column: "tbl_address_postcode",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "tbl_address_postcode",
                table: "tbl_address",
                type: "varchar(50)",
                maxLength: 50,
                nullable: false,
                collation: "utf8mb4_general_ci",
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldMaxLength: 50,
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("Relational:Collation", "utf8mb4_general_ci");

            migrationBuilder.UpdateData(
                table: "tbl_address",
                keyColumn: "tbl_address_companyName",
                keyValue: null,
                column: "tbl_address_companyName",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "tbl_address_companyName",
                table: "tbl_address",
                type: "varchar(150)",
                maxLength: 150,
                nullable: false,
                collation: "utf8mb4_general_ci",
                oldClrType: typeof(string),
                oldType: "varchar(150)",
                oldMaxLength: 150,
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("Relational:Collation", "utf8mb4_general_ci");

            migrationBuilder.UpdateData(
                table: "tbl_address",
                keyColumn: "tbl_address_address1",
                keyValue: null,
                column: "tbl_address_address1",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "tbl_address_address1",
                table: "tbl_address",
                type: "varchar(150)",
                maxLength: 150,
                nullable: false,
                collation: "utf8mb4_general_ci",
                oldClrType: typeof(string),
                oldType: "varchar(150)",
                oldMaxLength: 150,
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("Relational:Collation", "utf8mb4_general_ci");
            
            migrationBuilder.CreateIndex(
                name: "IX_tbl_voyage_tbl_voyage_number_tbl_voyage_carrierCode_tbl_voya~",
                table: "tbl_voyage",
                columns: new[] { "tbl_voyage_number", "tbl_voyage_carrierCode", "tbl_voyage_etd" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tbl_tbl_note_category_tbl_note_category_name",
                table: "tbl_tbl_note_category",
                column: "tbl_note_category_name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tbl_shipment_tbl_shipment_trackingNo_tbl_shipment_referenceNo",
                table: "tbl_shipment",
                columns: new[] { "tbl_shipment_trackingNo", "tbl_shipment_referenceNo" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tbl_milestone_header_tbl_milestone_header_name",
                table: "tbl_milestone_header",
                column: "tbl_milestone_header_name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tbl_master_tbl_master_billNumber_tbl_master_status",
                table: "tbl_master",
                columns: new[] { "tbl_master_billNumber", "tbl_master_status" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tbl_item_sku_tbl_item_sku_code",
                table: "tbl_item_sku",
                column: "tbl_item_sku_code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tbl_incoterm_tbl_incoterm_code",
                table: "tbl_incoterm",
                column: "tbl_incoterm_code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tbl_house_tbl_house_billNumber_tbl_house_value",
                table: "tbl_house",
                columns: new[] { "tbl_house_billNumber", "tbl_house_value" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tbl_container_tbl_container_number_tbl_container_sealNumber",
                table: "tbl_container",
                columns: new[] { "tbl_container_number", "tbl_container_sealNumber" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tbl_client_header_tbl_client_header_companyName_tbl_client_h~",
                table: "tbl_client_header",
                columns: new[] { "tbl_client_header_companyName", "tbl_client_header_postcode", "tbl_client_header_address1" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tbl_address_tbl_address_companyName_tbl_address_postcode_tbl~",
                table: "tbl_address",
                columns: new[] { "tbl_address_companyName", "tbl_address_postcode", "tbl_address_address1" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_tbl_voyage_tbl_voyage_number_tbl_voyage_carrierCode_tbl_voya~",
                table: "tbl_voyage");

            migrationBuilder.DropIndex(
                name: "IX_tbl_tbl_note_category_tbl_note_category_name",
                table: "tbl_tbl_note_category");

            migrationBuilder.DropIndex(
                name: "IX_tbl_shipment_tbl_shipment_trackingNo_tbl_shipment_referenceNo",
                table: "tbl_shipment");

            migrationBuilder.DropIndex(
                name: "IX_tbl_milestone_header_tbl_milestone_header_name",
                table: "tbl_milestone_header");

            migrationBuilder.DropIndex(
                name: "IX_tbl_master_tbl_master_billNumber_tbl_master_status",
                table: "tbl_master");

            migrationBuilder.DropIndex(
                name: "IX_tbl_item_sku_tbl_item_sku_code",
                table: "tbl_item_sku");

            migrationBuilder.DropIndex(
                name: "IX_tbl_incoterm_tbl_incoterm_code",
                table: "tbl_incoterm");

            migrationBuilder.DropIndex(
                name: "IX_tbl_house_tbl_house_billNumber_tbl_house_value",
                table: "tbl_house");

            migrationBuilder.DropIndex(
                name: "IX_tbl_container_tbl_container_number_tbl_container_sealNumber",
                table: "tbl_container");

            migrationBuilder.DropIndex(
                name: "IX_tbl_client_header_tbl_client_header_companyName_tbl_client_h~",
                table: "tbl_client_header");

            migrationBuilder.DropIndex(
                name: "IX_tbl_address_tbl_address_companyName_tbl_address_postcode_tbl~",
                table: "tbl_address");

            migrationBuilder.AlterColumn<string>(
                name: "tbl_voyage_number",
                table: "tbl_voyage",
                type: "varchar(30)",
                maxLength: 30,
                nullable: true,
                collation: "utf8mb4_general_ci",
                oldClrType: typeof(string),
                oldType: "varchar(30)",
                oldMaxLength: 30)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("Relational:Collation", "utf8mb4_general_ci");

            migrationBuilder.AlterColumn<DateTime>(
                name: "tbl_voyage_etd",
                table: "tbl_voyage",
                type: "datetime",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime");

            migrationBuilder.AlterColumn<string>(
                name: "tbl_voyage_carrierCode",
                table: "tbl_voyage",
                type: "varchar(30)",
                maxLength: 30,
                nullable: true,
                collation: "utf8mb4_general_ci",
                oldClrType: typeof(string),
                oldType: "varchar(30)",
                oldMaxLength: 30)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("Relational:Collation", "utf8mb4_general_ci");

            migrationBuilder.AlterColumn<string>(
                name: "tbl_note_category_name",
                table: "tbl_tbl_note_category",
                type: "varchar(50)",
                maxLength: 50,
                nullable: true,
                collation: "utf8mb4_general_ci",
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldMaxLength: 50)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("Relational:Collation", "utf8mb4_general_ci");

            migrationBuilder.AlterColumn<string>(
                name: "tbl_shipment_trackingNo",
                table: "tbl_shipment",
                type: "varchar(50)",
                maxLength: 50,
                nullable: true,
                collation: "utf8mb4_general_ci",
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldMaxLength: 50)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("Relational:Collation", "utf8mb4_general_ci");

            migrationBuilder.AlterColumn<string>(
                name: "tbl_shipment_referenceNo",
                table: "tbl_shipment",
                type: "varchar(50)",
                maxLength: 50,
                nullable: true,
                collation: "utf8mb4_general_ci",
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldMaxLength: 50)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("Relational:Collation", "utf8mb4_general_ci");

            migrationBuilder.AlterColumn<string>(
                name: "tbl_milestone_header_name",
                table: "tbl_milestone_header",
                type: "varchar(50)",
                maxLength: 50,
                nullable: true,
                collation: "utf8mb4_general_ci",
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldMaxLength: 50)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("Relational:Collation", "utf8mb4_general_ci");

            migrationBuilder.AlterColumn<string>(
                name: "tbl_master_status",
                table: "tbl_master",
                type: "varchar(50)",
                maxLength: 50,
                nullable: true,
                collation: "utf8mb4_general_ci",
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldMaxLength: 50)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("Relational:Collation", "utf8mb4_general_ci");

            migrationBuilder.AlterColumn<string>(
                name: "tbl_master_billNumber",
                table: "tbl_master",
                type: "varchar(50)",
                maxLength: 50,
                nullable: true,
                collation: "utf8mb4_general_ci",
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldMaxLength: 50)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("Relational:Collation", "utf8mb4_general_ci");

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

            migrationBuilder.AlterColumn<string>(
                name: "tbl_house_billNumber",
                table: "tbl_house",
                type: "varchar(50)",
                maxLength: 50,
                nullable: true,
                collation: "utf8mb4_general_ci",
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldMaxLength: 50)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("Relational:Collation", "utf8mb4_general_ci");

            migrationBuilder.AlterColumn<string>(
                name: "tbl_container_sealNumber",
                table: "tbl_container",
                type: "varchar(50)",
                maxLength: 50,
                nullable: true,
                collation: "utf8mb4_general_ci",
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldMaxLength: 50)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("Relational:Collation", "utf8mb4_general_ci");

            migrationBuilder.AlterColumn<string>(
                name: "tbl_container_number",
                table: "tbl_container",
                type: "varchar(50)",
                maxLength: 50,
                nullable: true,
                collation: "utf8mb4_general_ci",
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldMaxLength: 50)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("Relational:Collation", "utf8mb4_general_ci");

            migrationBuilder.AlterColumn<string>(
                name: "tbl_client_header_postcode",
                table: "tbl_client_header",
                type: "varchar(50)",
                maxLength: 50,
                nullable: true,
                collation: "utf8mb4_general_ci",
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldMaxLength: 50)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("Relational:Collation", "utf8mb4_general_ci");

            migrationBuilder.AlterColumn<string>(
                name: "tbl_client_header_companyName",
                table: "tbl_client_header",
                type: "varchar(100)",
                maxLength: 100,
                nullable: true,
                collation: "utf8mb4_general_ci",
                oldClrType: typeof(string),
                oldType: "varchar(150)",
                oldMaxLength: 150)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("Relational:Collation", "utf8mb4_general_ci");

            migrationBuilder.AlterColumn<string>(
                name: "tbl_client_header_address1",
                table: "tbl_client_header",
                type: "varchar(150)",
                maxLength: 150,
                nullable: true,
                collation: "utf8mb4_general_ci",
                oldClrType: typeof(string),
                oldType: "varchar(150)",
                oldMaxLength: 150)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("Relational:Collation", "utf8mb4_general_ci");

            migrationBuilder.AlterColumn<string>(
                name: "tbl_address_postcode",
                table: "tbl_address",
                type: "varchar(50)",
                maxLength: 50,
                nullable: true,
                collation: "utf8mb4_general_ci",
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldMaxLength: 50)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("Relational:Collation", "utf8mb4_general_ci");

            migrationBuilder.AlterColumn<string>(
                name: "tbl_address_companyName",
                table: "tbl_address",
                type: "varchar(150)",
                maxLength: 150,
                nullable: true,
                collation: "utf8mb4_general_ci",
                oldClrType: typeof(string),
                oldType: "varchar(150)",
                oldMaxLength: 150)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("Relational:Collation", "utf8mb4_general_ci");

            migrationBuilder.AlterColumn<string>(
                name: "tbl_address_address1",
                table: "tbl_address",
                type: "varchar(150)",
                maxLength: 150,
                nullable: true,
                collation: "utf8mb4_general_ci",
                oldClrType: typeof(string),
                oldType: "varchar(150)",
                oldMaxLength: 150)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("Relational:Collation", "utf8mb4_general_ci");
           
            migrationBuilder.CreateIndex(
                name: "IX_tbl_voyage_tbl_voyage_number_tbl_voyage_carrierCode_tbl_voya~",
                table: "tbl_voyage",
                columns: new[] { "tbl_voyage_number", "tbl_voyage_carrierCode", "tbl_voyage_etd" });

            migrationBuilder.CreateIndex(
                name: "IX_tbl_shipment_tbl_shipment_trackingNo_tbl_shipment_referenceNo",
                table: "tbl_shipment",
                columns: new[] { "tbl_shipment_trackingNo", "tbl_shipment_referenceNo" });

            migrationBuilder.CreateIndex(
                name: "IX_tbl_master_tbl_master_billNumber_tbl_master_status",
                table: "tbl_master",
                columns: new[] { "tbl_master_billNumber", "tbl_master_status" });

            migrationBuilder.CreateIndex(
                name: "IX_tbl_house_tbl_house_billNumber_tbl_house_value",
                table: "tbl_house",
                columns: new[] { "tbl_house_billNumber", "tbl_house_value" });

            migrationBuilder.CreateIndex(
                name: "IX_tbl_container_tbl_container_number_tbl_container_sealNumber",
                table: "tbl_container",
                columns: new[] { "tbl_container_number", "tbl_container_sealNumber" });

            migrationBuilder.CreateIndex(
                name: "IX_tbl_client_header_tbl_client_header_companyName_tbl_client_h~",
                table: "tbl_client_header",
                columns: new[] { "tbl_client_header_companyName", "tbl_client_header_postcode", "tbl_client_header_address1" });

            migrationBuilder.CreateIndex(
                name: "IX_tbl_address_tbl_address_companyName_tbl_address_postcode_tbl~",
                table: "tbl_address",
                columns: new[] { "tbl_address_companyName", "tbl_address_postcode", "tbl_address_address1" });
        }
    }
}
