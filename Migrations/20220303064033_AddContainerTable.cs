using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BTAS.Data.Migrations
{
    public partial class AddContainerTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "tbl_container_id",
                table: "tbl_hawb",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "tbl_container",
                columns: table => new
                {
                    idtbl_container = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    tbl_container_qty = table.Column<int>(type: "int", nullable: false),
                    tbl_container_sealNumber = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_container_mode = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_container_type = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_container_grossWeight = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    tbl_container_createdDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    tbl_container_sealedBy = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_mawb_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_container", x => x.idtbl_container);
                    table.ForeignKey(
                        name: "FK_tbl_container_tbl_mawb_tbl_mawb_id",
                        column: x => x.tbl_mawb_id,
                        principalTable: "tbl_mawb",
                        principalColumn: "idtbl_mawb",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_hawb_tbl_container_id",
                table: "tbl_hawb",
                column: "tbl_container_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_container_tbl_mawb_id",
                table: "tbl_container",
                column: "tbl_mawb_id");

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_hawb_tbl_container_tbl_container_id",
                table: "tbl_hawb",
                column: "tbl_container_id",
                principalTable: "tbl_container",
                principalColumn: "idtbl_container",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbl_hawb_tbl_container_tbl_container_id",
                table: "tbl_hawb");

            migrationBuilder.DropTable(
                name: "tbl_container");

            migrationBuilder.DropIndex(
                name: "IX_tbl_hawb_tbl_container_id",
                table: "tbl_hawb");

            migrationBuilder.DropColumn(
                name: "tbl_container_id",
                table: "tbl_hawb");
        }
    }
}
