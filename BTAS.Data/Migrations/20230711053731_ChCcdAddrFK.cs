using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BTAS.Data.Migrations
{
    /// <inheritdoc />
    public partial class ChCcdAddrFK : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_tbl_address_tbl_client_contact_details_ClientContactDetailCo~",
            //    table: "tbl_address");

            //migrationBuilder.DropForeignKey(
            //    name: "fk_tbl_address_tlb_client_header_id",
            //    table: "tbl_address");

            //migrationBuilder.AlterColumn<decimal>(
            //    name: "tbl_sea_shipment_weight",
            //    table: "tbl_sea_shipment",
            //    type: "decimal(10)",
            //    precision: 10,
            //    nullable: true,
            //    oldClrType: typeof(decimal),
            //    oldType: "decimal(10,30)",
            //    oldPrecision: 10,
            //    oldNullable: true);

            //migrationBuilder.AlterColumn<decimal>(
            //    name: "tbl_sea_shipment_volume",
            //    table: "tbl_sea_shipment",
            //    type: "decimal(10)",
            //    precision: 10,
            //    nullable: true,
            //    oldClrType: typeof(decimal),
            //    oldType: "decimal(10,30)",
            //    oldPrecision: 10,
            //    oldNullable: true);

            //migrationBuilder.AlterColumn<decimal>(
            //    name: "tbl_sea_shipment_value",
            //    table: "tbl_sea_shipment",
            //    type: "decimal(10)",
            //    precision: 10,
            //    nullable: true,
            //    oldClrType: typeof(decimal),
            //    oldType: "decimal(10,30)",
            //    oldPrecision: 10,
            //    oldNullable: true);

            //migrationBuilder.AlterColumn<decimal>(
            //    name: "tbl_sea_shipment_UN",
            //    table: "tbl_sea_shipment",
            //    type: "decimal(10)",
            //    precision: 10,
            //    nullable: true,
            //    oldClrType: typeof(decimal),
            //    oldType: "decimal(10,30)",
            //    oldPrecision: 10,
            //    oldNullable: true);

            //migrationBuilder.CreateIndex(
            //    name: "IX_tbl_address_ClientHeaderCode",
            //    table: "tbl_address",
            //    column: "ClientHeaderCode",
            //    unique: true);

            //migrationBuilder.AddForeignKey(
            //    name: "FK_contactDetail_address_ClientContactDeatilCode",
            //    table: "tbl_address",
            //    column: "ClientContactDetailCode",
            //    principalTable: "tbl_client_contact_details",
            //    principalColumn: "tbl_client_contact_details_code");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_table_address_tbl_client_header_code",
            //    table: "tbl_address",
            //    column: "ClientHeaderCode",
            //    principalTable: "tbl_client_header",
            //    principalColumn: "tbl_client_header_code");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_contactDetail_address_ClientContactDeatilCode",
                table: "tbl_address");

            migrationBuilder.DropForeignKey(
                name: "FK_table_address_tbl_client_header_code",
                table: "tbl_address");

            migrationBuilder.DropIndex(
                name: "IX_tbl_address_ClientHeaderCode",
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

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_address_tbl_client_contact_details_ClientContactDetailCo~",
                table: "tbl_address",
                column: "ClientContactDetailCode",
                principalTable: "tbl_client_contact_details",
                principalColumn: "tbl_client_contact_details_code");

            migrationBuilder.AddForeignKey(
                name: "fk_tbl_address_tlb_client_header_id",
                table: "tbl_address",
                column: "ClientContactDetailCode",
                principalTable: "tbl_client_header",
                principalColumn: "tbl_client_header_code");
        }
    }
}
