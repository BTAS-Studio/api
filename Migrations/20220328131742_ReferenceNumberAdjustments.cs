using Microsoft.EntityFrameworkCore.Migrations;

namespace BTAS.Data.Migrations
{
    public partial class ReferenceNumberAdjustments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbl_container_tbl_mawb_tbl_mawb_id",
                table: "tbl_container");

            migrationBuilder.DropColumn(
                name: "tbl_hawb_items_reference",
                table: "tbl_hawb_items");

            migrationBuilder.AlterColumn<string>(
                name: "MawbNumber",
                table: "tbl_voyage",
                type: "varchar(30)",
                maxLength: 30,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "VoyageNumber",
                table: "tbl_routing",
                type: "varchar(30)",
                maxLength: 30,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "HawbNumber",
                table: "tbl_receptacle",
                type: "varchar(30)",
                maxLength: 30,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "SkuCode",
                table: "tbl_parcel_items",
                type: "varchar(30)",
                maxLength: 30,
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "ReceptacleNumber",
                table: "tbl_parcel_info",
                type: "varchar(30)",
                maxLength: 30,
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "HawbNumber",
                table: "tbl_hawb_items",
                type: "varchar(30)",
                maxLength: 30,
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "HawbNumber",
                table: "tbl_hawb_incoterms",
                type: "varchar(30)",
                maxLength: 30,
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "mawbNumber",
                table: "tbl_hawb",
                type: "varchar(30)",
                maxLength: 30,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<int>(
                name: "tbl_mawb_id",
                table: "tbl_container",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "MawbNumber",
                table: "tbl_container",
                type: "varchar(30)",
                maxLength: 30,
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "HawbNumber",
                table: "tbl_client_header",
                type: "varchar(30)",
                maxLength: 30,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_container_tbl_mawb_tbl_mawb_id",
                table: "tbl_container",
                column: "tbl_mawb_id",
                principalTable: "tbl_mawb",
                principalColumn: "idtbl_mawb",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbl_container_tbl_mawb_tbl_mawb_id",
                table: "tbl_container");

            migrationBuilder.DropColumn(
                name: "SkuCode",
                table: "tbl_parcel_items");

            migrationBuilder.DropColumn(
                name: "ReceptacleNumber",
                table: "tbl_parcel_info");

            migrationBuilder.DropColumn(
                name: "HawbNumber",
                table: "tbl_hawb_items");

            migrationBuilder.DropColumn(
                name: "HawbNumber",
                table: "tbl_hawb_incoterms");

            migrationBuilder.DropColumn(
                name: "MawbNumber",
                table: "tbl_container");

            migrationBuilder.AlterColumn<string>(
                name: "MawbNumber",
                table: "tbl_voyage",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(30)",
                oldMaxLength: 30,
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "VoyageNumber",
                table: "tbl_routing",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(30)",
                oldMaxLength: 30,
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "HawbNumber",
                table: "tbl_receptacle",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(30)",
                oldMaxLength: 30,
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "tbl_hawb_items_reference",
                table: "tbl_hawb_items",
                type: "varchar(50)",
                maxLength: 50,
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "mawbNumber",
                table: "tbl_hawb",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(30)",
                oldMaxLength: 30,
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<int>(
                name: "tbl_mawb_id",
                table: "tbl_container",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "HawbNumber",
                table: "tbl_client_header",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(30)",
                oldMaxLength: 30,
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_container_tbl_mawb_tbl_mawb_id",
                table: "tbl_container",
                column: "tbl_mawb_id",
                principalTable: "tbl_mawb",
                principalColumn: "idtbl_mawb",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
