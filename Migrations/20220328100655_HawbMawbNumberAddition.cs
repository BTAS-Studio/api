using Microsoft.EntityFrameworkCore.Migrations;

namespace BTAS.Data.Migrations
{
    public partial class HawbMawbNumberAddition : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbl_hawb_tbl_mawb_tbl_mawb_id",
                table: "tbl_hawb");

            migrationBuilder.DropForeignKey(
                name: "FK_tbl_voyage_tbl_mawb_tbl_mawb_id",
                table: "tbl_voyage");

            migrationBuilder.DropIndex(
                name: "IX_tbl_hawb_tbl_mawb_id",
                table: "tbl_hawb");

            migrationBuilder.AlterColumn<int>(
                name: "tbl_mawb_id",
                table: "tbl_voyage",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "MawbNumber",
                table: "tbl_voyage",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "HawbNumber",
                table: "tbl_hawb",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "mawbNumber",
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

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_voyage_tbl_mawb_tbl_mawb_id",
                table: "tbl_voyage",
                column: "tbl_mawb_id",
                principalTable: "tbl_mawb",
                principalColumn: "idtbl_mawb",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbl_hawb_tbl_mawb_mawbidtbl_mawb",
                table: "tbl_hawb");

            migrationBuilder.DropForeignKey(
                name: "FK_tbl_voyage_tbl_mawb_tbl_mawb_id",
                table: "tbl_voyage");

            migrationBuilder.DropIndex(
                name: "IX_tbl_hawb_mawbidtbl_mawb",
                table: "tbl_hawb");

            migrationBuilder.DropColumn(
                name: "MawbNumber",
                table: "tbl_voyage");

            migrationBuilder.DropColumn(
                name: "HawbNumber",
                table: "tbl_hawb");

            migrationBuilder.DropColumn(
                name: "mawbNumber",
                table: "tbl_hawb");

            migrationBuilder.DropColumn(
                name: "mawbidtbl_mawb",
                table: "tbl_hawb");

            migrationBuilder.AlterColumn<int>(
                name: "tbl_mawb_id",
                table: "tbl_voyage",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

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

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_voyage_tbl_mawb_tbl_mawb_id",
                table: "tbl_voyage",
                column: "tbl_mawb_id",
                principalTable: "tbl_mawb",
                principalColumn: "idtbl_mawb",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
