using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BTAS.Data.Migrations
{
    /// <inheritdoc />
    public partial class ChCcdAddrFK2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_contactDetail_address_ClientContactDeatilCode",
            //    table: "tbl_address");

            //migrationBuilder.DropForeignKey(
            //    name: "FK_table_address_tbl_client_header_code",
            //    table: "tbl_address");

            //migrationBuilder.DropForeignKey(
            //    name: "FK_tbl_client_contact_details_tlb_client_header",
            //    table: "tbl_client_contact_details");

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
            //    name: "IX_tbl_client_contact_details_tbl_client_contact_details_code",
            //    table: "tbl_client_contact_details",
            //    column: "tbl_client_contact_details_code",
            //    unique: true);

            //migrationBuilder.AddForeignKey(
            //    name: "FK_address__contact_detail_code",
            //    table: "tbl_address",
            //    column: "ClientContactDetailCode",
            //    principalTable: "tbl_client_contact_details",
            //    principalColumn: "tbl_client_contact_details_code");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_address_client_header_code",
            //    table: "tbl_address",
            //    column: "ClientHeaderCode",
            //    principalTable: "tbl_client_header",
            //    principalColumn: "tbl_client_header_code");
            /*
            migrationBuilder.AddForeignKey(
                name: "FK_contact_details_client_header_id",
                table: "tbl_client_contact_details",
                column: "tbl_client_header_id",
                principalTable: "tbl_client_header",
                principalColumn: "idtbl_client_header");
            */
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_address__contact_detail_code",
                table: "tbl_address");

            migrationBuilder.DropForeignKey(
                name: "FK_address_client_header_code",
                table: "tbl_address");

            migrationBuilder.DropForeignKey(
                name: "FK_contact_details_client_header_id",
                table: "tbl_client_contact_details");

            migrationBuilder.DropIndex(
                name: "IX_tbl_client_contact_details_tbl_client_contact_details_code",
                table: "tbl_client_contact_details");

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
                name: "FK_contactDetail_address_ClientContactDeatilCode",
                table: "tbl_address",
                column: "ClientContactDetailCode",
                principalTable: "tbl_client_contact_details",
                principalColumn: "tbl_client_contact_details_code");

            migrationBuilder.AddForeignKey(
                name: "FK_table_address_tbl_client_header_code",
                table: "tbl_address",
                column: "ClientHeaderCode",
                principalTable: "tbl_client_header",
                principalColumn: "tbl_client_header_code");

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_client_contact_details_tlb_client_header",
                table: "tbl_client_contact_details",
                column: "tbl_client_header_id",
                principalTable: "tbl_client_header",
                principalColumn: "idtbl_client_header");
        }
    }
}
