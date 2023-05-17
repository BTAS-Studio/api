using Microsoft.EntityFrameworkCore.Migrations;

namespace BTAS.Data.Migrations
{
    public partial class CleaningReferences : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbl_hawb_tbl_mawb_mawbidtbl_mawb",
                table: "tbl_hawb");

            migrationBuilder.DropIndex(
                name: "IX_tbl_hawb_mawbidtbl_mawb",
                table: "tbl_hawb");

            migrationBuilder.DropColumn(
                name: "HawbNumber",
                table: "tbl_hawb");

            migrationBuilder.DropColumn(
                name: "mawbidtbl_mawb",
                table: "tbl_hawb");

            migrationBuilder.AddColumn<string>(
                name: "HawbNumber",
                table: "tbl_receptacle",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "HawbNumber",
                table: "tbl_client_header",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_hawb_tbl_mawb_id",
                table: "tbl_hawb",
                column: "tbl_mawb_id");

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_hawb_tbl_mawb_tbl_mawb_id",
                table: "tbl_hawb",
                column: "tbl_mawb_id",
                principalTable: "tbl_mawb",
                principalColumn: "idtbl_mawb",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbl_hawb_tbl_mawb_tbl_mawb_id",
                table: "tbl_hawb");

            migrationBuilder.DropIndex(
                name: "IX_tbl_hawb_tbl_mawb_id",
                table: "tbl_hawb");

            migrationBuilder.DropColumn(
                name: "HawbNumber",
                table: "tbl_receptacle");

            migrationBuilder.DropColumn(
                name: "HawbNumber",
                table: "tbl_client_header");

            migrationBuilder.AddColumn<string>(
                name: "HawbNumber",
                table: "tbl_hawb",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "mawbidtbl_mawb",
                table: "tbl_hawb",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_tbl_hawb_mawbidtbl_mawb",
                table: "tbl_hawb",
                column: "mawbidtbl_mawb");

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_hawb_tbl_mawb_mawbidtbl_mawb",
                table: "tbl_hawb",
                column: "mawbidtbl_mawb",
                principalTable: "tbl_mawb",
                principalColumn: "idtbl_mawb",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
