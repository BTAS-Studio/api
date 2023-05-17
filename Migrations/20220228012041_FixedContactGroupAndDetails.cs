using Microsoft.EntityFrameworkCore.Migrations;

namespace BTAS.Data.Migrations
{
    public partial class FixedContactGroupAndDetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbl_client_contact_grouptbl_client_header");

            migrationBuilder.CreateTable(
                name: "tbl_client_contact_detailstbl_client_contact_group",
                columns: table => new
                {
                    contactDetailsidtbl_client_contact_details = table.Column<int>(type: "int", nullable: false),
                    contactGroupsidtbl_client_contact_group = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_client_contact_detailstbl_client_contact_group", x => new { x.contactDetailsidtbl_client_contact_details, x.contactGroupsidtbl_client_contact_group });
                    table.ForeignKey(
                        name: "FK_tbl_client_contact_detailstbl_client_contact_group_tbl_clie~1",
                        column: x => x.contactGroupsidtbl_client_contact_group,
                        principalTable: "tbl_client_contact_group",
                        principalColumn: "idtbl_client_contact_group",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tbl_client_contact_detailstbl_client_contact_group_tbl_clien~",
                        column: x => x.contactDetailsidtbl_client_contact_details,
                        principalTable: "tbl_client_contact_details",
                        principalColumn: "idtbl_client_contact_details",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_client_contact_detailstbl_client_contact_group_contactGr~",
                table: "tbl_client_contact_detailstbl_client_contact_group",
                column: "contactGroupsidtbl_client_contact_group");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbl_client_contact_detailstbl_client_contact_group");

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
    }
}
