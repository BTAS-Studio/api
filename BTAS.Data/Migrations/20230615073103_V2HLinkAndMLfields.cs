using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BTAS.Data.Migrations
{
    /// <inheritdoc />
    public partial class V2HLinkAndMLfields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "tbl_milestone_createdBy",
                table: "tbl_milestone_link",
                newName: "tbl_milestone_link_createdBy");

            migrationBuilder.RenameColumn(
                name: "tbl_miestone_createdDate",
                table: "tbl_milestone_link",
                newName: "tbl_milestone_link_createdDate");

            migrationBuilder.RenameIndex(
                name: "IX_tbl_hawb_tbl_master_id",
                table: "tbl_house",
                newName: "IX_tbl_house_tbl_master_id");

            migrationBuilder.RenameIndex(
                name: "IX_tbl_hawb_tbl_container_id",
                table: "tbl_house",
                newName: "IX_tbl_house_tbl_container_id");

            migrationBuilder.AlterColumn<decimal>(
                name: "tbl_sea_shipment_weight",
                table: "tbl_sea_shipment",
                type: "decimal(10)",
                precision: 10,
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(10,30)",
                oldPrecision: 10,
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "tbl_sea_shipment_volume",
                table: "tbl_sea_shipment",
                type: "decimal(10)",
                precision: 10,
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(10,30)",
                oldPrecision: 10,
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "tbl_sea_shipment_value",
                table: "tbl_sea_shipment",
                type: "decimal(10)",
                precision: 10,
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(10,30)",
                oldPrecision: 10,
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "tbl_sea_shipment_UN",
                table: "tbl_sea_shipment",
                type: "decimal(10)",
                precision: 10,
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(10,30)",
                oldPrecision: 10,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MasterCode",
                table: "tbl_house",
                type: "varchar(50)",
                maxLength: 50,
                nullable: true,
                collation: "utf8mb4_general_ci",
                oldClrType: typeof(string),
                oldType: "varchar(30)",
                oldMaxLength: 30,
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("Relational:Collation", "utf8mb4_general_ci");

            migrationBuilder.AlterColumn<string>(
                name: "IncotermsCode",
                table: "tbl_house",
                type: "varchar(50)",
                maxLength: 50,
                nullable: true,
                collation: "utf8mb4_general_ci",
                oldClrType: typeof(string),
                oldType: "varchar(30)",
                oldMaxLength: 30,
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("Relational:Collation", "utf8mb4_general_ci");

            migrationBuilder.AlterColumn<string>(
                name: "ContainerCode",
                table: "tbl_house",
                type: "varchar(50)",
                maxLength: 50,
                nullable: true,
                collation: "utf8mb4_general_ci",
                oldClrType: typeof(string),
                oldType: "varchar(30)",
                oldMaxLength: 30,
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("Relational:Collation", "utf8mb4_general_ci");

            migrationBuilder.AddColumn<string>(
                name: "VoyageCode",
                table: "tbl_house",
                type: "varchar(50)",
                maxLength: 50,
                nullable: true,
                collation: "utf8mb4_general_ci")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "tbl_voyage_id",
                table: "tbl_house",
                type: "int(11)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_tbl_house_tbl_voyage_id",
                table: "tbl_house",
                column: "tbl_voyage_id");

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_house_tbl_voyage_tbl_voyage_id",
                table: "tbl_house",
                column: "tbl_voyage_id",
                principalTable: "tbl_voyage",
                principalColumn: "idtbl_voyage");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbl_house_tbl_voyage_tbl_voyage_id",
                table: "tbl_house");

            migrationBuilder.DropIndex(
                name: "IX_tbl_house_tbl_voyage_id",
                table: "tbl_house");

            migrationBuilder.DropColumn(
                name: "VoyageCode",
                table: "tbl_house");

            migrationBuilder.DropColumn(
                name: "tbl_voyage_id",
                table: "tbl_house");

            migrationBuilder.RenameColumn(
                name: "tbl_milestone_link_createdDate",
                table: "tbl_milestone_link",
                newName: "tbl_miestone_createdDate");

            migrationBuilder.RenameColumn(
                name: "tbl_milestone_link_createdBy",
                table: "tbl_milestone_link",
                newName: "tbl_milestone_createdBy");

            migrationBuilder.RenameIndex(
                name: "IX_tbl_house_tbl_master_id",
                table: "tbl_house",
                newName: "IX_tbl_hawb_tbl_master_id");

            migrationBuilder.RenameIndex(
                name: "IX_tbl_house_tbl_container_id",
                table: "tbl_house",
                newName: "IX_tbl_hawb_tbl_container_id");

            migrationBuilder.AlterColumn<decimal>(
                name: "tbl_sea_shipment_weight",
                table: "tbl_sea_shipment",
                type: "decimal(10,30)",
                precision: 10,
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(10)",
                oldPrecision: 10,
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "tbl_sea_shipment_volume",
                table: "tbl_sea_shipment",
                type: "decimal(10,30)",
                precision: 10,
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(10)",
                oldPrecision: 10,
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "tbl_sea_shipment_value",
                table: "tbl_sea_shipment",
                type: "decimal(10,30)",
                precision: 10,
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(10)",
                oldPrecision: 10,
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "tbl_sea_shipment_UN",
                table: "tbl_sea_shipment",
                type: "decimal(10,30)",
                precision: 10,
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(10)",
                oldPrecision: 10,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MasterCode",
                table: "tbl_house",
                type: "varchar(30)",
                maxLength: 30,
                nullable: true,
                collation: "utf8mb4_general_ci",
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldMaxLength: 50,
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("Relational:Collation", "utf8mb4_general_ci");

            migrationBuilder.AlterColumn<string>(
                name: "IncotermsCode",
                table: "tbl_house",
                type: "varchar(30)",
                maxLength: 30,
                nullable: true,
                collation: "utf8mb4_general_ci",
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldMaxLength: 50,
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("Relational:Collation", "utf8mb4_general_ci");

            migrationBuilder.AlterColumn<string>(
                name: "ContainerCode",
                table: "tbl_house",
                type: "varchar(30)",
                maxLength: 30,
                nullable: true,
                collation: "utf8mb4_general_ci",
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldMaxLength: 50,
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("Relational:Collation", "utf8mb4_general_ci");
        }
    }
}
