using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BTAS.Data.Migrations
{
    /// <inheritdoc />
    public partial class ChCcdFKs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_address_client_header_id",
            //    table: "tbl_address");

            //migrationBuilder.DropForeignKey(
            //    name: "FK_contact_details_client_header_id",
            //    table: "tbl_client_contact_details");

            //migrationBuilder.DropIndex(
            //    name: "IX_tbl_client_header_tbl_client_header_code",
            //    table: "tbl_client_header");

            //migrationBuilder.DropUniqueConstraint(
            //    name: "AK_tbl_client_contact_details_tbl_client_contact_details_code",
            //    table: "tbl_client_contact_details");

            //migrationBuilder.DropIndex(
            //    name: "IX_tbl_client_contact_details_tbl_client_contact_details_code",
            //    table: "tbl_client_contact_details");

            migrationBuilder.RenameTable(
                name: "tbl_client_contact_details",
                newName: "tbl_client_contact_detail");

            migrationBuilder.RenameColumn(
                name: "tbl_client_contact_details_type",
                table: "tbl_client_contact_detail",
                newName: "tbl_client_contact_detail_type");

            migrationBuilder.RenameColumn(
                name: "tbl_client_contact_details_phone",
                table: "tbl_client_contact_detail",
                newName: "tbl_client_contact_detail_phone");

            migrationBuilder.RenameColumn(
                name: "tbl_client_contact_details_isActive",
                table: "tbl_client_contact_detail",
                newName: "tbl_client_contact_detail_isActive");

            migrationBuilder.RenameColumn(
                name: "tbl_client_contact_details_email",
                table: "tbl_client_contact_detail",
                newName: "tbl_client_contact_detail_email");

            migrationBuilder.RenameColumn(
                name: "tbl_client_contact_details_contactName",
                table: "tbl_client_contact_detail",
                newName: "tbl_client_contact_detail_contactName");

            migrationBuilder.RenameColumn(
                name: "tbl_client_contact_details_companyName",
                table: "tbl_client_contact_detail",
                newName: "tbl_client_contact_detail_companyName");

            migrationBuilder.RenameColumn(
                name: "tbl_client_contact_details_code",
                table: "tbl_client_contact_detail",
                newName: "tbl_client_contact_detail_code");

            migrationBuilder.RenameIndex(
                name: "IX_tbl_client_contact_detail_tbl_client_header_id",
                table: "tbl_client_contact_detail",
                newName: "IX_contactDetail_clientHeader_id");

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

            migrationBuilder.AddUniqueConstraint(
                name: "AK_tbl_client_header_tbl_client_header_code",
                table: "tbl_client_header",
                column: "tbl_client_header_code");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_tbl_client_contact_detail_tbl_client_contact_detail_code",
                table: "tbl_client_contact_detail",
                column: "tbl_client_contact_detail_code");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_address_ClientHeaderCode",
                table: "tbl_address",
                column: "ClientHeaderCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_contactDetail_clientHeader_code",
                table: "tbl_client_contact_detail",
                column: "ClientHeaderCode");

            migrationBuilder.AddForeignKey(
                name: "FK_address_client_header_code",
                table: "tbl_address",
                column: "ClientHeaderCode",
                principalTable: "tbl_client_header",
                principalColumn: "tbl_client_header_code");

            migrationBuilder.AddForeignKey(
                name: "FK_contactDetail_clientHeader_code",
                table: "tbl_client_contact_detail",
                column: "ClientHeaderCode",
                principalTable: "tbl_client_header",
                principalColumn: "tbl_client_header_code");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_address_client_header_code",
                table: "tbl_address");

            migrationBuilder.DropForeignKey(
                name: "FK_contactDetail_clientHeader_code",
                table: "tbl_client_contact_detail");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_tbl_client_header_tbl_client_header_code",
                table: "tbl_client_header");

            migrationBuilder.DropIndex(
                name: "IX_tbl_address_ClientHeaderCode",
                table: "tbl_address");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_tbl_client_contact_detail_tbl_client_contact_detail_code",
                table: "tbl_client_contact_detail");

            migrationBuilder.DropIndex(
                name: "IX_contactDetail_clientHeader_code",
                table: "tbl_client_contact_detail");

            migrationBuilder.RenameTable(
                name: "tbl_client_contact_detail",
                newName: "tbl_client_contact_details");

            migrationBuilder.RenameColumn(
                name: "tbl_client_contact_detail_type",
                table: "tbl_client_contact_details",
                newName: "tbl_client_contact_details_type");

            migrationBuilder.RenameColumn(
                name: "tbl_client_contact_detail_phone",
                table: "tbl_client_contact_details",
                newName: "tbl_client_contact_details_phone");

            migrationBuilder.RenameColumn(
                name: "tbl_client_contact_detail_isActive",
                table: "tbl_client_contact_details",
                newName: "tbl_client_contact_details_isActive");

            migrationBuilder.RenameColumn(
                name: "tbl_client_contact_detail_email",
                table: "tbl_client_contact_details",
                newName: "tbl_client_contact_details_email");

            migrationBuilder.RenameColumn(
                name: "tbl_client_contact_detail_contactName",
                table: "tbl_client_contact_details",
                newName: "tbl_client_contact_details_contactName");

            migrationBuilder.RenameColumn(
                name: "tbl_client_contact_detail_companyName",
                table: "tbl_client_contact_details",
                newName: "tbl_client_contact_details_companyName");

            migrationBuilder.RenameColumn(
                name: "tbl_client_contact_detail_code",
                table: "tbl_client_contact_details",
                newName: "tbl_client_contact_details_code");

            migrationBuilder.RenameIndex(
                name: "IX_contactDetail_clientHeader_id",
                table: "tbl_client_contact_details",
                newName: "IX_tbl_client_contact_detail_tbl_client_header_id");

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

            migrationBuilder.AddUniqueConstraint(
                name: "AK_tbl_client_contact_details_tbl_client_contact_details_code",
                table: "tbl_client_contact_details",
                column: "tbl_client_contact_details_code");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_client_header_tbl_client_header_code",
                table: "tbl_client_header",
                column: "tbl_client_header_code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tbl_client_contact_details_tbl_client_contact_details_code",
                table: "tbl_client_contact_details",
                column: "tbl_client_contact_details_code",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_address_client_header_id",
                table: "tbl_address",
                column: "tbl_client_header_id",
                principalTable: "tbl_client_header",
                principalColumn: "idtbl_client_header");

            migrationBuilder.AddForeignKey(
                name: "FK_contact_details_client_header_id",
                table: "tbl_client_contact_details",
                column: "tbl_client_header_id",
                principalTable: "tbl_client_header",
                principalColumn: "idtbl_client_header");
        }
    }
}
