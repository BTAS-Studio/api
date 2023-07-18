using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BTAS.Data.Migrations
{
    /// <inheritdoc />
    public partial class ChCcdAddrFK3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_address__contact_detail_code",
            //    table: "tbl_address");

            //migrationBuilder.DropForeignKey(
            //    name: "FK_address_client_header_code",
            //    table: "tbl_address");

            //migrationBuilder.DropUniqueConstraint(
            //    name: "AK_tbl_client_header_tbl_client_header_code",
            //    table: "tbl_client_header");

            //migrationBuilder.DropUniqueConstraint(
            //    name: "AK_tbl_client_contact_details_tbl_client_contact_details_code",
            //    table: "tbl_client_contact_details");

            migrationBuilder.DropIndex(
                name: "IX_tbl_address_ClientContactDetailCode",
                table: "tbl_address");

            migrationBuilder.DropIndex(
                name: "IX_tbl_address_ClientHeaderCode",
                table: "tbl_address");

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

            migrationBuilder.AlterColumn<string>(
                name: "tbl_client_header_code",
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
                name: "tbl_client_contact_details_code",
                table: "tbl_client_contact_details",
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

            migrationBuilder.AlterColumn<int>(
                name: "tbl_client_contact_detail_id",
                table: "tbl_address",
                type: "int(11)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ClientContactDetailCode",
                table: "tbl_address",
                type: "longtext",
                nullable: true,
                collation: "utf8mb4_general_ci",
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("Relational:Collation", "utf8mb4_general_ci");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_address_tbl_client_contact_detail_id",
                table: "tbl_address",
                column: "tbl_client_contact_detail_id",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_address_client_contact_detail_id",
                table: "tbl_address",
                column: "tbl_client_contact_detail_id",
                principalTable: "tbl_client_contact_details",
                principalColumn: "idtbl_client_contact_detail");

            migrationBuilder.AddForeignKey(
                name: "FK_address_client_header_id",
                table: "tbl_address",
                column: "tbl_client_header_id",
                principalTable: "tbl_client_header",
                principalColumn: "idtbl_client_header");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_address_client_contact_detail_id",
                table: "tbl_address");

            migrationBuilder.DropForeignKey(
                name: "FK_address_client_header_id",
                table: "tbl_address");

            migrationBuilder.DropIndex(
                name: "IX_tbl_address_tbl_client_contact_detail_id",
                table: "tbl_address");

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

            migrationBuilder.UpdateData(
                table: "tbl_client_header",
                keyColumn: "tbl_client_header_code",
                keyValue: null,
                column: "tbl_client_header_code",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "tbl_client_header_code",
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
                table: "tbl_client_contact_details",
                keyColumn: "tbl_client_contact_details_code",
                keyValue: null,
                column: "tbl_client_contact_details_code",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "tbl_client_contact_details_code",
                table: "tbl_client_contact_details",
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

            migrationBuilder.AlterColumn<int>(
                name: "tbl_client_contact_detail_id",
                table: "tbl_address",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int(11)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ClientContactDetailCode",
                table: "tbl_address",
                type: "varchar(50)",
                nullable: true,
                collation: "utf8mb4_general_ci",
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("Relational:Collation", "utf8mb4_general_ci");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_tbl_client_header_tbl_client_header_code",
                table: "tbl_client_header",
                column: "tbl_client_header_code");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_tbl_client_contact_details_tbl_client_contact_details_code",
                table: "tbl_client_contact_details",
                column: "tbl_client_contact_details_code");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_address_ClientContactDetailCode",
                table: "tbl_address",
                column: "ClientContactDetailCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tbl_address_ClientHeaderCode",
                table: "tbl_address",
                column: "ClientHeaderCode",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_address__contact_detail_code",
                table: "tbl_address",
                column: "ClientContactDetailCode",
                principalTable: "tbl_client_contact_details",
                principalColumn: "tbl_client_contact_details_code");

            migrationBuilder.AddForeignKey(
                name: "FK_address_client_header_code",
                table: "tbl_address",
                column: "ClientHeaderCode",
                principalTable: "tbl_client_header",
                principalColumn: "tbl_client_header_code");
        }
    }
}
