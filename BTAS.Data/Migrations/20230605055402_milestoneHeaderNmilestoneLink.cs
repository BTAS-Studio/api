using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BTAS.Data.Migrations
{
    /// <inheritdoc />
    public partial class milestoneHeaderNmilestoneLink : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "document_milestone_master_link",
                table: "tbl_documents");

            migrationBuilder.DropForeignKey(
                name: "master_milestone_master_link",
                table: "tbl_master");

            migrationBuilder.DropTable(
                name: "tbl_milestone_master");

            migrationBuilder.DropIndex(
                name: "IX_tbl_master_tbl_milestone_master_id",
                table: "tbl_master");

            migrationBuilder.DropIndex(
                name: "idx_document_milestone_master_link_idx",
                table: "tbl_documents");

            migrationBuilder.DropIndex(
                name: "IX_tbl_documents_tbl_milestone_master_id",
                table: "tbl_documents");

            migrationBuilder.DropColumn(
                name: "MilestoneMasterCode",
                table: "tbl_master");

            migrationBuilder.DropColumn(
                name: "tbl_milestone_master_id",
                table: "tbl_master");

            migrationBuilder.DropColumn(
                name: "MilestoneMasterCode",
                table: "tbl_documents");

            migrationBuilder.DropColumn(
                name: "tbl_milestone_master_id",
                table: "tbl_documents");

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

            migrationBuilder.CreateTable(
                name: "tbl_milestone_header",
                columns: table => new
                {
                    idtbl_milestone_header = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    tbl_milestone_header_code = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_milestone_header_name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_milestone_header_description = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_milestone_header_createdBy = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_milestone_header_createdDate = table.Column<DateTime>(type: "datetime(6)", maxLength: 6, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.idtbl_milestone_header);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_general_ci");

            migrationBuilder.CreateTable(
                name: "tbl_milestone_link",
                columns: table => new
                {
                    idtbl_milestone_link = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    tbl_milestone_link_code = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_milestone_link_value = table.Column<DateTime>(type: "datetime(6)", maxLength: 6, nullable: false),
                    tbl_milestone_createdBy = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_miestone_createdDate = table.Column<DateTime>(type: "datetime(6)", maxLength: 6, nullable: false),
                    tbl_milestone_header_id = table.Column<int>(type: "int(11)", nullable: true),
                    MilestoneHeaderCode = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_master_id = table.Column<int>(type: "int(11)", nullable: true),
                    MasterCode = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_house_id = table.Column<int>(type: "int(11)", nullable: true),
                    HouseCode = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_shipment_id = table.Column<int>(type: "int(11)", nullable: true),
                    ShipmentCode = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.idtbl_milestone_link);
                    table.ForeignKey(
                        name: "msLink_house_link",
                        column: x => x.tbl_house_id,
                        principalTable: "tbl_house",
                        principalColumn: "idtbl_house");
                    table.ForeignKey(
                        name: "msLink_master_link",
                        column: x => x.tbl_master_id,
                        principalTable: "tbl_master",
                        principalColumn: "idtbl_master");
                    table.ForeignKey(
                        name: "msLink_msHeader_link",
                        column: x => x.tbl_milestone_header_id,
                        principalTable: "tbl_milestone_header",
                        principalColumn: "idtbl_milestone_header");
                    table.ForeignKey(
                        name: "msLink_shipment_link",
                        column: x => x.tbl_shipment_id,
                        principalTable: "tbl_shipment",
                        principalColumn: "idtbl_shipment");
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_general_ci");

            migrationBuilder.CreateIndex(
                name: "idx_mslink_house_link_idx",
                table: "tbl_milestone_link",
                column: "tbl_house_id");

            migrationBuilder.CreateIndex(
                name: "idx_mslink_master_link_idx",
                table: "tbl_milestone_link",
                column: "tbl_master_id");

            migrationBuilder.CreateIndex(
                name: "idx_mslink_shipment_link_idx",
                table: "tbl_milestone_link",
                column: "tbl_shipment_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_milestone_link_tbl_milestone_header_id",
                table: "tbl_milestone_link",
                column: "tbl_milestone_header_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbl_milestone_link");

            migrationBuilder.DropTable(
                name: "tbl_milestone_header");

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

            migrationBuilder.AddColumn<string>(
                name: "MilestoneMasterCode",
                table: "tbl_master",
                type: "longtext",
                nullable: true,
                collation: "utf8mb4_general_ci")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "tbl_milestone_master_id",
                table: "tbl_master",
                type: "int(11)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MilestoneMasterCode",
                table: "tbl_documents",
                type: "varchar(50)",
                maxLength: 50,
                nullable: true,
                collation: "utf8mb4_general_ci")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "tbl_milestone_master_id",
                table: "tbl_documents",
                type: "int(11)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "tbl_milestone_master",
                columns: table => new
                {
                    idtbl_milestone_master = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ataDestination = table.Column<DateTime>(type: "datetime(6)", maxLength: 6, nullable: false),
                    available = table.Column<DateTime>(type: "datetime(6)", maxLength: 6, nullable: false),
                    boundArrival = table.Column<DateTime>(type: "datetime(6)", maxLength: 6, nullable: false),
                    code = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ediReceive = table.Column<DateTime>(type: "datetime(6)", maxLength: 6, nullable: false),
                    etaDestination = table.Column<DateTime>(type: "datetime(6)", maxLength: 6, nullable: false),
                    etaDischarge = table.Column<DateTime>(type: "datetime(6)", maxLength: 6, nullable: false),
                    etd = table.Column<DateTime>(type: "datetime(6)", maxLength: 6, nullable: false),
                    excptReportSent = table.Column<DateTime>(type: "datetime(6)", maxLength: 6, nullable: false),
                    lastMileCarrier = table.Column<DateTime>(type: "datetime(6)", maxLength: 6, nullable: false),
                    masterCut = table.Column<DateTime>(type: "datetime(6)", maxLength: 6, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.idtbl_milestone_master);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_general_ci");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_master_tbl_milestone_master_id",
                table: "tbl_master",
                column: "tbl_milestone_master_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "idx_document_milestone_master_link_idx",
                table: "tbl_documents",
                column: "tbl_milestone_master_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_documents_tbl_milestone_master_id",
                table: "tbl_documents",
                column: "tbl_milestone_master_id",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "document_milestone_master_link",
                table: "tbl_documents",
                column: "tbl_milestone_master_id",
                principalTable: "tbl_milestone_master",
                principalColumn: "idtbl_milestone_master");

            migrationBuilder.AddForeignKey(
                name: "master_milestone_master_link",
                table: "tbl_master",
                column: "tbl_milestone_master_id",
                principalTable: "tbl_milestone_master",
                principalColumn: "idtbl_milestone_master");
        }
    }
}
