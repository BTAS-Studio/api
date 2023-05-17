using Microsoft.EntityFrameworkCore.Migrations;

namespace BTAS.Data.Migrations
{
    public partial class FixParcelInfoByteToBool : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "tbl_parcel_info_tailLiftO",
                table: "tbl_parcel_info",
                type: "tinyint(1)",
                nullable: true,
                oldClrType: typeof(byte),
                oldType: "tinyint unsigned");

            migrationBuilder.AlterColumn<bool>(
                name: "tbl_parcel_info_tailLiftD",
                table: "tbl_parcel_info",
                type: "tinyint(1)",
                nullable: true,
                oldClrType: typeof(byte),
                oldType: "tinyint unsigned");

            migrationBuilder.AlterColumn<bool>(
                name: "tbl_parcel_info_dg",
                table: "tbl_parcel_info",
                type: "tinyint(1)",
                nullable: true,
                oldClrType: typeof(byte),
                oldType: "tinyint unsigned");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte>(
                name: "tbl_parcel_info_tailLiftO",
                table: "tbl_parcel_info",
                type: "tinyint unsigned",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "tinyint(1)");

            migrationBuilder.AlterColumn<byte>(
                name: "tbl_parcel_info_tailLiftD",
                table: "tbl_parcel_info",
                type: "tinyint unsigned",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "tinyint(1)");

            migrationBuilder.AlterColumn<byte>(
                name: "tbl_parcel_info_dg",
                table: "tbl_parcel_info",
                type: "tinyint unsigned",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "tinyint(1)");
        }
    }
}
