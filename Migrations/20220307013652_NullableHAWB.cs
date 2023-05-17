using Microsoft.EntityFrameworkCore.Migrations;

namespace BTAS.Data.Migrations
{
    public partial class NullableHAWB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbl_receptacle_tbl_hawb_tbl_hawb_id",
                table: "tbl_receptacle");

            migrationBuilder.AlterColumn<int>(
                name: "tbl_hawb_id",
                table: "tbl_receptacle",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_receptacle_tbl_hawb_tbl_hawb_id",
                table: "tbl_receptacle",
                column: "tbl_hawb_id",
                principalTable: "tbl_hawb",
                principalColumn: "idtbl_hawb",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbl_receptacle_tbl_hawb_tbl_hawb_id",
                table: "tbl_receptacle");

            migrationBuilder.AlterColumn<int>(
                name: "tbl_hawb_id",
                table: "tbl_receptacle",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_receptacle_tbl_hawb_tbl_hawb_id",
                table: "tbl_receptacle",
                column: "tbl_hawb_id",
                principalTable: "tbl_hawb",
                principalColumn: "idtbl_hawb",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
