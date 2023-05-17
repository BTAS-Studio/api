using Microsoft.EntityFrameworkCore.Migrations;

namespace BTAS.Data.Migrations
{
    public partial class FixParcelInfoByteToBool3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "tbl_parcel_info_lockerService",
                table: "tbl_parcel_info",
                type: "tinyint(1)",
                nullable: true,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "tinyint(1)",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "tbl_parcel_info_gstexemptioncode",
                table: "tbl_parcel_info",
                type: "tinyint(1)",
                nullable: true,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "tinyint(1)",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "tbl_parcel_info_authorityToLeave",
                table: "tbl_parcel_info",
                type: "tinyint(1)",
                nullable: true,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "tinyint(1)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "tbl_parcel_info_lockerService",
                table: "tbl_parcel_info",
                type: "tinyint(1)",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "tinyint(1)");

            migrationBuilder.AlterColumn<bool>(
                name: "tbl_parcel_info_gstexemptioncode",
                table: "tbl_parcel_info",
                type: "tinyint(1)",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "tinyint(1)");

            migrationBuilder.AlterColumn<bool>(
                name: "tbl_parcel_info_authorityToLeave",
                table: "tbl_parcel_info",
                type: "tinyint(1)",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "tinyint(1)");
        }
    }
}
