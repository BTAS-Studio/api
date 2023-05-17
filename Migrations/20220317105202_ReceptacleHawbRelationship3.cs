using Microsoft.EntityFrameworkCore.Migrations;

namespace BTAS.Data.Migrations
{
    public partial class ReceptacleHawbRelationship3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbl_hawb_tbl_mawb_tbl_mawb_id",
                table: "tbl_hawb");

            migrationBuilder.AlterColumn<int>(
                name: "tbl_mawb_id",
                table: "tbl_hawb",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

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

            migrationBuilder.AlterColumn<int>(
                name: "tbl_mawb_id",
                table: "tbl_hawb",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_hawb_tbl_mawb_tbl_mawb_id",
                table: "tbl_hawb",
                column: "tbl_mawb_id",
                principalTable: "tbl_mawb",
                principalColumn: "idtbl_mawb",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
