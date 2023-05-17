using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BTAS.Data.Migrations
{
    public partial class InitialMigrate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tbl_3pl_routings",
                columns: table => new
                {
                    tbl_routings_id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    tbl_routings_states = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_routings_suburbs = table.Column<string>(type: "varchar(5)", maxLength: 5, nullable: false, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_routings_code = table.Column<string>(type: "varchar(3)", maxLength: 3, nullable: false, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.tbl_routings_id);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_general_ci");

            migrationBuilder.CreateTable(
                name: "tbl_address",
                columns: table => new
                {
                    idtbl_address = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    tbl_address_code = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_address_type = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_address_address1 = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_address_address2 = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_address_suburb = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_address_city = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_address_state = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_address_postcode = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_address_country = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.idtbl_address);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_general_ci");

            migrationBuilder.CreateTable(
                name: "tbl_amazon_routings",
                columns: table => new
                {
                    tbl_routings_id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    tbl_routings_states = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_routings_suburbs = table.Column<string>(type: "varchar(5)", maxLength: 5, nullable: false, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_routings_code = table.Column<string>(type: "varchar(3)", maxLength: 3, nullable: false, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.tbl_routings_id);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_general_ci");

            migrationBuilder.CreateTable(
                name: "tbl_austway_routings",
                columns: table => new
                {
                    tbl_routings_id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    tbl_routings_states = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_routings_suburbs = table.Column<string>(type: "varchar(5)", maxLength: 5, nullable: false, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_routings_code = table.Column<string>(type: "varchar(3)", maxLength: 3, nullable: false, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.tbl_routings_id);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_general_ci");

            migrationBuilder.CreateTable(
                name: "tbl_barcodes",
                columns: table => new
                {
                    tbl_barcodes_id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    tbl_barcodes_parcel_id = table.Column<int>(type: "int(11)", nullable: false),
                    tbl_barcodes_code = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_barcodes_manifest_link_id = table.Column<int>(type: "int(11)", nullable: true),
                    tbl_barcodes_sequence = table.Column<string>(type: "varchar(3)", maxLength: 3, nullable: false, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_barcodes_shipment_id = table.Column<int>(type: "int(11)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.tbl_barcodes_id);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_general_ci");

            migrationBuilder.CreateTable(
                name: "tbl_border_routings",
                columns: table => new
                {
                    tbl_routings_id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    tbl_routings_states = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_routings_suburbs = table.Column<string>(type: "varchar(5)", maxLength: 5, nullable: false, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_routings_code = table.Column<string>(type: "varchar(3)", maxLength: 3, nullable: false, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.tbl_routings_id);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_general_ci");

            migrationBuilder.CreateTable(
                name: "tbl_carrier_api_response",
                columns: table => new
                {
                    idtbl_carrier_api_response = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    tbl_carrier_api_response_message = table.Column<string>(type: "longtext", nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_carrier_api_response_ind = table.Column<int>(type: "int(1)", nullable: true),
                    tbl_carrier_api_response_parcelId = table.Column<int>(type: "int(11)", nullable: true),
                    tbl_carrier_api_trackingRef = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_carrier_api_manifestId = table.Column<int>(type: "int(11)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.idtbl_carrier_api_response);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_general_ci");

            migrationBuilder.CreateTable(
                name: "tbl_carrier_info",
                columns: table => new
                {
                    idtbl_carrier_info = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    tbl_carrier_name = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_carrier_address1 = table.Column<string>(type: "varchar(60)", maxLength: 60, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_carrier_address2 = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_carrier_city = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_carrier_suburb = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_carrier_postCode = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_carrier_state = table.Column<string>(type: "varchar(3)", maxLength: 3, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_carrier_country_origin = table.Column<string>(type: "varchar(3)", maxLength: 3, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_carrier_country_destination = table.Column<string>(type: "varchar(3)", maxLength: 3, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_carrier_email = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_carrier_phone = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_carrier_contactName = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_carrier_code = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: false, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_carrier_type = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_carrier_active = table.Column<sbyte>(type: "tinyint(4)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.idtbl_carrier_info);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_general_ci");

            migrationBuilder.CreateTable(
                name: "tbl_client_contact_group",
                columns: table => new
                {
                    idtbl_client_contact_group = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    tbl_client_contact_group_code = table.Column<int>(type: "int(11)", nullable: true),
                    tbl_client_contact_group_isDefault = table.Column<byte>(type: "tinyint(3) unsigned", nullable: false),
                    tbl_client_contact_group_isActive = table.Column<byte>(type: "tinyint(3) unsigned", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.idtbl_client_contact_group);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_general_ci");

            migrationBuilder.CreateTable(
                name: "tbl_containerType",
                columns: table => new
                {
                    idtbl_containerType = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    tbl_containerType_description = table.Column<string>(type: "longtext", nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.idtbl_containerType);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_general_ci");

            migrationBuilder.CreateTable(
                name: "tbl_default_settings",
                columns: table => new
                {
                    idtbl_default_settings = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    tbl_address_type = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_incoterm_id = table.Column<int>(type: "int(11)", nullable: false),
                    isBillTo = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    tbl_contact_group_id = table.Column<int>(type: "int(11)", nullable: false),
                    tbl_default_settings_active = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DateAdded = table.Column<DateTime>(type: "datetime(6)", maxLength: 6, nullable: false),
                    AddedBy = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.idtbl_default_settings);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_general_ci");

            migrationBuilder.CreateTable(
                name: "tbl_dynamic_filters",
                columns: table => new
                {
                    idtbl_dynamic_filters = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    tbl_dynamic_filters_column = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_dynamic_filters_condition = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_dynamic_filters_value = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_dynamic_filters_module = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_dynamic_filters_user = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.idtbl_dynamic_filters);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_general_ci");

            migrationBuilder.CreateTable(
                name: "tbl_field_conditions",
                columns: table => new
                {
                    tbl_field_conditions_id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    tbl_field_conditions_name = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_field_conditions_requirement = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_field_conditions_type = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_field_conditions = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.tbl_field_conditions_id);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_general_ci");

            migrationBuilder.CreateTable(
                name: "tbl_hunterrates",
                columns: table => new
                {
                    tbl_hunterrates_injectionport = table.Column<string>(type: "varchar(3)", maxLength: 3, nullable: false, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_hunterrates_zone = table.Column<int>(type: "int(3)", nullable: false),
                    tbl_hunterrates_min = table.Column<decimal>(type: "decimal(15,2)", precision: 15, scale: 2, nullable: false),
                    tbl_hunterrates_base = table.Column<decimal>(type: "decimal(15,2)", precision: 15, scale: 2, nullable: false),
                    tbl_hunterrates_perkg = table.Column<decimal>(type: "decimal(15,2)", precision: 15, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => new { x.tbl_hunterrates_injectionport, x.tbl_hunterrates_zone })
                        .Annotation("MySql:IndexPrefixLength", new[] { 0, 0 });
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_general_ci");

            migrationBuilder.CreateTable(
                name: "tbl_hunterzones",
                columns: table => new
                {
                    tbl_hunterzones_suburb = table.Column<string>(type: "varchar(55)", maxLength: 55, nullable: false, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_hunterzones_postcode = table.Column<int>(type: "int(5)", nullable: false),
                    tbl_hunterzones_state = table.Column<string>(type: "varchar(3)", maxLength: 3, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_hunterzones_routescan = table.Column<string>(type: "varchar(3)", maxLength: 3, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_hunterzones_labelzone = table.Column<string>(type: "varchar(3)", maxLength: 3, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_hunterzones_zone = table.Column<int>(type: "int(2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => new { x.tbl_hunterzones_suburb, x.tbl_hunterzones_postcode })
                        .Annotation("MySql:IndexPrefixLength", new[] { 0, 0 });
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_general_ci");

            migrationBuilder.CreateTable(
                name: "tbl_incoterms",
                columns: table => new
                {
                    idtbl_incoterm = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    tbl_incoterm_code = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_incoterm_description = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.idtbl_incoterm);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_general_ci");

            migrationBuilder.CreateTable(
                name: "tbl_item_sku",
                columns: table => new
                {
                    idtbl_item_sku = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    tbl_item_sku_code = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_items_weight = table.Column<decimal>(type: "decimal(12,3)", precision: 12, scale: 3, nullable: false),
                    tbl_items_weightUnit = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_items_length = table.Column<decimal>(type: "decimal(12,3)", precision: 12, scale: 3, nullable: false),
                    tbl_items_width = table.Column<decimal>(type: "decimal(12,3)", precision: 12, scale: 3, nullable: false),
                    tbl_items_height = table.Column<decimal>(type: "decimal(12,3)", precision: 12, scale: 3, nullable: false),
                    tbl_items_volume = table.Column<decimal>(type: "decimal(12,3)", precision: 12, scale: 3, nullable: false),
                    tbl_items_volumeUnit = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_items_qty = table.Column<int>(type: "int(11)", nullable: false),
                    tbl_items_description = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_items_nativeDescription = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_items_hsCode = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_items_originCountry = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_items_value = table.Column<decimal>(type: "decimal(12,2)", precision: 12, scale: 2, nullable: false),
                    tbl_items_productUrl = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_items_batteryType = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_items_batteryPacking = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_items_dangerousGoods = table.Column<byte>(type: "tinyint(3) unsigned", nullable: false),
                    tbl_items_batchNumber = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.idtbl_item_sku);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_general_ci");

            migrationBuilder.CreateTable(
                name: "tbl_manifests",
                columns: table => new
                {
                    idtbl_manifest = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    tbl_manifest_created_date = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    tbl_manifest_sent_date = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    tbl_manifest_carrier = table.Column<string>(type: "longtext", nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_manifest_active = table.Column<int>(type: "int", nullable: false),
                    tbl_manifest_prefix = table.Column<string>(type: "longtext", nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_manifests", x => x.idtbl_manifest);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_general_ci");

            migrationBuilder.CreateTable(
                name: "tbl_nz_routings",
                columns: table => new
                {
                    tbl_routings_id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    tbl_routings_states = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_routings_suburbs = table.Column<string>(type: "varchar(5)", maxLength: 5, nullable: false, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_routings_code = table.Column<string>(type: "varchar(3)", maxLength: 3, nullable: false, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.tbl_routings_id);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_general_ci");

            migrationBuilder.CreateTable(
                name: "tbl_parcel_tracking",
                columns: table => new
                {
                    tbl_parcel_tracking_id = table.Column<int>(type: "int(11)", nullable: false),
                    tbl_parcel_tracking_shipmentId = table.Column<string>(type: "varchar(5)", maxLength: 5, nullable: false, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_parcel_tracking_received = table.Column<sbyte>(type: "tinyint(4)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.tbl_parcel_tracking_id);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_general_ci");

            migrationBuilder.CreateTable(
                name: "tbl_pluscourier",
                columns: table => new
                {
                    tbl_pluscourier_id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    tbl_pluscourier_suburb = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_pluscourier_postcode = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_pluscourier_distance = table.Column<int>(type: "int(11)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.tbl_pluscourier_id);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_general_ci");

            migrationBuilder.CreateTable(
                name: "tbl_pluscourier_rate",
                columns: table => new
                {
                    tbl_pluscourier_rate_id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    tbl_pluscourier_rate_pallet = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: true),
                    tbl_pluscourier_rate_km = table.Column<int>(type: "int(11)", nullable: true),
                    tbl_pluscourier_rate_notes = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.tbl_pluscourier_rate_id);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_general_ci");

            migrationBuilder.CreateTable(
                name: "tbl_returns",
                columns: table => new
                {
                    tbl_returns_id = table.Column<int>(type: "int(11)", nullable: false),
                    tbl_returns_reference = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_returns_name = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_returns_address1 = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_returns_address2 = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_returns_address3 = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_returns_city = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_returns_suburb = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_returns_state = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_returns_postcode = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_returns_country = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_returns_option = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_returns_status = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.tbl_returns_id);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_general_ci");

            migrationBuilder.CreateTable(
                name: "tbl_returns_sku",
                columns: table => new
                {
                    tbl_returns_sku_id = table.Column<int>(type: "int(11)", nullable: false),
                    tbl_returns_sku_description = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_returns_sku_batch = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_returns_sku_hscode = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_returns_sku_dangerousgoods = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_returns_sku_action = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_returns_sku_value = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.tbl_returns_sku_id);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_general_ci");

            migrationBuilder.CreateTable(
                name: "tbl_sea_shipment",
                columns: table => new
                {
                    tbl_sea_shipment_id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    tbl_sea_shipment_mowb = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_sea_shipment_howb = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_sea_shipment_shippingLine = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_sea_shipment_incotermCode = table.Column<string>(type: "varchar(5)", maxLength: 5, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_sea_shipment_seaJobReference = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_sea_shipment_shipperID = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_sea_shipment_pieces = table.Column<int>(type: "int(11)", nullable: true),
                    tbl_sea_shipment_weight = table.Column<decimal>(type: "decimal(10)", precision: 10, nullable: true),
                    tbl_sea_shipment_volume = table.Column<decimal>(type: "decimal(10)", precision: 10, nullable: true),
                    tbl_sea_shipment_etd = table.Column<DateTime>(type: "datetime", nullable: true),
                    tbl_sea_shipment_eta = table.Column<DateTime>(type: "datetime", nullable: true),
                    tbl_sea_shipment_atd = table.Column<DateTime>(type: "datetime", nullable: true),
                    tbl_sea_shipment_ata = table.Column<DateTime>(type: "datetime", nullable: true),
                    tbl_sea_shipment_originPort = table.Column<string>(type: "varchar(5)", maxLength: 5, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_sea_shipment_destinationPort = table.Column<string>(type: "varchar(5)", maxLength: 5, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_sea_shipment_transit1 = table.Column<string>(type: "varchar(5)", maxLength: 5, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_sea_shipment_transit2 = table.Column<string>(type: "varchar(5)", maxLength: 5, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_sea_shipment_transit3 = table.Column<string>(type: "varchar(5)", maxLength: 5, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_sea_shipment_value = table.Column<decimal>(type: "decimal(10)", precision: 10, nullable: true),
                    tbl_sea_shipment_description = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_sea_shipment_FTA = table.Column<sbyte>(type: "tinyint(4)", nullable: true),
                    tbl_sea_shipment_COO = table.Column<sbyte>(type: "tinyint(4)", nullable: true),
                    tbl_sea_shipment_senderRef = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_sea_shipment_coloaderCode = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_sea_shipment_latestTracking = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_sea_shipment_timestamp = table.Column<DateTime>(type: "datetime", nullable: true),
                    tbl_sea_shipment_status = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_sea_shipment_service = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_sea_shipment_notes = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_sea_shipment_type = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_sea_shipment_deliverydate = table.Column<DateTime>(type: "datetime", nullable: true),
                    tbl_sea_shipment_clearancedate = table.Column<DateTime>(type: "datetime", nullable: true),
                    tbl_sea_shipment_tailLiftO = table.Column<sbyte>(type: "tinyint(4)", nullable: true),
                    tbl_sea_shipment_tailLiftD = table.Column<sbyte>(type: "tinyint(4)", nullable: true),
                    tbl_sea_shipment_DG = table.Column<sbyte>(type: "tinyint(4)", nullable: true),
                    tbl_sea_shipment_UN = table.Column<decimal>(type: "decimal(10)", precision: 10, nullable: true),
                    tbl_sea_shipment_packaging = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_sea_shipment_class = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_sea_shipment_currency = table.Column<string>(type: "varchar(5)", maxLength: 5, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_sea_shipment_senderName = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_sea_shipment_senderAddress1 = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_sea_shipment_senderAddress2 = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_sea_shipment_senderEmail = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_sea_shipment_senderPhone = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_sea_shipment_senderBusiness = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_sea_shipment_senderSuburb = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_sea_shipment_senderCity = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_sea_shipment_senderPostcode = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_sea_shipment_senderState = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_sea_shipment_senderCountry = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_sea_shipment_receiverBusiness = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_sea_shipment_receiverName = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_sea_shipment_receiverAddress1 = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_sea_shipment_receiverAddress2 = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_sea_shipment_receiverEmail = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_sea_shipment_receiverPhone = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_sea_shipment_receiverSuburb = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_sea_shipment_receiverPostcode = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_sea_shipment_receiverCity = table.Column<string>(type: "varchar(25)", maxLength: 25, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_sea_shipment_receiverState = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_sea_shipment_receiverCountry = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.tbl_sea_shipment_id);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_general_ci");

            migrationBuilder.CreateTable(
                name: "tbl_services",
                columns: table => new
                {
                    tbl_services_id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    tbl_services_name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_services_code = table.Column<string>(type: "varchar(22)", maxLength: 22, nullable: false, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_services_carrierId = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: false, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_services_active = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    tbl_services_carrierAccount = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_services_carrierCode = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_services_prefixCode = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.tbl_services_id);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_general_ci");

            migrationBuilder.CreateTable(
                name: "tbl_shippers",
                columns: table => new
                {
                    tbl_shippers_id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    tbl_shippers_name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_shippers_code = table.Column<string>(type: "varchar(7)", maxLength: 7, nullable: false, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_shippers_active = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    tbl_shippers_creation_date = table.Column<DateTime>(type: "date", nullable: false),
                    tbl_shippers_country = table.Column<string>(type: "longtext", nullable: false, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_shipperscol = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_shippers_prefix = table.Column<string>(type: "varchar(3)", maxLength: 3, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_air_prefix = table.Column<string>(type: "varchar(3)", maxLength: 3, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.tbl_shippers_id);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_general_ci");

            migrationBuilder.CreateTable(
                name: "tbl_shippers_air_ref",
                columns: table => new
                {
                    idtbl_shippers_air_ref = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    tbl_shippers_air_createDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    tbl_shippers_air_shipmentId = table.Column<int>(type: "int(11)", nullable: true),
                    tbl_shippers_air_prefix = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_shippers_air_batch_id = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.idtbl_shippers_air_ref);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_general_ci");

            migrationBuilder.CreateTable(
                name: "tbl_shippers_tracking_ref",
                columns: table => new
                {
                    idshippers_tracking_ref = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    tbl_shippers_tracking_createDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    tbl_shippers_tracking_shipmentId = table.Column<int>(type: "int(11)", nullable: true),
                    tbl_shippers_tracking_prefix = table.Column<string>(type: "varchar(3)", maxLength: 3, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_shippers_tracking_batch_id = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_shippers_tracking_est_cost = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.idshippers_tracking_ref);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_general_ci");

            migrationBuilder.CreateTable(
                name: "tbl_tickets",
                columns: table => new
                {
                    tbl_tickets_id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    tbl_tickets_owner = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_tickets_timestamp = table.Column<DateTime>(type: "datetime", nullable: true),
                    tbl_tickets_status = table.Column<string>(type: "varchar(25)", maxLength: 25, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_tickets_type = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_tickets_comments = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_tickets_priority = table.Column<int>(type: "int(11)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.tbl_tickets_id);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_general_ci");

            migrationBuilder.CreateTable(
                name: "tbl_tracking_3pl",
                columns: table => new
                {
                    tbl_tracking_id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    tbl_tracking_createDate = table.Column<DateTime>(type: "datetime(6)", maxLength: 6, nullable: false),
                    tbl_tracking_shipmentID = table.Column<int>(type: "int(11)", nullable: false),
                    tbl_tracking_prefix = table.Column<string>(type: "longtext", nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.tbl_tracking_id);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_general_ci");

            migrationBuilder.CreateTable(
                name: "tbl_tracking_amazon",
                columns: table => new
                {
                    tbl_tracking_id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    tbl_tracking_createDate = table.Column<DateTime>(type: "datetime(6)", maxLength: 6, nullable: false),
                    tbl_tracking_shipmentID = table.Column<int>(type: "int(11)", nullable: false),
                    tbl_tracking_prefix = table.Column<string>(type: "longtext", nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.tbl_tracking_id);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_general_ci");

            migrationBuilder.CreateTable(
                name: "tbl_tracking_austway",
                columns: table => new
                {
                    tbl_tracking_id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    tbl_tracking_createDate = table.Column<DateTime>(type: "datetime(6)", maxLength: 6, nullable: false),
                    tbl_tracking_shipmentID = table.Column<int>(type: "int(11)", nullable: false),
                    tbl_tracking_prefix = table.Column<string>(type: "longtext", nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.tbl_tracking_id);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_general_ci");

            migrationBuilder.CreateTable(
                name: "tbl_tracking_border",
                columns: table => new
                {
                    tbl_tracking_id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    tbl_tracking_createDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    tbl_tracking_shipmentID = table.Column<int>(type: "int(5)", nullable: true),
                    tbl_tracking_prefix = table.Column<string>(type: "varchar(5)", maxLength: 5, nullable: true, defaultValueSql: "'VCN'", collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.tbl_tracking_id);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_general_ci");

            migrationBuilder.CreateTable(
                name: "tbl_tracking_nz",
                columns: table => new
                {
                    tbl_tracking_id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    tbl_tracking_createDate = table.Column<DateTime>(type: "datetime(6)", maxLength: 6, nullable: false),
                    tbl_tracking_shipmentID = table.Column<int>(type: "int(11)", nullable: false),
                    tbl_tracking_prefix = table.Column<string>(type: "longtext", nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.tbl_tracking_id);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_general_ci");

            migrationBuilder.CreateTable(
                name: "tbl_tracking_tnt",
                columns: table => new
                {
                    tbl_tracking_tnt_id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    tbl_tracking_tnt_createDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    tbl_tracking_tnt_shipmentID = table.Column<int>(type: "int(5)", nullable: true),
                    tbl_tracking_tnt_prefix = table.Column<string>(type: "varchar(5)", maxLength: 5, nullable: true, defaultValueSql: "'VCN'", collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.tbl_tracking_tnt_id);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_general_ci");

            migrationBuilder.CreateTable(
                name: "tbl_voyage",
                columns: table => new
                {
                    idtbl_voyage = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    tbl_voyage_code = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_voyage_type = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_voyage_status = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_voyage_vesselNumber = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_voyage_number = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_voyage_carrierCode = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_voyage_loadPort = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_voyage_dischargePort = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_voyage_destinationPort = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_voyage_etd = table.Column<DateTime>(type: "datetime(6)", maxLength: 6, nullable: false),
                    tbl_voyage_eta = table.Column<DateTime>(type: "datetime(6)", maxLength: 6, nullable: false),
                    tbl_voyage_etaDischarge = table.Column<DateTime>(type: "datetime(6)", maxLength: 6, nullable: true),
                    tbl_voyage_atd = table.Column<DateTime>(type: "datetime(6)", maxLength: 6, nullable: false),
                    tbl_voyage_ata = table.Column<DateTime>(type: "datetime(6)", maxLength: 6, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.idtbl_voyage);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_general_ci");

            migrationBuilder.CreateTable(
                name: "tbl_client_header",
                columns: table => new
                {
                    idtbl_client_header = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    tbl_client_header_code = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_client_header_active = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    tbl_client_header_is_agent = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    tbl_client_header_is_consignee = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    tbl_client_header_is_consignor = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    tbl_client_header_is_broker = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    tbl_client_header_is_carrier = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    tbl_client_header_is_payable = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    tbl_client_header_is_receivable = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    tbl_client_header_createdBy = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_client_header_createdDate = table.Column<DateTime>(type: "datetime(6)", maxLength: 6, nullable: false),
                    tbl_client_header_companyName = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_client_header_contactName = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_client_header_email = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_client_header_phone = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_client_header_closestPort = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_client_header_abn = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_delivery_address_id = table.Column<int>(type: "int(11)", nullable: true),
                    DeliveryAddressCode = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_billing_address_id = table.Column<int>(type: "int(11)", nullable: true),
                    BillingAddressCode = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_pickup_address_id = table.Column<int>(type: "int(11)", nullable: true),
                    PickupAddressCode = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.idtbl_client_header);
                    table.ForeignKey(
                        name: "FK_tbl_client_header_tbl_address_tbl_address_billing_address_id",
                        column: x => x.tbl_billing_address_id,
                        principalTable: "tbl_address",
                        principalColumn: "idtbl_address",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tbl_client_header_tbl_address_tbl_address_delivery_address_id",
                        column: x => x.tbl_delivery_address_id,
                        principalTable: "tbl_address",
                        principalColumn: "idtbl_address",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tbl_client_header_tbl_address_tbl_address_id",
                        column: x => x.tbl_pickup_address_id,
                        principalTable: "tbl_address",
                        principalColumn: "idtbl_address",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_general_ci");

            migrationBuilder.CreateTable(
                name: "tbl_routing",
                columns: table => new
                {
                    idtbl_routing = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    tbl_routing_cutoffDate = table.Column<DateTime>(type: "datetime(6)", maxLength: 6, nullable: false),
                    tbl_voyage_loadPort = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_voyage_dischargePort = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_voyage_etd = table.Column<DateTime>(type: "datetime(6)", maxLength: 6, nullable: false),
                    tbl_voyage_eta = table.Column<DateTime>(type: "datetime(6)", maxLength: 6, nullable: false),
                    tbl_voyage_atd = table.Column<DateTime>(type: "datetime(6)", maxLength: 6, nullable: false),
                    tbl_voyage_ata = table.Column<DateTime>(type: "datetime(6)", maxLength: 6, nullable: false),
                    tbl_voyage_id = table.Column<int>(type: "int(11)", nullable: true),
                    VoyageNumber = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.idtbl_routing);
                    table.ForeignKey(
                        name: "FK_tbl_routing_tbl_voyage_tbl_voyage_id",
                        column: x => x.tbl_voyage_id,
                        principalTable: "tbl_voyage",
                        principalColumn: "idtbl_voyage",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_general_ci");

            migrationBuilder.CreateTable(
                name: "tbl_client_contact_details",
                columns: table => new
                {
                    idtbl_client_contact_detail = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    tbl_client_contact_details_code = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_client_contact_details_isActive = table.Column<bool>(type: "tinyint(1)", nullable: true, defaultValueSql: "'0'"),
                    tbl_client_contact_details_type = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_client_contact_details_companyName = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_client_contact_details_contactName = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_client_contact_details_phone = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_client_contact_details_email = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_client_header_id = table.Column<int>(type: "int(11)", nullable: true),
                    ClientHeaderCode = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_address_id = table.Column<int>(type: "int(11)", nullable: true),
                    AddressCode = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.idtbl_client_contact_detail);
                    table.ForeignKey(
                        name: "FK_tbl_client_contact_details_tbl_address_tbl_address_id",
                        column: x => x.tbl_address_id,
                        principalTable: "tbl_address",
                        principalColumn: "idtbl_address",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tbl_client_contact_details_tlb_client_header",
                        column: x => x.tbl_client_header_id,
                        principalTable: "tbl_client_header",
                        principalColumn: "idtbl_client_header",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_general_ci");

            migrationBuilder.CreateTable(
                name: "tbl_master",
                columns: table => new
                {
                    idtbl_master = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    tbl_master_code = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_master_bookingNumber = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_master_billNumber = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_master_status = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_master_type = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_master_transportType = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_master_containerMode = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_master_createdDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    tbl_client_header_origin_id = table.Column<int>(type: "int(11)", nullable: true),
                    originAgentCode = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_client_header_destination_id = table.Column<int>(type: "int(11)", nullable: true),
                    destinationAgentCode = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_client_header_carrier_id = table.Column<int>(type: "int(11)", nullable: true),
                    carrierAgentCode = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_client_header_creditor_id = table.Column<int>(type: "int(11)", nullable: true),
                    creditorAgentCode = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_voyage_id = table.Column<int>(type: "int(11)", nullable: true),
                    VoyageCode = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.idtbl_master);
                    table.ForeignKey(
                        name: "FK_tbl_master_tbl_client_header_tbl_client_header_carrier_id",
                        column: x => x.tbl_client_header_carrier_id,
                        principalTable: "tbl_client_header",
                        principalColumn: "idtbl_client_header",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tbl_master_tbl_client_header_tbl_client_header_creditor_id",
                        column: x => x.tbl_client_header_creditor_id,
                        principalTable: "tbl_client_header",
                        principalColumn: "idtbl_client_header",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tbl_master_tbl_client_header_tbl_client_header_destination_id",
                        column: x => x.tbl_client_header_destination_id,
                        principalTable: "tbl_client_header",
                        principalColumn: "idtbl_client_header",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tbl_master_tbl_client_header_tbl_client_header_origin_id",
                        column: x => x.tbl_client_header_origin_id,
                        principalTable: "tbl_client_header",
                        principalColumn: "idtbl_client_header",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tbl_master_tbl_voyage_tbl_voyage_id",
                        column: x => x.tbl_voyage_id,
                        principalTable: "tbl_voyage",
                        principalColumn: "idtbl_voyage",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_general_ci");

            migrationBuilder.CreateTable(
                name: "tbl_client_contact_detailtbl_client_contact_group",
                columns: table => new
                {
                    contactDetailsidtbl_client_contact_detail = table.Column<int>(type: "int(11)", nullable: false),
                    contactGroupsidtbl_client_contact_group = table.Column<int>(type: "int(11)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_client_contact_detailtbl_client_contact_group", x => new { x.contactDetailsidtbl_client_contact_detail, x.contactGroupsidtbl_client_contact_group });
                    table.ForeignKey(
                        name: "FK_tbl_client_contact_detailtbl_client_contact_group_tbl_clien~1",
                        column: x => x.contactGroupsidtbl_client_contact_group,
                        principalTable: "tbl_client_contact_group",
                        principalColumn: "idtbl_client_contact_group",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tbl_client_contact_detailtbl_client_contact_group_tbl_client~",
                        column: x => x.contactDetailsidtbl_client_contact_detail,
                        principalTable: "tbl_client_contact_details",
                        principalColumn: "idtbl_client_contact_detail",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_general_ci");

            migrationBuilder.CreateTable(
                name: "tbl_container",
                columns: table => new
                {
                    idtbl_container = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    tbl_container_code = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_container_status = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_container_number = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_container_isoType = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_container_cargoType = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_container_sealNumber = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_container_qty = table.Column<int>(type: "int(11)", nullable: false),
                    tbl_container_grossWeight = table.Column<decimal>(type: "decimal(12,3)", precision: 12, scale: 3, nullable: false),
                    tbl_container_createdDate = table.Column<DateTime>(type: "datetime(6)", maxLength: 6, nullable: false),
                    tbl_container_sealedBy = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_master_id = table.Column<int>(type: "int(11)", nullable: true),
                    MasterCode = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.idtbl_container);
                    table.ForeignKey(
                        name: "FK_tbl_container_tbl_master_tbl_master_id",
                        column: x => x.tbl_master_id,
                        principalTable: "tbl_master",
                        principalColumn: "idtbl_master",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_general_ci");

            migrationBuilder.CreateTable(
                name: "tbl_house",
                columns: table => new
                {
                    idtbl_house = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    tbl_house_code = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_house_billNumber = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_house_type = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_house_status = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_house_delivery = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_house_incotermCode = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_house_airJobReference = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_house_qty = table.Column<int>(type: "int(11)", nullable: false),
                    tbl_house_weight = table.Column<decimal>(type: "decimal(12,3)", precision: 12, scale: 3, nullable: false),
                    tbl_house_weightUnit = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_house_length = table.Column<decimal>(type: "decimal(12,3)", precision: 12, scale: 3, nullable: false),
                    tbl_house_width = table.Column<decimal>(type: "decimal(12,3)", precision: 12, scale: 3, nullable: false),
                    tbl_house_height = table.Column<decimal>(type: "decimal(12,3)", precision: 12, scale: 3, nullable: false),
                    tbl_house_volume = table.Column<decimal>(type: "decimal(12,3)", precision: 12, scale: 3, nullable: false),
                    tbl_house_volumeUnit = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_house_originAirport = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_house_destinationAirport = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_house_value = table.Column<decimal>(type: "decimal(12,2)", precision: 12, scale: 2, nullable: false),
                    tbl_house_description = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_house_native_description = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_house_FTA = table.Column<byte>(type: "tinyint(3) unsigned", nullable: false),
                    tbl_house_shipperCode = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_house_coloaderCode = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_house_serviceCode = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_house_latestTracking = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_house_createdDate = table.Column<DateTime>(type: "datetime(6)", maxLength: 6, nullable: false),
                    tbl_house_deliveryDate = table.Column<DateTime>(type: "datetime(6)", maxLength: 6, nullable: false),
                    tbl_house_deliveryInstructions = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_house_clearanceDate = table.Column<DateTime>(type: "datetime(6)", maxLength: 6, nullable: true),
                    tbl_house_coo = table.Column<byte>(type: "tinyint(3) unsigned", nullable: false),
                    tbl_house_tailLiftO = table.Column<byte>(type: "tinyint(3) unsigned", nullable: false),
                    tbl_house_tailLiftD = table.Column<byte>(type: "tinyint(3) unsigned", nullable: false),
                    tbl_house_DG = table.Column<byte>(type: "tinyint(3) unsigned", nullable: false),
                    tbl_house_UN = table.Column<string>(type: "longtext", nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_house_packaging = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_house_class = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_house_currency = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_master_id = table.Column<int>(type: "int(11)", nullable: true),
                    MasterCode = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_container_id = table.Column<int>(type: "int(11)", nullable: true),
                    ContainerCode = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_consignee_id = table.Column<int>(type: "int(11)", nullable: true),
                    ConsigneeCode = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_consignor_id = table.Column<int>(type: "int(11)", nullable: true),
                    ConsignorCode = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_incoterms_id = table.Column<int>(type: "int(11)", nullable: true),
                    IncotermsCode = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.idtbl_house);
                    table.ForeignKey(
                        name: "FK_tbl_house_tbl_client_header_tbl_consignee_id",
                        column: x => x.tbl_consignee_id,
                        principalTable: "tbl_client_header",
                        principalColumn: "idtbl_client_header",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tbl_house_tbl_client_header_tbl_consignor_id",
                        column: x => x.tbl_consignor_id,
                        principalTable: "tbl_client_header",
                        principalColumn: "idtbl_client_header",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tbl_house_tbl_container_tbl_container_id",
                        column: x => x.tbl_container_id,
                        principalTable: "tbl_container",
                        principalColumn: "idtbl_container",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tbl_house_tbl_incoterms_tbl_incoterms_id",
                        column: x => x.tbl_incoterms_id,
                        principalTable: "tbl_incoterms",
                        principalColumn: "idtbl_incoterm",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tbl_house_tbl_master_tbl_master_id",
                        column: x => x.tbl_master_id,
                        principalTable: "tbl_master",
                        principalColumn: "idtbl_master",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_general_ci");

            migrationBuilder.CreateTable(
                name: "tbl_house_items",
                columns: table => new
                {
                    idtbl_house_item = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    tbl_house_item_code = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_house_item_type = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_house_item_qty = table.Column<int>(type: "int(11)", nullable: false),
                    tbl_house_item_weight = table.Column<decimal>(type: "decimal(12,3)", precision: 12, scale: 3, nullable: false),
                    tbl_house_item_weightUnit = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_house_item_length = table.Column<decimal>(type: "decimal(12,3)", precision: 12, scale: 3, nullable: false),
                    tbl_house_item_width = table.Column<decimal>(type: "decimal(12,3)", precision: 12, scale: 3, nullable: false),
                    tbl_house_item_height = table.Column<decimal>(type: "decimal(12,3)", precision: 12, scale: 3, nullable: false),
                    tbl_house_item_volumeUnit = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_house_item_dg = table.Column<byte>(type: "tinyint(3) unsigned", nullable: false),
                    tbl_house_item_description = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_house_id = table.Column<int>(type: "int(11)", nullable: true),
                    HouseCode = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.idtbl_house_item);
                    table.ForeignKey(
                        name: "FK_tbl_house_items_tbl_house_tbl_house_id",
                        column: x => x.tbl_house_id,
                        principalTable: "tbl_house",
                        principalColumn: "idtbl_house",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_general_ci");

            migrationBuilder.CreateTable(
                name: "tbl_receptacle",
                columns: table => new
                {
                    idtbl_receptacle = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    tbl_receptacle_code = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_receptacle_shipper_code = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_receptacle_mode = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_receptacle_type = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_receptacle_qty = table.Column<int>(type: "int(11)", nullable: false),
                    tbl_receptacle_weight = table.Column<decimal>(type: "decimal(12,3)", precision: 12, scale: 3, nullable: false),
                    tbl_receptacle_status = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_receptacle_origin = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_receptacle_destination = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_receptacle_createdDate = table.Column<DateTime>(type: "datetime(6)", maxLength: 6, nullable: false),
                    tbl_receptacle_length = table.Column<decimal>(type: "decimal(12,3)", precision: 12, scale: 3, nullable: false),
                    tbl_receptacle_width = table.Column<decimal>(type: "decimal(12,3)", precision: 12, scale: 3, nullable: false),
                    tbl_receptacle_height = table.Column<decimal>(type: "decimal(12,3)", precision: 12, scale: 3, nullable: false),
                    tbl_house_id = table.Column<int>(type: "int(11)", nullable: true),
                    HouseCode = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.idtbl_receptacle);
                    table.ForeignKey(
                        name: "FK_tbl_receptacle_tbl_house_tbl_house_id",
                        column: x => x.tbl_house_id,
                        principalTable: "tbl_house",
                        principalColumn: "idtbl_house",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_general_ci");

            migrationBuilder.CreateTable(
                name: "tbl_house_itemtbl_item_sku",
                columns: table => new
                {
                    houseItemsidtbl_house_item = table.Column<int>(type: "int(11)", nullable: false),
                    itemSkusidtbl_item_sku = table.Column<int>(type: "int(11)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_house_itemtbl_item_sku", x => new { x.houseItemsidtbl_house_item, x.itemSkusidtbl_item_sku });
                    table.ForeignKey(
                        name: "FK_tbl_house_itemtbl_item_sku_tbl_house_items_houseItemsidtbl_h~",
                        column: x => x.houseItemsidtbl_house_item,
                        principalTable: "tbl_house_items",
                        principalColumn: "idtbl_house_item",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tbl_house_itemtbl_item_sku_tbl_item_sku_itemSkusidtbl_item_s~",
                        column: x => x.itemSkusidtbl_item_sku,
                        principalTable: "tbl_item_sku",
                        principalColumn: "idtbl_item_sku",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_general_ci");

            migrationBuilder.CreateTable(
                name: "tbl_shipment",
                columns: table => new
                {
                    idtbl_shipment = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    tbl_shipment_code = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_shipment_status = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_shipment_batchCode = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_shipment_shipperCode = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_shipment_trackingNo = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_shipment_referenceNo = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_shipment_description = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_shipment_nativeDescription = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_shipment_facility = table.Column<string>(type: "text", nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_shipment_instruction = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_shipment_invoiceCurrency = table.Column<string>(type: "varchar(3)", maxLength: 3, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_shipment_invoiceValue = table.Column<decimal>(type: "decimal(11,2)", precision: 11, scale: 2, nullable: true),
                    tbl_shipment_phone = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_shipment_platform = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_shipment_serviceCode = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_shipment_serviceOption = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_shipment_authorityToLeave = table.Column<bool>(type: "tinyint(1)", nullable: true, defaultValueSql: "'0'"),
                    tbl_shipment_incoterm = table.Column<string>(type: "varchar(5)", maxLength: 5, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_shipment_shipmentItems = table.Column<string>(type: "text", nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_shipment_vendorId = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_shipment_gstExemptionCode = table.Column<bool>(type: "tinyint(1)", nullable: true, defaultValueSql: "'0'"),
                    tbl_shipment_abnNumber = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_shipment_sortCode = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_shipment_coverAmount = table.Column<decimal>(type: "decimal(11,2)", precision: 11, scale: 2, nullable: true),
                    tbl_shipment_orderItems = table.Column<string>(type: "text", nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_shipment_hasLockerService = table.Column<bool>(type: "tinyint(1)", nullable: true, defaultValueSql: "'0'"),
                    tbl_shipment_warehouse = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_shipment_createdDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    tbl_shipment_readyDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    tbl_shipment_dg = table.Column<bool>(type: "tinyint(1)", nullable: true, defaultValueSql: "'0'"),
                    tbl_shipment_dgClass = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_shipment_dgUn = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_shipment_dgPackaging = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_shipment_tailLiftO = table.Column<bool>(type: "tinyint(1)", nullable: true, defaultValueSql: "'0'"),
                    tbl_shipment_tailLiftD = table.Column<bool>(type: "tinyint(1)", nullable: true, defaultValueSql: "'0'"),
                    tbl_shipment_deliveryName = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_shipment_deliveryPhone = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_shipment_deliveryEmail = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_shipment_deliveryContact = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_shipment_deliveryContactPhone = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_shipment_deliveryContactEmail = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_shipment_deliveryCompany = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_shipment_deliveryAddressLine1 = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_shipment_deliveryAddressLine2 = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_shipment_deliveryAddressLine3 = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_shipment_deliverySuburb = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_shipment_deliveryCity = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_shipment_deliveryState = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_shipment_deliveryPostcode = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_shipment_deliveryCountry = table.Column<string>(type: "varchar(2)", maxLength: 2, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_shipment_deliveryInstructions = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_shipment_deliveryDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    tbl_shipment_shipperName = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_shipment_shipperPhone = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_shipment_shipperEmail = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_shipment_shipperContact = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_shipment_shipperCompany = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_shipment_shipperAddressLine1 = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_shipment_shipperAddressLine2 = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_shipment_shipperAddressLine3 = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_shipment_shipperCity = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_shipment_shipperSuburb = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_shipment_shipperState = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_shipment_shipperPostcode = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_shipment_shipperCountry = table.Column<string>(type: "varchar(2)", maxLength: 2, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_shipment_shipperInstructions = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_shipment_returnName = table.Column<string>(type: "text", nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_shipment_returnAddress1 = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_shipment_returnAddress2 = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_shipment_returnAddress3 = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_shipment_returnCity = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_shipment_returnState = table.Column<string>(type: "varchar(3)", maxLength: 3, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_shipment_returnPostcode = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_shipment_returnCountry = table.Column<string>(type: "varchar(2)", maxLength: 2, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_shipment_returnOption = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_receptable_id = table.Column<int>(type: "int(11)", nullable: true),
                    ReceptacleCode = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_incoterms_id = table.Column<int>(type: "int(11)", nullable: true),
                    IncotermsCode = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.idtbl_shipment);
                    table.ForeignKey(
                        name: "FK_tbl_shipment_tbl_incoterms_tbl_incoterms_id",
                        column: x => x.tbl_incoterms_id,
                        principalTable: "tbl_incoterms",
                        principalColumn: "idtbl_incoterm",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tbl_shipment_tbl_receptacle_tbl_receptacle_id",
                        column: x => x.tbl_receptable_id,
                        principalTable: "tbl_receptacle",
                        principalColumn: "idtbl_receptacle",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_general_ci");

            migrationBuilder.CreateTable(
                name: "tbl_documents",
                columns: table => new
                {
                    idtbl_document = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    document = table.Column<string>(type: "longtext", nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    status = table.Column<string>(type: "longtext", nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    date_added = table.Column<DateTime>(type: "datetime(6)", maxLength: 6, nullable: false),
                    added_by = table.Column<string>(type: "longtext", nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    master_reference = table.Column<int>(type: "int(11)", nullable: false),
                    house_reference = table.Column<int>(type: "int(11)", nullable: false),
                    shipment_reference = table.Column<int>(type: "int(11)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.idtbl_document);
                    table.ForeignKey(
                        name: "document_house_link",
                        column: x => x.house_reference,
                        principalTable: "tbl_house",
                        principalColumn: "idtbl_house",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "document_master_link",
                        column: x => x.master_reference,
                        principalTable: "tbl_master",
                        principalColumn: "idtbl_master",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "document_shipment_link",
                        column: x => x.shipment_reference,
                        principalTable: "tbl_shipment",
                        principalColumn: "idtbl_shipment",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_general_ci");

            migrationBuilder.CreateTable(
                name: "tbl_shipment_items",
                columns: table => new
                {
                    idtbl_shipment_item = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    tbl_shipment_item_code = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_shipment_item_weight = table.Column<decimal>(type: "decimal(12,3)", precision: 12, scale: 3, nullable: true),
                    tbl_shipment_item_weightUnit = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_shipment_item_length = table.Column<decimal>(type: "decimal(12,3)", precision: 12, scale: 3, nullable: true),
                    tbl_shipment_item_width = table.Column<decimal>(type: "decimal(12,3)", precision: 12, scale: 3, nullable: true),
                    tbl_shipment_item_height = table.Column<decimal>(type: "decimal(12,3)", precision: 12, scale: 3, nullable: true),
                    tbl_shipment_item_volumeUnit = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_shipment_item_dangerousGoods = table.Column<sbyte>(type: "tinyint(4)", nullable: true),
                    tbl_shipment_item_description = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_shipment_item_type = table.Column<string>(type: "varchar(5)", maxLength: 5, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_shipment_item_qty = table.Column<int>(type: "int(3)", nullable: true),
                    tbl_shipment_id = table.Column<int>(type: "int(11)", nullable: true),
                    ShipmentCode = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.idtbl_shipment_item);
                    table.ForeignKey(
                        name: "FK_tbl_shipment_item_tbl_shipment_tbl_shipment_id",
                        column: x => x.tbl_shipment_id,
                        principalTable: "tbl_shipment",
                        principalColumn: "idtbl_shipment",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_general_ci");

            migrationBuilder.CreateTable(
                name: "tbl_shipping_billing",
                columns: table => new
                {
                    idtbl_shipping_billing = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    tbl_shipping_billing_orderId = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_shipping_billing_referenceNo = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_shipping_billing_trackingNo = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_shipping_billing_shippingCost = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: true),
                    tbl_shipping_billing_dateAdded = table.Column<DateTime>(type: "datetime(6)", maxLength: 6, nullable: true),
                    tbl_shipping_billing_status = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tbl_shipment_id = table.Column<int>(type: "int(11)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.idtbl_shipping_billing);
                    table.ForeignKey(
                        name: "FK_tbl_shipping_billing_tbl_shipment_tbl_shipment_id",
                        column: x => x.tbl_shipment_id,
                        principalTable: "tbl_shipment",
                        principalColumn: "idtbl_shipment",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_general_ci");

            migrationBuilder.CreateTable(
                name: "tbl_item_skutbl_shipment_item",
                columns: table => new
                {
                    itemSkusidtbl_item_sku = table.Column<int>(type: "int(11)", nullable: false),
                    shipmentItemsidtbl_shipment_item = table.Column<int>(type: "int(11)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_item_skutbl_shipment_item", x => new { x.itemSkusidtbl_item_sku, x.shipmentItemsidtbl_shipment_item });
                    table.ForeignKey(
                        name: "FK_tbl_item_skutbl_shipment_item_tbl_item_sku_itemSkusidtbl_ite~",
                        column: x => x.itemSkusidtbl_item_sku,
                        principalTable: "tbl_item_sku",
                        principalColumn: "idtbl_item_sku",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tbl_item_skutbl_shipment_item_tbl_shipment_items_shipmentIte~",
                        column: x => x.shipmentItemsidtbl_shipment_item,
                        principalTable: "tbl_shipment_items",
                        principalColumn: "idtbl_shipment_item",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_general_ci");

            migrationBuilder.CreateIndex(
                name: "FK_tbl_client_contact_details_tbl_address_tbl_address_id_idx",
                table: "tbl_client_contact_details",
                column: "tbl_address_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_client_contact_details_tbl_client_header_id",
                table: "tbl_client_contact_details",
                column: "tbl_client_header_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_client_contact_detailtbl_client_contact_group_contactGro~",
                table: "tbl_client_contact_detailtbl_client_contact_group",
                column: "contactGroupsidtbl_client_contact_group");

            migrationBuilder.CreateIndex(
                name: "FK_tbl_client_header_tbl_address_tbl_address_billing_addres_idx",
                table: "tbl_client_header",
                column: "tbl_billing_address_id");

            migrationBuilder.CreateIndex(
                name: "FK_tbl_client_header_tbl_address_tbl_address_delivery_addre_idx",
                table: "tbl_client_header",
                column: "tbl_delivery_address_id");

            migrationBuilder.CreateIndex(
                name: "FK_tbl_client_header_tbl_address_tbl_address_id_idx",
                table: "tbl_client_header",
                column: "tbl_pickup_address_id");

            migrationBuilder.CreateIndex(
                name: "FK_tbl_container_tbl_master_tbl_master_id_idx",
                table: "tbl_container",
                column: "tbl_master_id");

            migrationBuilder.CreateIndex(
                name: "idx_document_house_link_idx",
                table: "tbl_documents",
                column: "house_reference");

            migrationBuilder.CreateIndex(
                name: "idx_document_master_link_idx",
                table: "tbl_documents",
                column: "master_reference");

            migrationBuilder.CreateIndex(
                name: "idx_document_shipment_link_idx",
                table: "tbl_documents",
                column: "shipment_reference");

            migrationBuilder.CreateIndex(
                name: "idtbl_dynamic_filters_UNIQUE",
                table: "tbl_dynamic_filters",
                column: "idtbl_dynamic_filters",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "FK_tbl_house_tbl_client_header_tbl_consignee_id_idx",
                table: "tbl_house",
                column: "tbl_consignee_id");

            migrationBuilder.CreateIndex(
                name: "FK_tbl_house_tbl_client_header_tbl_consignor_id_idx",
                table: "tbl_house",
                column: "tbl_consignor_id");

            migrationBuilder.CreateIndex(
                name: "FK_tbl_house_tbl_incoterms_tbl_incoterms_id_idx",
                table: "tbl_house",
                column: "tbl_incoterms_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_hawb_tbl_container_id",
                table: "tbl_house",
                column: "tbl_container_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_hawb_tbl_master_id",
                table: "tbl_house",
                column: "tbl_master_id");

            migrationBuilder.CreateIndex(
                name: "FK_tbl_house_items_tbl_house_tbl_house_id_idx",
                table: "tbl_house_items",
                column: "tbl_house_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_house_itemtbl_item_sku_itemSkusidtbl_item_sku",
                table: "tbl_house_itemtbl_item_sku",
                column: "itemSkusidtbl_item_sku");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_item_skutbl_shipment_item_shipmentItemsidtbl_shipment_it~",
                table: "tbl_item_skutbl_shipment_item",
                column: "shipmentItemsidtbl_shipment_item");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_master_tbl_client_header_carrier_id",
                table: "tbl_master",
                column: "tbl_client_header_carrier_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_master_tbl_client_header_creditor_id",
                table: "tbl_master",
                column: "tbl_client_header_creditor_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_master_tbl_client_header_destination_id",
                table: "tbl_master",
                column: "tbl_client_header_destination_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_master_tbl_client_header_origin_id",
                table: "tbl_master",
                column: "tbl_client_header_origin_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_master_tbl_voyage_id",
                table: "tbl_master",
                column: "tbl_voyage_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_receptacle_tbl_house_id",
                table: "tbl_receptacle",
                column: "tbl_house_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_routing_tbl_voyage_id",
                table: "tbl_routing",
                column: "tbl_voyage_id");

            migrationBuilder.CreateIndex(
                name: "FK_tbl_shipment_tbl_incoterms_tbl_incoterms_id_idx",
                table: "tbl_shipment",
                column: "tbl_incoterms_id");

            migrationBuilder.CreateIndex(
                name: "FK_tbl_shipment_tbl_receptacle_tbl_receptacle_id_idx",
                table: "tbl_shipment",
                column: "tbl_receptable_id");

            migrationBuilder.CreateIndex(
                name: "FK_tbl_shipmentl_items_tbl_shipment_tbl_shipment_id_idx",
                table: "tbl_shipment_items",
                column: "tbl_shipment_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_shipping_billing_tbl_shipment_id",
                table: "tbl_shipping_billing",
                column: "tbl_shipment_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbl_3pl_routings");

            migrationBuilder.DropTable(
                name: "tbl_amazon_routings");

            migrationBuilder.DropTable(
                name: "tbl_austway_routings");

            migrationBuilder.DropTable(
                name: "tbl_barcodes");

            migrationBuilder.DropTable(
                name: "tbl_border_routings");

            migrationBuilder.DropTable(
                name: "tbl_carrier_api_response");

            migrationBuilder.DropTable(
                name: "tbl_carrier_info");

            migrationBuilder.DropTable(
                name: "tbl_client_contact_detailtbl_client_contact_group");

            migrationBuilder.DropTable(
                name: "tbl_containerType");

            migrationBuilder.DropTable(
                name: "tbl_default_settings");

            migrationBuilder.DropTable(
                name: "tbl_documents");

            migrationBuilder.DropTable(
                name: "tbl_dynamic_filters");

            migrationBuilder.DropTable(
                name: "tbl_field_conditions");

            migrationBuilder.DropTable(
                name: "tbl_house_itemtbl_item_sku");

            migrationBuilder.DropTable(
                name: "tbl_hunterrates");

            migrationBuilder.DropTable(
                name: "tbl_hunterzones");

            migrationBuilder.DropTable(
                name: "tbl_item_skutbl_shipment_item");

            migrationBuilder.DropTable(
                name: "tbl_manifests");

            migrationBuilder.DropTable(
                name: "tbl_nz_routings");

            migrationBuilder.DropTable(
                name: "tbl_parcel_tracking");

            migrationBuilder.DropTable(
                name: "tbl_pluscourier");

            migrationBuilder.DropTable(
                name: "tbl_pluscourier_rate");

            migrationBuilder.DropTable(
                name: "tbl_returns");

            migrationBuilder.DropTable(
                name: "tbl_returns_sku");

            migrationBuilder.DropTable(
                name: "tbl_routing");

            migrationBuilder.DropTable(
                name: "tbl_sea_shipment");

            migrationBuilder.DropTable(
                name: "tbl_services");

            migrationBuilder.DropTable(
                name: "tbl_shippers");

            migrationBuilder.DropTable(
                name: "tbl_shippers_air_ref");

            migrationBuilder.DropTable(
                name: "tbl_shippers_tracking_ref");

            migrationBuilder.DropTable(
                name: "tbl_shipping_billing");

            migrationBuilder.DropTable(
                name: "tbl_tickets");

            migrationBuilder.DropTable(
                name: "tbl_tracking_3pl");

            migrationBuilder.DropTable(
                name: "tbl_tracking_amazon");

            migrationBuilder.DropTable(
                name: "tbl_tracking_austway");

            migrationBuilder.DropTable(
                name: "tbl_tracking_border");

            migrationBuilder.DropTable(
                name: "tbl_tracking_nz");

            migrationBuilder.DropTable(
                name: "tbl_tracking_tnt");

            migrationBuilder.DropTable(
                name: "tbl_client_contact_group");

            migrationBuilder.DropTable(
                name: "tbl_client_contact_details");

            migrationBuilder.DropTable(
                name: "tbl_house_items");

            migrationBuilder.DropTable(
                name: "tbl_item_sku");

            migrationBuilder.DropTable(
                name: "tbl_shipment_items");

            migrationBuilder.DropTable(
                name: "tbl_shipment");

            migrationBuilder.DropTable(
                name: "tbl_receptacle");

            migrationBuilder.DropTable(
                name: "tbl_house");

            migrationBuilder.DropTable(
                name: "tbl_container");

            migrationBuilder.DropTable(
                name: "tbl_incoterms");

            migrationBuilder.DropTable(
                name: "tbl_master");

            migrationBuilder.DropTable(
                name: "tbl_client_header");

            migrationBuilder.DropTable(
                name: "tbl_voyage");

            migrationBuilder.DropTable(
                name: "tbl_address");
        }
    }
}
