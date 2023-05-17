using Microsoft.EntityFrameworkCore.Migrations;

namespace BTAS.Data.Migrations
{
    public partial class AddRoutingVoyageNumber : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbl_routing_tbl_voyage_tbl_voyage_id",
                table: "tbl_routing");

            migrationBuilder.AlterColumn<int>(
                name: "tbl_voyage_id",
                table: "tbl_routing",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "VoyageNumber",
                table: "tbl_routing",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_routing_tbl_voyage_tbl_voyage_id",
                table: "tbl_routing",
                column: "tbl_voyage_id",
                principalTable: "tbl_voyage",
                principalColumn: "idtbl_voyage",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbl_routing_tbl_voyage_tbl_voyage_id",
                table: "tbl_routing");

            migrationBuilder.DropColumn(
                name: "VoyageNumber",
                table: "tbl_routing");

            migrationBuilder.AlterColumn<int>(
                name: "tbl_voyage_id",
                table: "tbl_routing",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_routing_tbl_voyage_tbl_voyage_id",
                table: "tbl_routing",
                column: "tbl_voyage_id",
                principalTable: "tbl_voyage",
                principalColumn: "idtbl_voyage",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
