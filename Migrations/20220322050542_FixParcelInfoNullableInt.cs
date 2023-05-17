using Microsoft.EntityFrameworkCore.Migrations;

namespace BTAS.Data.Migrations
{
    public partial class FixParcelInfoNullableInt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_tbl_parcel_info_tbl_receptacle_tbl_receptacle_id",
            //    table: "tbl_parcel_info");

            migrationBuilder.AlterColumn<int>(
                name: "tbl_receptacle_id",
                table: "tbl_parcel_info",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_parcel_info_tbl_receptacle_tbl_receptacle_id",
                table: "tbl_parcel_info",
                column: "tbl_receptacle_id",
                principalTable: "tbl_receptacle",
                principalColumn: "idtbl_receptacle",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbl_parcel_info_tbl_receptacle_tbl_receptacle_id",
                table: "tbl_parcel_info");

            migrationBuilder.AlterColumn<int>(
                name: "tbl_receptacle_id",
                table: "tbl_parcel_info",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_parcel_info_tbl_receptacle_tbl_receptacle_id",
                table: "tbl_parcel_info",
                column: "tbl_receptacle_id",
                principalTable: "tbl_receptacle",
                principalColumn: "idtbl_receptacle",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
