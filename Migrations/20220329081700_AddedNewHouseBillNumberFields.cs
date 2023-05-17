using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BTAS.Data.Migrations
{
    public partial class AddedNewHouseBillNumberFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbl_voyage_tbl_mawb_tbl_mawb_id",
                table: "tbl_voyage");

            migrationBuilder.DropIndex(
                name: "IX_tbl_voyage_tbl_mawb_id",
                table: "tbl_voyage");

            migrationBuilder.DropColumn(
                name: "MawbNumber",
                table: "tbl_voyage");

            migrationBuilder.DropColumn(
                name: "tbl_mawb_id",
                table: "tbl_voyage");

            migrationBuilder.AddColumn<string>(
                name: "tbl_mawb_billNumber",
                table: "tbl_mawb",
                type: "varchar(50)",
                maxLength: 50,
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "tbl_voyage_id",
                table: "tbl_mawb",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "tbl_hawb_billNumber",
                table: "tbl_hawb",
                type: "varchar(30)",
                maxLength: 30,
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tbl_containerType",
                columns: table => new
                {
                    idtbl_containerType = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    tbl_containerType_description = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_containerType", x => x.idtbl_containerType);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_mawb_tbl_voyage_id",
                table: "tbl_mawb",
                column: "tbl_voyage_id");

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_mawb_tbl_voyage_tbl_voyage_id",
                table: "tbl_mawb",
                column: "tbl_voyage_id",
                principalTable: "tbl_voyage",
                principalColumn: "idtbl_voyage",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbl_mawb_tbl_voyage_tbl_voyage_id",
                table: "tbl_mawb");

            migrationBuilder.DropTable(
                name: "tbl_containerType");

            migrationBuilder.DropIndex(
                name: "IX_tbl_mawb_tbl_voyage_id",
                table: "tbl_mawb");

            migrationBuilder.DropColumn(
                name: "tbl_mawb_billNumber",
                table: "tbl_mawb");

            migrationBuilder.DropColumn(
                name: "tbl_voyage_id",
                table: "tbl_mawb");

            migrationBuilder.DropColumn(
                name: "tbl_hawb_billNumber",
                table: "tbl_hawb");

            migrationBuilder.AddColumn<string>(
                name: "MawbNumber",
                table: "tbl_voyage",
                type: "varchar(30)",
                maxLength: 30,
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "tbl_mawb_id",
                table: "tbl_voyage",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_tbl_voyage_tbl_mawb_id",
                table: "tbl_voyage",
                column: "tbl_mawb_id");

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_voyage_tbl_mawb_tbl_mawb_id",
                table: "tbl_voyage",
                column: "tbl_mawb_id",
                principalTable: "tbl_mawb",
                principalColumn: "idtbl_mawb",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
