using Microsoft.EntityFrameworkCore.Migrations;

namespace BTAS.Data.Migrations
{
    public partial class FixParcelItemsRelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_tbl_parcel_items_tbl_items_sku_tbl_items_sku_id",
            //    table: "tbl_parcel_items");

            //migrationBuilder.DropForeignKey(
            //    name: "FK_tbl_parcel_items_tbl_parcel_info_tbl_parcel_items_info_id",
            //    table: "tbl_parcel_items");

            //migrationBuilder.RenameColumn(
            //    name: "tbl_parcel_items_info_id",
            //    table: "tbl_parcel_items",
            //    newName: "tbl_parcel_info_id");

            //migrationBuilder.RenameIndex(
            //    name: "IX_tbl_parcel_items_tbl_parcel_items_info_id",
            //    table: "tbl_parcel_items",
            //    newName: "IX_tbl_parcel_items_tbl_parcel_info_id");

            migrationBuilder.AlterColumn<bool>(
                name: "tbl_parcel_items_parcelDangerousGoods",
                table: "tbl_parcel_items",
                type: "tinyint(1)",
                nullable: true,
                oldClrType: typeof(byte),
                oldType: "tinyint unsigned");

            migrationBuilder.AlterColumn<int>(
                name: "tbl_items_sku_id",
                table: "tbl_parcel_items",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_tbl_parcel_items_tbl_items_sku_tbl_items_sku_id",
            //    table: "tbl_parcel_items",
            //    column: "tbl_items_sku_id",
            //    principalTable: "tbl_items_sku",
            //    principalColumn: "idtbl_items_sku",
            //    onDelete: ReferentialAction.NoAction);

            //migrationBuilder.AddForeignKey(
            //    name: "FK_tbl_parcel_items_tbl_parcel_info_tbl_parcel_info_id",
            //    table: "tbl_parcel_items",
            //    column: "tbl_parcel_info_id",
            //    principalTable: "tbl_parcel_info",
            //    principalColumn: "idtbl_parcel_info",
            //    onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbl_parcel_items_tbl_items_sku_tbl_items_sku_id",
                table: "tbl_parcel_items");

            migrationBuilder.DropForeignKey(
                name: "FK_tbl_parcel_items_tbl_parcel_info_tbl_parcel_info_id",
                table: "tbl_parcel_items");

            migrationBuilder.RenameColumn(
                name: "tbl_parcel_info_id",
                table: "tbl_parcel_items",
                newName: "tbl_parcel_items_info_id");

            migrationBuilder.RenameIndex(
                name: "IX_tbl_parcel_items_tbl_parcel_info_id",
                table: "tbl_parcel_items",
                newName: "IX_tbl_parcel_items_tbl_parcel_items_info_id");

            migrationBuilder.AlterColumn<byte>(
                name: "tbl_parcel_items_parcelDangerousGoods",
                table: "tbl_parcel_items",
                type: "tinyint unsigned",
                nullable: false,
                defaultValue: (byte)0,
                oldClrType: typeof(bool),
                oldType: "tinyint(1)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "tbl_items_sku_id",
                table: "tbl_parcel_items",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_parcel_items_tbl_items_sku_tbl_items_sku_id",
                table: "tbl_parcel_items",
                column: "tbl_items_sku_id",
                principalTable: "tbl_items_sku",
                principalColumn: "idtbl_items_sku",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_parcel_items_tbl_parcel_info_tbl_parcel_items_info_id",
                table: "tbl_parcel_items",
                column: "tbl_parcel_items_info_id",
                principalTable: "tbl_parcel_info",
                principalColumn: "idtbl_parcel_info",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
