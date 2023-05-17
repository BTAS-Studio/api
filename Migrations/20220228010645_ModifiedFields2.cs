using Microsoft.EntityFrameworkCore.Migrations;

namespace BTAS.Data.Migrations
{
    public partial class ModifiedFields2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbl_client_contact_group_tbl_client_header_tbl_client_header~",
                table: "tbl_client_contact_group");

            migrationBuilder.DropIndex(
                name: "IX_tbl_client_contact_group_tbl_client_header_id",
                table: "tbl_client_contact_group");

            migrationBuilder.DropColumn(
                name: "tbl_client_header_id",
                table: "tbl_client_contact_group");

            migrationBuilder.RenameColumn(
                name: "tbl_hawb_incoterm_description",
                table: "tbl_hawb_incoterms",
                newName: "tbl_hawb_incoterms_description");

            migrationBuilder.RenameColumn(
                name: "tbl_hawb_incoterm_code",
                table: "tbl_hawb_incoterms",
                newName: "tbl_hawb_incoterms_code");

            migrationBuilder.RenameColumn(
                name: "tbl_hawb_incoterm_id",
                table: "tbl_hawb_incoterms",
                newName: "idtbl_hawb_incoterms");

            migrationBuilder.CreateTable(
                name: "tbl_client_contact_grouptbl_client_header",
                columns: table => new
                {
                    clientHeadersidtbl_client_header = table.Column<int>(type: "int", nullable: false),
                    contactGroupsidtbl_client_contact_group = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_client_contact_grouptbl_client_header", x => new { x.clientHeadersidtbl_client_header, x.contactGroupsidtbl_client_contact_group });
                    table.ForeignKey(
                        name: "FK_tbl_client_contact_grouptbl_client_header_tbl_client_contact~",
                        column: x => x.contactGroupsidtbl_client_contact_group,
                        principalTable: "tbl_client_contact_group",
                        principalColumn: "idtbl_client_contact_group",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tbl_client_contact_grouptbl_client_header_tbl_client_header_~",
                        column: x => x.clientHeadersidtbl_client_header,
                        principalTable: "tbl_client_header",
                        principalColumn: "idtbl_client_header",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_client_contact_grouptbl_client_header_contactGroupsidtbl~",
                table: "tbl_client_contact_grouptbl_client_header",
                column: "contactGroupsidtbl_client_contact_group");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbl_client_contact_grouptbl_client_header");

            migrationBuilder.RenameColumn(
                name: "tbl_hawb_incoterms_description",
                table: "tbl_hawb_incoterms",
                newName: "tbl_hawb_incoterm_description");

            migrationBuilder.RenameColumn(
                name: "tbl_hawb_incoterms_code",
                table: "tbl_hawb_incoterms",
                newName: "tbl_hawb_incoterm_code");

            migrationBuilder.RenameColumn(
                name: "idtbl_hawb_incoterms",
                table: "tbl_hawb_incoterms",
                newName: "tbl_hawb_incoterm_id");

            migrationBuilder.AddColumn<int>(
                name: "tbl_client_header_id",
                table: "tbl_client_contact_group",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_tbl_client_contact_group_tbl_client_header_id",
                table: "tbl_client_contact_group",
                column: "tbl_client_header_id");

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_client_contact_group_tbl_client_header_tbl_client_header~",
                table: "tbl_client_contact_group",
                column: "tbl_client_header_id",
                principalTable: "tbl_client_header",
                principalColumn: "idtbl_client_header",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
