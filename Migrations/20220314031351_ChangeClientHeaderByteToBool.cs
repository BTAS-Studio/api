using Microsoft.EntityFrameworkCore.Migrations;

namespace BTAS.Data.Migrations
{
    public partial class ChangeClientHeaderByteToBool : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "tbl_client_header_is_receivable",
                table: "tbl_client_header",
                type: "tinyint(1)",
                nullable: false,
                oldClrType: typeof(byte),
                oldType: "tinyint unsigned");

            migrationBuilder.AlterColumn<bool>(
                name: "tbl_client_header_is_payable",
                table: "tbl_client_header",
                type: "tinyint(1)",
                nullable: false,
                oldClrType: typeof(byte),
                oldType: "tinyint unsigned");

            migrationBuilder.AlterColumn<bool>(
                name: "tbl_client_header_is_consignor",
                table: "tbl_client_header",
                type: "tinyint(1)",
                nullable: false,
                oldClrType: typeof(byte),
                oldType: "tinyint unsigned");

            migrationBuilder.AlterColumn<bool>(
                name: "tbl_client_header_is_consignee",
                table: "tbl_client_header",
                type: "tinyint(1)",
                nullable: false,
                oldClrType: typeof(byte),
                oldType: "tinyint unsigned");

            migrationBuilder.AlterColumn<bool>(
                name: "tbl_client_header_is_carrier",
                table: "tbl_client_header",
                type: "tinyint(1)",
                nullable: false,
                oldClrType: typeof(byte),
                oldType: "tinyint unsigned");

            migrationBuilder.AlterColumn<bool>(
                name: "tbl_client_header_is_broker",
                table: "tbl_client_header",
                type: "tinyint(1)",
                nullable: false,
                oldClrType: typeof(byte),
                oldType: "tinyint unsigned");

            migrationBuilder.AlterColumn<bool>(
                name: "tbl_client_header_is_agent",
                table: "tbl_client_header",
                type: "tinyint(1)",
                nullable: false,
                oldClrType: typeof(byte),
                oldType: "tinyint unsigned");

            migrationBuilder.AlterColumn<bool>(
                name: "tbl_client_header_active",
                table: "tbl_client_header",
                type: "tinyint(1)",
                nullable: false,
                oldClrType: typeof(byte),
                oldType: "tinyint unsigned");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte>(
                name: "tbl_client_header_is_receivable",
                table: "tbl_client_header",
                type: "tinyint unsigned",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "tinyint(1)");

            migrationBuilder.AlterColumn<byte>(
                name: "tbl_client_header_is_payable",
                table: "tbl_client_header",
                type: "tinyint unsigned",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "tinyint(1)");

            migrationBuilder.AlterColumn<byte>(
                name: "tbl_client_header_is_consignor",
                table: "tbl_client_header",
                type: "tinyint unsigned",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "tinyint(1)");

            migrationBuilder.AlterColumn<byte>(
                name: "tbl_client_header_is_consignee",
                table: "tbl_client_header",
                type: "tinyint unsigned",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "tinyint(1)");

            migrationBuilder.AlterColumn<byte>(
                name: "tbl_client_header_is_carrier",
                table: "tbl_client_header",
                type: "tinyint unsigned",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "tinyint(1)");

            migrationBuilder.AlterColumn<byte>(
                name: "tbl_client_header_is_broker",
                table: "tbl_client_header",
                type: "tinyint unsigned",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "tinyint(1)");

            migrationBuilder.AlterColumn<byte>(
                name: "tbl_client_header_is_agent",
                table: "tbl_client_header",
                type: "tinyint unsigned",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "tinyint(1)");

            migrationBuilder.AlterColumn<byte>(
                name: "tbl_client_header_active",
                table: "tbl_client_header",
                type: "tinyint unsigned",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "tinyint(1)");
        }
    }
}
