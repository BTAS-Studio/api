using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BTAS.Data.Migrations
{
    /// <inheritdoc />
    public partial class ntntcdocmsm : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "document_house_link",
                table: "tbl_documents");

            migrationBuilder.DropForeignKey(
                name: "document_master_link",
                table: "tbl_documents");

            migrationBuilder.DropForeignKey(
                name: "document_shipment_link",
                table: "tbl_documents");

            migrationBuilder.DropIndex(
                name: "idx_document_house_link_idx",
                table: "tbl_documents");

            migrationBuilder.DropIndex(
                name: "idx_document_master_link_idx",
                table: "tbl_documents");

            migrationBuilder.DropIndex(
                name: "idx_document_shipment_link_idx",
                table: "tbl_documents");

            migrationBuilder.DropColumn(
                name: "added_by",
                table: "tbl_documents");

            migrationBuilder.DropColumn(
                name: "document",
                table: "tbl_documents");

            migrationBuilder.DropColumn(
                name: "house_reference",
                table: "tbl_documents");

            migrationBuilder.DropColumn(
                name: "master_reference",
                table: "tbl_documents");

            migrationBuilder.DropColumn(
                name: "shipment_reference",
                table: "tbl_documents");

            migrationBuilder.DropColumn(
                name: "status",
                table: "tbl_documents");

            migrationBuilder.RenameColumn(
                name: "date_added",
                table: "tbl_documents",
                newName: "tbl_document_createdDate");

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
                name: "HouseCode",
                table: "tbl_documents",
                type: "varchar(50)",
                maxLength: 50,
                nullable: true,
                collation: "utf8mb4_general_ci")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "MasterCode",
                table: "tbl_documents",
                type: "varchar(50)",
                maxLength: 50,
                nullable: true,
                collation: "utf8mb4_general_ci")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "MilestoneMasterCode",
                table: "tbl_documents",
                type: "varchar(50)",
                maxLength: 50,
                nullable: true,
                collation: "utf8mb4_general_ci")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "NoteCode",
                table: "tbl_documents",
                type: "varchar(50)",
                maxLength: 50,
                nullable: true,
                collation: "utf8mb4_general_ci")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "ShipmentCode",
                table: "tbl_documents",
                type: "varchar(50)",
                maxLength: 50,
                nullable: true,
                collation: "utf8mb4_general_ci")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "tbl_document_blobToken",
                table: "tbl_documents",
                type: "varchar(150)",
                maxLength: 150,
                nullable: true,
                collation: "utf8mb4_general_ci")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "tbl_document_code",
                table: "tbl_documents",
                type: "varchar(50)",
                maxLength: 50,
                nullable: true,
                collation: "utf8mb4_general_ci")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "tbl_document_description",
                table: "tbl_documents",
                type: "varchar(150)",
                maxLength: 150,
                nullable: true,
                collation: "utf8mb4_general_ci")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "tbl_document_extension",
                table: "tbl_documents",
                type: "varchar(50)",
                maxLength: 50,
                nullable: true,
                collation: "utf8mb4_general_ci")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "tbl_document_group",
                table: "tbl_documents",
                type: "varchar(50)",
                maxLength: 50,
                nullable: true,
                collation: "utf8mb4_general_ci")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "tbl_document_name",
                table: "tbl_documents",
                type: "varchar(50)",
                maxLength: 50,
                nullable: true,
                collation: "utf8mb4_general_ci")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "tbl_document_route",
                table: "tbl_documents",
                type: "varchar(150)",
                maxLength: 150,
                nullable: true,
                collation: "utf8mb4_general_ci")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<byte>(
                name: "tbl_document_status",
                table: "tbl_documents",
                type: "tinyint(3) unsigned",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<byte>(
                name: "tbl_doucument_externalAccess",
                table: "tbl_documents",
                type: "tinyint(3) unsigned",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<byte>(
                name: "tbl_doucument_internalAccess",
                table: "tbl_documents",
                type: "tinyint(3) unsigned",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<string>(
                name: "tbl_doucument_updatedBy",
                table: "tbl_documents",
                type: "varchar(50)",
                maxLength: 50,
                nullable: true,
                collation: "utf8mb4_general_ci")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "tbl_house_id",
                table: "tbl_documents",
                type: "int(11)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "tbl_master_id",
                table: "tbl_documents",
                type: "int(11)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "tbl_milestone_master_id",
                table: "tbl_documents",
                type: "int(11)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "tbl_note_id",
                table: "tbl_documents",
                type: "int(11)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "tbl_shipment_id",
                table: "tbl_documents",
                type: "int(11)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "tbl_milestone_master",
                columns: table => new
                {
                    idtbl_milestone_master = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    code = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    masterCut = table.Column<DateTime>(type: "datetime(6)", maxLength: 6, nullable: false),
                    etd = table.Column<DateTime>(type: "datetime(6)", maxLength: 6, nullable: false),
                    available = table.Column<DateTime>(type: "datetime(6)", maxLength: 6, nullable: false),
                    ediReceive = table.Column<DateTime>(type: "datetime(6)", maxLength: 6, nullable: false),
                    etaDischarge = table.Column<DateTime>(type: "datetime(6)", maxLength: 6, nullable: false),
                    etaDestination = table.Column<DateTime>(type: "datetime(6)", maxLength: 6, nullable: false),
                    ataDestination = table.Column<DateTime>(type: "datetime(6)", maxLength: 6, nullable: false),
                    boundArrival = table.Column<DateTime>(type: "datetime(6)", maxLength: 6, nullable: false),
                    excptReportSent = table.Column<DateTime>(type: "datetime(6)", maxLength: 6, nullable: false),
                    lastMileCarrier = table.Column<DateTime>(type: "datetime(6)", maxLength: 6, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.idtbl_milestone_master);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_general_ci");

            migrationBuilder.CreateTable(
                name: "tbl_note_categories",
                columns: table => new
                {
                    idtbl_note_category = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    tbl_note_category_code = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_note_category_name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_note_category_color = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_note_category_value = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.idtbl_note_category);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_general_ci");

            migrationBuilder.CreateTable(
                name: "tbl_note",
                columns: table => new
                {
                    idtbl_note = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    tbl_note_code = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_note_status = table.Column<byte>(type: "tinyint(3) unsigned", nullable: false),
                    tbl_note_title = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_note_description = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_note_createdDate = table.Column<DateTime>(type: "datetime(6)", maxLength: 6, nullable: false),
                    tbl_master_id = table.Column<int>(type: "int(11)", nullable: true),
                    MasterCode = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_house_id = table.Column<int>(type: "int(11)", nullable: true),
                    HouseCode = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_shipment_id = table.Column<int>(type: "int(11)", nullable: true),
                    ShipmentCode = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_client_header_id = table.Column<int>(type: "int(11)", nullable: true),
                    ClientHeaderCode = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_note_category_id = table.Column<int>(type: "int(11)", nullable: true),
                    NoteCategoryCode = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.idtbl_note);
                    table.ForeignKey(
                        name: "note_client_header_link",
                        column: x => x.tbl_client_header_id,
                        principalTable: "tbl_client_header",
                        principalColumn: "idtbl_client_header");
                    table.ForeignKey(
                        name: "note_house_link",
                        column: x => x.tbl_house_id,
                        principalTable: "tbl_house",
                        principalColumn: "idtbl_house");
                    table.ForeignKey(
                        name: "note_master_link",
                        column: x => x.tbl_master_id,
                        principalTable: "tbl_master",
                        principalColumn: "idtbl_master");
                    table.ForeignKey(
                        name: "note_note_category_link",
                        column: x => x.tbl_note_category_id,
                        principalTable: "tbl_note_categories",
                        principalColumn: "idtbl_note_category");
                    table.ForeignKey(
                        name: "note_shipment_link",
                        column: x => x.tbl_shipment_id,
                        principalTable: "tbl_shipment",
                        principalColumn: "idtbl_shipment");
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_general_ci");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_master_tbl_milestone_master_id",
                table: "tbl_master",
                column: "tbl_milestone_master_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "idx_document_house_link_idx",
                table: "tbl_documents",
                column: "tbl_house_id");

            migrationBuilder.CreateIndex(
                name: "idx_document_master_link_idx",
                table: "tbl_documents",
                column: "tbl_master_id");

            migrationBuilder.CreateIndex(
                name: "idx_document_milestone_master_link_idx",
                table: "tbl_documents",
                column: "tbl_milestone_master_id");

            migrationBuilder.CreateIndex(
                name: "idx_document_note_link_idx",
                table: "tbl_documents",
                column: "tbl_note_id");

            migrationBuilder.CreateIndex(
                name: "idx_document_shipment_link_idx",
                table: "tbl_documents",
                column: "tbl_shipment_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_documents_tbl_milestone_master_id",
                table: "tbl_documents",
                column: "tbl_milestone_master_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "idx_note_client_header_link_idx",
                table: "tbl_note",
                column: "tbl_client_header_id");

            migrationBuilder.CreateIndex(
                name: "idx_note_house_link_idx",
                table: "tbl_note",
                column: "tbl_house_id");

            migrationBuilder.CreateIndex(
                name: "idx_note_master_link_idx",
                table: "tbl_note",
                column: "tbl_master_id");

            migrationBuilder.CreateIndex(
                name: "idx_note_note_category_link_idx",
                table: "tbl_note",
                column: "tbl_note_category_id");

            migrationBuilder.CreateIndex(
                name: "idx_note_shipment_link_idx",
                table: "tbl_note",
                column: "tbl_shipment_id");

            migrationBuilder.AddForeignKey(
                name: "document_house_link",
                table: "tbl_documents",
                column: "tbl_house_id",
                principalTable: "tbl_house",
                principalColumn: "idtbl_house");

            migrationBuilder.AddForeignKey(
                name: "document_master_link",
                table: "tbl_documents",
                column: "tbl_master_id",
                principalTable: "tbl_master",
                principalColumn: "idtbl_master");

            migrationBuilder.AddForeignKey(
                name: "document_milestone_master_link",
                table: "tbl_documents",
                column: "tbl_milestone_master_id",
                principalTable: "tbl_milestone_master",
                principalColumn: "idtbl_milestone_master");

            migrationBuilder.AddForeignKey(
                name: "document_note_link",
                table: "tbl_documents",
                column: "tbl_note_id",
                principalTable: "tbl_note",
                principalColumn: "idtbl_note");

            migrationBuilder.AddForeignKey(
                name: "document_shipment_link",
                table: "tbl_documents",
                column: "tbl_shipment_id",
                principalTable: "tbl_shipment",
                principalColumn: "idtbl_shipment");

            migrationBuilder.AddForeignKey(
                name: "master_milestone_master_link",
                table: "tbl_master",
                column: "tbl_milestone_master_id",
                principalTable: "tbl_milestone_master",
                principalColumn: "idtbl_milestone_master");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "document_house_link",
                table: "tbl_documents");

            migrationBuilder.DropForeignKey(
                name: "document_master_link",
                table: "tbl_documents");

            migrationBuilder.DropForeignKey(
                name: "document_milestone_master_link",
                table: "tbl_documents");

            migrationBuilder.DropForeignKey(
                name: "document_note_link",
                table: "tbl_documents");

            migrationBuilder.DropForeignKey(
                name: "document_shipment_link",
                table: "tbl_documents");

            migrationBuilder.DropForeignKey(
                name: "master_milestone_master_link",
                table: "tbl_master");

            migrationBuilder.DropTable(
                name: "tbl_milestone_master");

            migrationBuilder.DropTable(
                name: "tbl_note");

            migrationBuilder.DropTable(
                name: "tbl_note_categories");

            migrationBuilder.DropIndex(
                name: "IX_tbl_master_tbl_milestone_master_id",
                table: "tbl_master");

            migrationBuilder.DropIndex(
                name: "idx_document_house_link_idx",
                table: "tbl_documents");

            migrationBuilder.DropIndex(
                name: "idx_document_master_link_idx",
                table: "tbl_documents");

            migrationBuilder.DropIndex(
                name: "idx_document_milestone_master_link_idx",
                table: "tbl_documents");

            migrationBuilder.DropIndex(
                name: "idx_document_note_link_idx",
                table: "tbl_documents");

            migrationBuilder.DropIndex(
                name: "idx_document_shipment_link_idx",
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
                name: "HouseCode",
                table: "tbl_documents");

            migrationBuilder.DropColumn(
                name: "MasterCode",
                table: "tbl_documents");

            migrationBuilder.DropColumn(
                name: "MilestoneMasterCode",
                table: "tbl_documents");

            migrationBuilder.DropColumn(
                name: "NoteCode",
                table: "tbl_documents");

            migrationBuilder.DropColumn(
                name: "ShipmentCode",
                table: "tbl_documents");

            migrationBuilder.DropColumn(
                name: "tbl_document_blobToken",
                table: "tbl_documents");

            migrationBuilder.DropColumn(
                name: "tbl_document_code",
                table: "tbl_documents");

            migrationBuilder.DropColumn(
                name: "tbl_document_description",
                table: "tbl_documents");

            migrationBuilder.DropColumn(
                name: "tbl_document_extension",
                table: "tbl_documents");

            migrationBuilder.DropColumn(
                name: "tbl_document_group",
                table: "tbl_documents");

            migrationBuilder.DropColumn(
                name: "tbl_document_name",
                table: "tbl_documents");

            migrationBuilder.DropColumn(
                name: "tbl_document_route",
                table: "tbl_documents");

            migrationBuilder.DropColumn(
                name: "tbl_document_status",
                table: "tbl_documents");

            migrationBuilder.DropColumn(
                name: "tbl_doucument_externalAccess",
                table: "tbl_documents");

            migrationBuilder.DropColumn(
                name: "tbl_doucument_internalAccess",
                table: "tbl_documents");

            migrationBuilder.DropColumn(
                name: "tbl_doucument_updatedBy",
                table: "tbl_documents");

            migrationBuilder.DropColumn(
                name: "tbl_house_id",
                table: "tbl_documents");

            migrationBuilder.DropColumn(
                name: "tbl_master_id",
                table: "tbl_documents");

            migrationBuilder.DropColumn(
                name: "tbl_milestone_master_id",
                table: "tbl_documents");

            migrationBuilder.DropColumn(
                name: "tbl_note_id",
                table: "tbl_documents");

            migrationBuilder.DropColumn(
                name: "tbl_shipment_id",
                table: "tbl_documents");

            migrationBuilder.RenameColumn(
                name: "tbl_document_createdDate",
                table: "tbl_documents",
                newName: "date_added");

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
                name: "added_by",
                table: "tbl_documents",
                type: "longtext",
                nullable: true,
                collation: "utf8mb4_general_ci")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "document",
                table: "tbl_documents",
                type: "longtext",
                nullable: true,
                collation: "utf8mb4_general_ci")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "house_reference",
                table: "tbl_documents",
                type: "int(11)",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "master_reference",
                table: "tbl_documents",
                type: "int(11)",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "shipment_reference",
                table: "tbl_documents",
                type: "int(11)",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "status",
                table: "tbl_documents",
                type: "longtext",
                nullable: true,
                collation: "utf8mb4_general_ci")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "idx_document_house_link_idx",
                table: "tbl_documents",
                column: "house_reference");

            migrationBuilder.CreateIndex(
                name: "idx_document_master_link_idx",
                table: "tbl_documents",
                column: "master_reference");

            migrationBuilder.CreateIndex(
                name: "idx_document_shipment_link_idx",
                table: "tbl_documents",
                column: "shipment_reference");

            migrationBuilder.AddForeignKey(
                name: "document_house_link",
                table: "tbl_documents",
                column: "house_reference",
                principalTable: "tbl_house",
                principalColumn: "idtbl_house");

            migrationBuilder.AddForeignKey(
                name: "document_master_link",
                table: "tbl_documents",
                column: "master_reference",
                principalTable: "tbl_master",
                principalColumn: "idtbl_master");

            migrationBuilder.AddForeignKey(
                name: "document_shipment_link",
                table: "tbl_documents",
                column: "shipment_reference",
                principalTable: "tbl_shipment",
                principalColumn: "idtbl_shipment");
        }
    }
}
