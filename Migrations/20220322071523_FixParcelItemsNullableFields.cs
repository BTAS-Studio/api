using Microsoft.EntityFrameworkCore.Migrations;

namespace BTAS.Data.Migrations
{
    public partial class FixParcelItemsNullableFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_tbl_parcel_items_tbl_parcel_info_tbl_parcel_info_id",
            //    table: "tbl_parcel_items");

            migrationBuilder.AlterColumn<int>(
                name: "tbl_parcel_info_id",
                table: "tbl_parcel_items",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_tbl_parcel_items_tbl_parcel_info_tbl_parcel_info_id",
            //    table: "tbl_parcel_items",
            //    column: "tbl_parcel_info_id",
            //    principalTable: "tbl_parcel_info",
            //    principalColumn: "idtbl_parcel_info",
            //    onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_tbl_parcel_items_tbl_parcel_info_tbl_parcel_info_id",
            //    table: "tbl_parcel_items");

            migrationBuilder.AlterColumn<int>(
                name: "tbl_parcel_info_id",
                table: "tbl_parcel_items",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            //migrationBuilder.AddForeignKey(
            //    name: "FK_tbl_parcel_items_tbl_parcel_info_tbl_parcel_info_id",
            //    table: "tbl_parcel_items",
            //    column: "tbl_parcel_info_id",
            //    principalTable: "tbl_parcel_info",
            //    principalColumn: "idtbl_parcel_info",
            //    onDelete: ReferentialAction.Cascade);
        }
    }
}
