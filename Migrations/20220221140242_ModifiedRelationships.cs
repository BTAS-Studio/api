using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BTAS.Data.Migrations
{
    public partial class ModifiedRelationships : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tbl_hawb_incoterms",
                columns: table => new
                {
                    tbl_hawb_incoterm_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    tbl_hawb_incoterm_code = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_hawb_incoterm_description = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_hawb_incoterms", x => x.tbl_hawb_incoterm_id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tbl_items_sku",
                columns: table => new
                {
                    idtbl_items_sku = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    tbl_items_weightUnit = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_items_weight = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false),
                    tbl_items_dimensionUnit = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_items_length = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false),
                    tbl_items_width = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false),
                    tbl_items_height = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false),
                    tbl_items_volume = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false),
                    tbl_items_number = table.Column<int>(type: "int", nullable: false),
                    tbl_items_skuCode = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_items_description = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_items_nativeDescription = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_items_hsCode = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_items_originCountry = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_items_value = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    tbl_items_productUrl = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_items_batteryType = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_items_batteryPacking = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_items_dangerousGoods = table.Column<byte>(type: "tinyint unsigned", nullable: false),
                    tbl_items_batchNumber = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_items_sku", x => x.idtbl_items_sku);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tbl_mawb",
                columns: table => new
                {
                    idtbl_mawb = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_mawb", x => x.idtbl_mawb);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tbl_hawb",
                columns: table => new
                {
                    idtbl_hawb = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    tbl_mawb_id = table.Column<int>(type: "int", nullable: false),
                    tbl_hawb_incotermCode = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_hawb_airJobReference = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_hawb_shipperId = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_hawb_pieces = table.Column<int>(type: "int", nullable: false),
                    tbl_hawb_weight = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false),
                    tbl_hawb_volume = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false),
                    tbl_hawb_originAirport = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_hawb_destinationAirport = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_hawb_value = table.Column<int>(type: "int", nullable: false),
                    tbl_hawb_description = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_hawb_FTA = table.Column<byte>(type: "tinyint unsigned", nullable: false),
                    tbl_hawb_shipperRef = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_hawb_coloaderCode = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_hawb_latestTracking = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_hawb_timestamp = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    tbl_hawb_status = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_hawb_service = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_hawb_deliverydate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    tbl_hawb_deliveryInstructions = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_hawb_clearancedate = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_hawb_coo = table.Column<byte>(type: "tinyint unsigned", nullable: false),
                    tbl_hawb_type = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_hawb_tailLiftO = table.Column<byte>(type: "tinyint unsigned", nullable: false),
                    tbl_hawb_tailLiftD = table.Column<byte>(type: "tinyint unsigned", nullable: false),
                    tbl_hawb_DG = table.Column<byte>(type: "tinyint unsigned", nullable: false),
                    tbl_hawb_UN = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_hawb_packaging = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_hawb_class = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_hawb_currency = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_hawb_incoterms_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_hawb", x => x.idtbl_hawb);
                    table.ForeignKey(
                        name: "FK_tbl_hawb_tbl_hawb_incoterms_tbl_hawb_incoterms_id",
                        column: x => x.tbl_hawb_incoterms_id,
                        principalTable: "tbl_hawb_incoterms",
                        principalColumn: "tbl_hawb_incoterm_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tbl_hawb_tbl_mawb_tbl_mawb_id",
                        column: x => x.tbl_mawb_id,
                        principalTable: "tbl_mawb",
                        principalColumn: "idtbl_mawb",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tbl_client_header",
                columns: table => new
                {
                    idtbl_client_header = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    tbl_client_header_code = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_client_header_name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_client_header_is_agent = table.Column<byte>(type: "tinyint unsigned", nullable: false),
                    tbl_client_header_is_consignee = table.Column<byte>(type: "tinyint unsigned", nullable: false),
                    tbl_client_header_is_consignor = table.Column<byte>(type: "tinyint unsigned", nullable: false),
                    tbl_client_header_is_broker = table.Column<byte>(type: "tinyint unsigned", nullable: false),
                    tbl_client_header_is_carrier = table.Column<byte>(type: "tinyint unsigned", nullable: false),
                    tbl_client_header_is_payable = table.Column<byte>(type: "tinyint unsigned", nullable: false),
                    tbl_client_header_is_receivable = table.Column<byte>(type: "tinyint unsigned", nullable: false),
                    tbl_client_header_created_by = table.Column<int>(type: "int", nullable: false),
                    tbl_client_header_created_date = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    tbl_client_header_address1 = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_client_header_address2 = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_client_header_suburb = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_client_header_city = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_client_header_postcode = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_client_header_state = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_client_header_country = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_client_header_closest_port = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_client_header_abn = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_client_header_main_email = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_client_header_main_phone = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_client_header_main_contact = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_client_header_active = table.Column<byte>(type: "tinyint unsigned", nullable: false),
                    tbl_hawb_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_client_header", x => x.idtbl_client_header);
                    table.ForeignKey(
                        name: "FK_tbl_client_header_tbl_hawb_tbl_hawb_id",
                        column: x => x.tbl_hawb_id,
                        principalTable: "tbl_hawb",
                        principalColumn: "idtbl_hawb",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tbl_hawb_items",
                columns: table => new
                {
                    idtbl_hawb_items = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    tbl_hawb_id = table.Column<int>(type: "int", nullable: false),
                    tbl_hawb_items_weight = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false),
                    tbl_hawb_items_length = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false),
                    tbl_hawb_items_width = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false),
                    tbl_hawb_items_height = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false),
                    tbl_hawb_items_weightUnit = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_hawb_items_lenghtUnit = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_hawb_items_dg = table.Column<byte>(type: "tinyint unsigned", nullable: false),
                    tbl_hawb_items_description = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_hawb_items_type = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_hawb_items_reference = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_hawb_items_qty = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_hawb_items", x => x.idtbl_hawb_items);
                    table.ForeignKey(
                        name: "FK_tbl_hawb_items_tbl_hawb_tbl_hawb_id",
                        column: x => x.tbl_hawb_id,
                        principalTable: "tbl_hawb",
                        principalColumn: "idtbl_hawb",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tbl_receptacle",
                columns: table => new
                {
                    idtbl_receptacle = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    tbl_hawb_id = table.Column<int>(type: "int", nullable: false),
                    tbl_receptacle_shipper_id = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_receptacle_ref = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_receptacle_mode = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_receptacle_type = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_receptacle_no_items = table.Column<int>(type: "int", nullable: false),
                    tbl_receptacle_weight = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false),
                    tbl_receptacle_status = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_receptacle_origin = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_receptacle_dest = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_receptacle_creation = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    tbl_receptacle_length = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false),
                    tbl_receptacle_width = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false),
                    tbl_receptacle_height = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_receptacle", x => x.idtbl_receptacle);
                    table.ForeignKey(
                        name: "FK_tbl_receptacle_tbl_hawb_tbl_hawb_id",
                        column: x => x.tbl_hawb_id,
                        principalTable: "tbl_hawb",
                        principalColumn: "idtbl_hawb",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tbl_client_contact_details",
                columns: table => new
                {
                    idtbl_client_contact_details = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    tbl_client_contact_details_first_name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_client_contact_details_last_name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_client_contact_details_tel = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_client_contact_details_email = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_client_contact_details_position = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_client_contact_details_type = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_client_contact_details_active = table.Column<byte>(type: "tinyint unsigned", nullable: false),
                    tbl_client_header_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_client_contact_details", x => x.idtbl_client_contact_details);
                    table.ForeignKey(
                        name: "FK_tbl_client_contact_details_tbl_client_header_tbl_client_head~",
                        column: x => x.tbl_client_header_id,
                        principalTable: "tbl_client_header",
                        principalColumn: "idtbl_client_header",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tbl_client_contact_group",
                columns: table => new
                {
                    idtbl_client_contact_group = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    tbl_client_contact_group_number = table.Column<int>(type: "int", nullable: false),
                    tbl_client_contact_group_default = table.Column<byte>(type: "tinyint unsigned", nullable: false),
                    tbl_client_contact_group_active = table.Column<byte>(type: "tinyint unsigned", nullable: false),
                    tbl_client_header_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_client_contact_group", x => x.idtbl_client_contact_group);
                    table.ForeignKey(
                        name: "FK_tbl_client_contact_group_tbl_client_header_tbl_client_header~",
                        column: x => x.tbl_client_header_id,
                        principalTable: "tbl_client_header",
                        principalColumn: "idtbl_client_header",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tbl_parcel_info",
                columns: table => new
                {
                    idtbl_parcel_info = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    tbl_parcel_info_batchId = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_parcel_info_shipperId = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_parcel_info_trackingNo = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_parcel_info_referenceNo = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_parcel_info_deliveryAddressLine1 = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_parcel_info_deliveryAddressLine2 = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_parcel_info_deliveryAddressLine3 = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_parcel_info_deliveryCity = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_parcel_info_deliveryCountry = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_parcel_info_description = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_parcel_info_nativeDescription = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_parcel_info_deliveryEmail = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_parcel_info_facility = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_parcel_info_instruction = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_parcel_info_invoiceCurrency = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_parcel_info_invoiceValue = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false),
                    tbl_parcel_info_phone = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_parcel_info_platform = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_parcel_info_deliverySuburb = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_parcel_info_deliveryPostcode = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_parcel_info_deliveryCompany = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_parcel_info_deliveryName = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_parcel_info_serviceCode = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_parcel_info_serviceOption = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_parcel_info_deliveryState = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_parcel_info_shipperName = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_parcel_info_shipperAddressLine1 = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_parcel_info_shipperAddressLine2 = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_parcel_info_shipperAddressLine3 = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_parcel_info_shipperCity = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_parcel_info_shipperState = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_parcel_info_shipperPostcode = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_parcel_info_shipperCountry = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_parcel_info_shipperPhone = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_parcel_info_authorityToLeave = table.Column<byte>(type: "tinyint unsigned", nullable: false),
                    tbl_parcel_info_incoterm = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_parcel_info_vendorid = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_parcel_info_gstexemptioncode = table.Column<byte>(type: "tinyint unsigned", nullable: false),
                    tbl_parcel_info_abnnumber = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_parcel_info_sortCode = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_parcel_info_coveramount = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false),
                    tbl_parcel_info_orderItems = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_parcel_info_deliveryInstructions = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_parcel_info_lockerService = table.Column<byte>(type: "tinyint unsigned", nullable: false),
                    tbl_parcel_info_returnName = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_parcel_info_returnAddress1 = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_parcel_info_returnAddress2 = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_parcel_info_returnAddress3 = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_parcel_info_returnCity = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_parcel_info_returnState = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_parcel_info_returnPostcode = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_parcel_info_returnCountry = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_parcel_info_returnOption = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_parcel_info_parcelItems = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_parcel_info_shipperEmail = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_parcel_info_shipment = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_parcel_info_deliveryContact = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_parcel_info_deliveryContactPhone = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_parcel_info_deliveryContactEmail = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_parcel_info_shipperSuburb = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_parcel_info_deliveryPhone = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_parcel_info_shipperInstructions = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_parcel_info_shipperContact = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_parcel_info_warehouse = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_parcel_info_timestamp = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    tbl_parcel_info_readyDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    tbl_parcel_info_dg = table.Column<byte>(type: "tinyint unsigned", nullable: false),
                    tbl_parcel_info_dgClass = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_parcel_info_dgUn = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_parcel_info_dgPackaging = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_parcel_info_tailLiftO = table.Column<byte>(type: "tinyint unsigned", nullable: false),
                    tbl_parcel_info_tailLiftD = table.Column<byte>(type: "tinyint unsigned", nullable: false),
                    tbl_parcel_info_shipperCompany = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_parcel_info_shipperLastName = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_parcel_info_deliveryDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    tbl_receptacle_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_parcel_info", x => x.idtbl_parcel_info);
                    table.ForeignKey(
                        name: "FK_tbl_parcel_info_tbl_receptacle_tbl_receptacle_id",
                        column: x => x.tbl_receptacle_id,
                        principalTable: "tbl_receptacle",
                        principalColumn: "idtbl_receptacle",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tbl_parcel_items",
                columns: table => new
                {
                    idtbl_parcel_items = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    tbl_parcel_items_info_id = table.Column<int>(type: "int", nullable: false),
                    tbl_parcel_items_parcelWeight = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false),
                    tbl_parcel_items_parcelLength = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false),
                    tbl_parcel_items_parcelWidth = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false),
                    tbl_parcel_items_parcelHeight = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false),
                    tbl_parcel_items_parcelWeightUnit = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_parcel_items_parcelDimensionUnit = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_parcel_items_parcelDangerousGoods = table.Column<byte>(type: "tinyint unsigned", nullable: false),
                    tbl_parcel_items_parcelDescription = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_parcel_items_parcelType = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_parcel_items_parcelReference = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_parcel_items_parcelQty = table.Column<int>(type: "int", nullable: false),
                    tbl_items_sku_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_parcel_items", x => x.idtbl_parcel_items);
                    table.ForeignKey(
                        name: "FK_tbl_parcel_items_tbl_items_sku_tbl_items_sku_id",
                        column: x => x.tbl_items_sku_id,
                        principalTable: "tbl_items_sku",
                        principalColumn: "idtbl_items_sku",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tbl_parcel_items_tbl_parcel_info_tbl_parcel_items_info_id",
                        column: x => x.tbl_parcel_items_info_id,
                        principalTable: "tbl_parcel_info",
                        principalColumn: "idtbl_parcel_info",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_client_contact_details_tbl_client_header_id",
                table: "tbl_client_contact_details",
                column: "tbl_client_header_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_client_contact_group_tbl_client_header_id",
                table: "tbl_client_contact_group",
                column: "tbl_client_header_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_client_header_tbl_hawb_id",
                table: "tbl_client_header",
                column: "tbl_hawb_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_hawb_tbl_hawb_incoterms_id",
                table: "tbl_hawb",
                column: "tbl_hawb_incoterms_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_hawb_tbl_mawb_id",
                table: "tbl_hawb",
                column: "tbl_mawb_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_hawb_items_tbl_hawb_id",
                table: "tbl_hawb_items",
                column: "tbl_hawb_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_parcel_info_tbl_receptacle_id",
                table: "tbl_parcel_info",
                column: "tbl_receptacle_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_parcel_items_tbl_items_sku_id",
                table: "tbl_parcel_items",
                column: "tbl_items_sku_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_parcel_items_tbl_parcel_items_info_id",
                table: "tbl_parcel_items",
                column: "tbl_parcel_items_info_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_receptacle_tbl_hawb_id",
                table: "tbl_receptacle",
                column: "tbl_hawb_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbl_client_contact_details");

            migrationBuilder.DropTable(
                name: "tbl_client_contact_group");

            migrationBuilder.DropTable(
                name: "tbl_hawb_items");

            migrationBuilder.DropTable(
                name: "tbl_parcel_items");

            migrationBuilder.DropTable(
                name: "tbl_client_header");

            migrationBuilder.DropTable(
                name: "tbl_items_sku");

            migrationBuilder.DropTable(
                name: "tbl_parcel_info");

            migrationBuilder.DropTable(
                name: "tbl_receptacle");

            migrationBuilder.DropTable(
                name: "tbl_hawb");

            migrationBuilder.DropTable(
                name: "tbl_hawb_incoterms");

            migrationBuilder.DropTable(
                name: "tbl_mawb");
        }
    }
}
