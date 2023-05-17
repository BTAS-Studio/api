using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BTAS.Data.Migrations
{
    public partial class VoyageAndRouting : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AddColumn<string>(
                name: "tbl_mawb_bookingNumber",
                table: "tbl_mawb",
                type: "varchar(50)",
                maxLength: 50,
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "tbl_mawb_containerMode",
                table: "tbl_mawb",
                type: "varchar(30)",
                maxLength: 30,
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "tbl_mawb_masterBillNumber",
                table: "tbl_mawb",
                type: "varchar(50)",
                maxLength: 50,
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "tbl_mawb_transportType",
                table: "tbl_mawb",
                type: "varchar(30)",
                maxLength: 30,
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "tbl_mawb_type",
                table: "tbl_mawb",
                type: "varchar(30)",
                maxLength: 30,
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "tbl_mawb_voyage_id",
                table: "tbl_mawb",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "tbl_voyage",
                columns: table => new
                {
                    idtbl_voyage = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    tbl_voyage_number = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_voyage_vessel = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_voyage_aircrafType = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_voyage_aircraftReg = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_voyage_vinNumber = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_voyage_loadPort = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_voyage_dischargePort = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_voyage_etd = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    tbl_voyage_eta = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    tbl_voyage_atd = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    tbl_voyage_ata = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_voyage", x => x.idtbl_voyage);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tbl_routing",
                columns: table => new
                {
                    idtbl_routing = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    tbl_voyage_id = table.Column<int>(type: "int", nullable: false),
                    tbl_routing_cutoffDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    tbl_voyage_loadPort = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_voyage_dischargePort = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_voyage_etd = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    tbl_voyage_eta = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    tbl_voyage_atd = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    tbl_voyage_ata = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_routing", x => x.idtbl_routing);
                    table.ForeignKey(
                        name: "FK_tbl_routing_tbl_voyage_tbl_voyage_id",
                        column: x => x.tbl_voyage_id,
                        principalTable: "tbl_voyage",
                        principalColumn: "idtbl_voyage",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

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

            migrationBuilder.CreateIndex(
                name: "IX_tbl_mawb_tbl_mawb_voyage_id",
                table: "tbl_mawb",
                column: "tbl_mawb_voyage_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_routing_tbl_voyage_id",
                table: "tbl_routing",
                column: "tbl_voyage_id");

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_mawb_tbl_client_header_carrier_id",
                table: "tbl_mawb",
                column: "tbl_client_header_carrier_id",
                principalTable: "tbl_client_header",
                principalColumn: "idtbl_client_header",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_mawb_tbl_client_header_creditor_id",
                table: "tbl_mawb",
                column: "tbl_client_header_creditor_id",
                principalTable: "tbl_client_header",
                principalColumn: "idtbl_client_header",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_mawb_tbl_client_header_destination_id",
                table: "tbl_mawb",
                column: "tbl_client_header_destination_id",
                principalTable: "tbl_client_header",
                principalColumn: "idtbl_client_header",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_mawb_tbl_client_header_origin_id",
                table: "tbl_mawb",
                column: "tbl_client_header_origin_id",
                principalTable: "tbl_client_header",
                principalColumn: "idtbl_client_header",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_mawb_tbl_voyage_tbl_mawb_voyage_id",
                table: "tbl_mawb",
                column: "tbl_mawb_voyage_id",
                principalTable: "tbl_voyage",
                principalColumn: "idtbl_voyage",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbl_mawb_tbl_client_header_carrier_id",
                table: "tbl_mawb");

            migrationBuilder.DropForeignKey(
                name: "FK_tbl_mawb_tbl_client_header_creditor_id",
                table: "tbl_mawb");

            migrationBuilder.DropForeignKey(
                name: "FK_tbl_mawb_tbl_client_header_destination_id",
                table: "tbl_mawb");

            migrationBuilder.DropForeignKey(
                name: "FK_tbl_mawb_tbl_client_header_origin_id",
                table: "tbl_mawb");

            migrationBuilder.DropForeignKey(
                name: "FK_tbl_mawb_tbl_voyage_tbl_mawb_voyage_id",
                table: "tbl_mawb");

            migrationBuilder.DropTable(
                name: "tbl_routing");

            migrationBuilder.DropTable(
                name: "tbl_voyage");

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

            migrationBuilder.DropIndex(
                name: "IX_tbl_mawb_tbl_mawb_voyage_id",
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

            migrationBuilder.DropColumn(
                name: "tbl_mawb_bookingNumber",
                table: "tbl_mawb");

            migrationBuilder.DropColumn(
                name: "tbl_mawb_containerMode",
                table: "tbl_mawb");

            migrationBuilder.DropColumn(
                name: "tbl_mawb_masterBillNumber",
                table: "tbl_mawb");

            migrationBuilder.DropColumn(
                name: "tbl_mawb_transportType",
                table: "tbl_mawb");

            migrationBuilder.DropColumn(
                name: "tbl_mawb_type",
                table: "tbl_mawb");

            migrationBuilder.DropColumn(
                name: "tbl_mawb_voyage_id",
                table: "tbl_mawb");
        }
    }
}
