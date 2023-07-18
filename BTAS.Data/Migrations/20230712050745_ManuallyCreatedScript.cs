using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BTAS.Data.Migrations
{
    /// <inheritdoc />
    public partial class ManuallyCreatedScript : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            /*
            migrationBuilder.DropForeignKey(
                name: "FK_tbl_client_contact_details_tbl_address_tbl_address_id",
                table: "tbl_client_contact_details");

            migrationBuilder.DropForeignKey(
                name: "FK_tbl_client_header_tbl_address_tbl_address_billing_address_id",
                table: "tbl_client_header");

            migrationBuilder.DropForeignKey(
                name: "FK_tbl_client_header_tbl_address_tbl_address_delivery_address_id",
                table: "tbl_client_header");

            migrationBuilder.DropForeignKey(
                name: "FK_tbl_client_header_tbl_address_tbl_address_id",
                table: "tbl_client_header");

            migrationBuilder.DropForeignKey(
                name: "FK_tbl_house_tbl_incoterms_tbl_incoterms_id",
                table: "tbl_house");

            migrationBuilder.DropForeignKey(
                name: "FK_tbl_shipment_tbl_incoterms_tbl_incoterms_id",
                table: "tbl_shipment");

            migrationBuilder.DropIndex(
                name: "FK_tbl_client_header_tbl_address_tbl_address_billing_addres_idx",
                table: "tbl_client_header");

            migrationBuilder.DropIndex(
                name: "FK_tbl_client_header_tbl_address_tbl_address_delivery_addre_idx",
                table: "tbl_client_header");

            migrationBuilder.DropIndex(
                name: "FK_tbl_client_header_tbl_address_tbl_address_id_idx",
                table: "tbl_client_header");

            migrationBuilder.DropIndex(
                name: "FK_tbl_client_contact_details_tbl_address_tbl_address_id_idx",
                table: "tbl_client_contact_details");

            migrationBuilder.DropColumn(
                name: "BillingAddressCode",
                table: "tbl_client_header");

            migrationBuilder.DropColumn(
                name: "DeliveryAddressCode",
                table: "tbl_client_header");

            migrationBuilder.DropColumn(
                name: "PickupAddressCode",
                table: "tbl_client_header");

            migrationBuilder.DropColumn(
                name: "tbl_billing_address_id",
                table: "tbl_client_header");

            migrationBuilder.DropColumn(
                name: "tbl_delivery_address_id",
                table: "tbl_client_header");

            migrationBuilder.DropColumn(
                name: "tbl_pickup_address_id",
                table: "tbl_client_header");

            migrationBuilder.DropColumn(
                name: "AddressCode",
                table: "tbl_client_contact_details");

            migrationBuilder.DropColumn(
                name: "tbl_address_id",
                table: "tbl_client_contact_details");

            migrationBuilder.RenameTable(
                name: "tbl_note_categories",
                newName: "tbl_note_category");

            migrationBuilder.RenameTable(
                name: "tbl_incoterms",
                newName: "tbl_incoterm");

            migrationBuilder.RenameColumn(
                name: "tbl_incoterms_id",
                table: "tbl_house",
                newName: "tbl_pickupClient_id");

            migrationBuilder.RenameColumn(
                name: "IncotermsCode",
                table: "tbl_house",
                newName: "PickupClientCode");

            migrationBuilder.RenameIndex(
                name: "FK_tbl_house_tbl_incoterms_tbl_incoterms_id_idx",
                table: "tbl_house",
                newName: "IX_tbl_house_tbl_client_header_tbl_pickClient_id");

            migrationBuilder.RenameColumn(
                name: "tbl_client_header_is_receivable",
                table: "tbl_client_header",
                newName: "tbl_client_header_isWarehouse");

            migrationBuilder.RenameColumn(
                name: "tbl_client_header_is_payable",
                table: "tbl_client_header",
                newName: "tbl_client_header_isReceivable");

            migrationBuilder.RenameColumn(
                name: "tbl_client_header_is_consignor",
                table: "tbl_client_header",
                newName: "tbl_client_header_isPayable");

            migrationBuilder.RenameColumn(
                name: "tbl_client_header_is_consignee",
                table: "tbl_client_header",
                newName: "tbl_client_header_isConsignor");

            migrationBuilder.RenameColumn(
                name: "tbl_client_header_is_carrier",
                table: "tbl_client_header",
                newName: "tbl_client_header_isConsignee");

            migrationBuilder.RenameColumn(
                name: "tbl_client_header_is_broker",
                table: "tbl_client_header",
                newName: "tbl_client_header_isCarrier");

            migrationBuilder.RenameColumn(
                name: "tbl_client_header_is_agent",
                table: "tbl_client_header",
                newName: "tbl_client_header_isBroker");

            migrationBuilder.RenameIndex(
                name: "IX_tbl_client_contact_details_tbl_client_header_id",
                table: "tbl_client_contact_details",
                newName: "IX_tbl_client_contact_detail_tbl_client_header_id");

            migrationBuilder.RenameColumn(
                name: "tbl_address_type",
                table: "tbl_address",
                newName: "tbl_address_description");

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
                name: "tbl_house_incotermCode",
                table: "tbl_house",
                type: "longtext",
                nullable: true,
                collation: "utf8mb4_general_ci",
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldMaxLength: 50,
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("Relational:Collation", "utf8mb4_general_ci");

            migrationBuilder.AlterColumn<byte>(
                name: "tbl_house_coo",
                table: "tbl_house",
                type: "tinyint(1) unsigned",
                nullable: true,
                oldClrType: typeof(byte),
                oldType: "tinyint(3) unsigned",
                oldNullable: true);

            migrationBuilder.AlterColumn<byte>(
                name: "tbl_house_FTA",
                table: "tbl_house",
                type: "tinyint(1) unsigned",
                nullable: true,
                oldClrType: typeof(byte),
                oldType: "tinyint(3) unsigned",
                oldNullable: true);

            migrationBuilder.AlterColumn<byte>(
                name: "tbl_house_DG",
                table: "tbl_house",
                type: "tinyint(1) unsigned",
                nullable: true,
                oldClrType: typeof(byte),
                oldType: "tinyint(3) unsigned",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeliveryClientCode",
                table: "tbl_house",
                type: "varchar(50)",
                maxLength: 50,
                nullable: true,
                collation: "utf8mb4_general_ci")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "IncotermCode",
                table: "tbl_house",
                type: "varchar(50)",
                maxLength: 50,
                nullable: true,
                collation: "utf8mb4_general_ci")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "tbl_deliveryClient_id",
                table: "tbl_house",
                type: "int(11)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "tbl_incoterm_id",
                table: "tbl_house",
                type: "int(11)",
                nullable: true);

            migrationBuilder.AlterColumn<byte>(
                name: "tbl_doucument_internalAccess",
                table: "tbl_documents",
                type: "tinyint(1) unsigned",
                nullable: true,
                oldClrType: typeof(byte),
                oldType: "tinyint(3) unsigned",
                oldNullable: true);

            migrationBuilder.AlterColumn<byte>(
                name: "tbl_doucument_externalAccess",
                table: "tbl_documents",
                type: "tinyint(1) unsigned",
                nullable: true,
                oldClrType: typeof(byte),
                oldType: "tinyint(3) unsigned",
                oldNullable: true);

            migrationBuilder.AlterColumn<byte>(
                name: "tbl_document_status",
                table: "tbl_documents",
                type: "tinyint(1) unsigned",
                nullable: true,
                oldClrType: typeof(byte),
                oldType: "tinyint(3) unsigned",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "tbl_client_header",
                keyColumn: "tbl_client_header_code",
                keyValue: null,
                column: "tbl_client_header_code",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "tbl_client_header_code",
                table: "tbl_client_header",
                type: "varchar(50)",
                maxLength: 50,
                nullable: false,
                collation: "utf8mb4_general_ci",
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldMaxLength: 50,
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("Relational:Collation", "utf8mb4_general_ci");

            migrationBuilder.AddColumn<string>(
                name: "tbl_client_header_address1",
                table: "tbl_client_header",
                type: "varchar(255)",
                nullable: true,
                collation: "utf8mb4_general_ci")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "tbl_client_header_address2",
                table: "tbl_client_header",
                type: "longtext",
                nullable: true,
                collation: "utf8mb4_general_ci")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "tbl_client_header_city",
                table: "tbl_client_header",
                type: "longtext",
                nullable: true,
                collation: "utf8mb4_general_ci")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "tbl_client_header_country",
                table: "tbl_client_header",
                type: "longtext",
                nullable: true,
                collation: "utf8mb4_general_ci")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<bool>(
                name: "tbl_client_header_isAgent",
                table: "tbl_client_header",
                type: "tinyint(1)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "tbl_client_header_postcode",
                table: "tbl_client_header",
                type: "varchar(255)",
                nullable: true,
                collation: "utf8mb4_general_ci")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "tbl_client_header_state",
                table: "tbl_client_header",
                type: "longtext",
                nullable: true,
                collation: "utf8mb4_general_ci")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "tbl_client_header_suburb",
                table: "tbl_client_header",
                type: "longtext",
                nullable: true,
                collation: "utf8mb4_general_ci")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "tbl_client_contact_details",
                keyColumn: "tbl_client_contact_details_code",
                keyValue: null,
                column: "tbl_client_contact_details_code",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "tbl_client_contact_details_code",
                table: "tbl_client_contact_details",
                type: "varchar(50)",
                maxLength: 50,
                nullable: false,
                collation: "utf8mb4_general_ci",
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldMaxLength: 50,
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("Relational:Collation", "utf8mb4_general_ci");

            migrationBuilder.UpdateData(
                table: "tbl_address",
                keyColumn: "tbl_address_code",
                keyValue: null,
                column: "tbl_address_code",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "tbl_address_code",
                table: "tbl_address",
                type: "varchar(50)",
                maxLength: 50,
                nullable: false,
                collation: "utf8mb4_general_ci",
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldMaxLength: 50,
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("Relational:Collation", "utf8mb4_general_ci");

            migrationBuilder.AddColumn<string>(
                name: "ClientContactDetailCode",
                table: "tbl_address",
                type: "varchar(50)",
                nullable: true,
                collation: "utf8mb4_general_ci")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "ClientHeaderCode",
                table: "tbl_address",
                type: "varchar(50)",
                maxLength: 50,
                nullable: true,
                collation: "utf8mb4_general_ci")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<byte>(
                name: "tbl_address_commercial",
                table: "tbl_address",
                type: "tinyint(1) unsigned",
                nullable: true);

            migrationBuilder.AddColumn<byte>(
                name: "tbl_address_crane",
                table: "tbl_address",
                type: "tinyint(1) unsigned",
                nullable: true);

            migrationBuilder.AddColumn<byte>(
                name: "tbl_address_customerUnloading",
                table: "tbl_address",
                type: "tinyint(1) unsigned",
                nullable: true);

            migrationBuilder.AddColumn<TimeOnly>(
                name: "tbl_address_endTime",
                table: "tbl_address",
                type: "time",
                nullable: true);

            migrationBuilder.AddColumn<byte>(
                name: "tbl_address_forkLift",
                table: "tbl_address",
                type: "tinyint(1) unsigned",
                nullable: true);

            migrationBuilder.AddColumn<byte>(
                name: "tbl_address_handUnloading",
                table: "tbl_address",
                type: "tinyint(1) unsigned",
                nullable: true);

            migrationBuilder.AddColumn<byte>(
                name: "tbl_address_isBilling",
                table: "tbl_address",
                type: "tinyint(1) unsigned",
                nullable: true);

            migrationBuilder.AddColumn<byte>(
                name: "tbl_address_isDelivery",
                table: "tbl_address",
                type: "tinyint(1) unsigned",
                nullable: true);

            migrationBuilder.AddColumn<byte>(
                name: "tbl_address_isLegalEntity",
                table: "tbl_address",
                type: "tinyint(1) unsigned",
                nullable: true);

            migrationBuilder.AddColumn<byte>(
                name: "tbl_address_isPickup",
                table: "tbl_address",
                type: "tinyint(1) unsigned",
                nullable: true);

            migrationBuilder.AddColumn<TimeOnly>(
                name: "tbl_address_startTime",
                table: "tbl_address",
                type: "time",
                nullable: true);

            migrationBuilder.AddColumn<byte>(
                name: "tbl_address_tailLift",
                table: "tbl_address",
                type: "tinyint(1) unsigned",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "tbl_client_contact_detail_id",
                table: "tbl_address",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "tbl_client_header_id",
                table: "tbl_address",
                type: "int(11)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "tbl_note_category_status",
                table: "tbl_note_category",
                type: "tinyint(1)",
                nullable: true);
*/
            //migrationBuilder.AddUniqueConstraint(
            //    name: "AK_tbl_client_header_tbl_client_header_code",
            //    table: "tbl_client_header",
            //    column: "tbl_client_header_code");

            //migrationBuilder.AddUniqueConstraint(
            //    name: "AK_tbl_client_contact_details_tbl_client_contact_details_code",
            //    table: "tbl_client_contact_details",
            //    column: "tbl_client_contact_details_code");

            //migrationBuilder.AddUniqueConstraint(
            //    name: "AK_tbl_address_tbl_address_code",
            //    table: "tbl_address",
            //    column: "tbl_address_code");

            //migrationBuilder.CreateIndex(
            //    name: "FK_tbl_house_tbl_incoterm_tbl_incoterm_id_idx",
            //    table: "tbl_house",
            //    column: "tbl_incoterm_id");

            //migrationBuilder.CreateIndex(
            //    name: "IX_tbl_house_tbl_client_header_tbl_deliveryClient_id",
            //    table: "tbl_house",
            //    column: "tbl_deliveryClient_id");

            //migrationBuilder.CreateIndex(
            //    name: "IX_tbl_client_header_tbl_client_header_code",
            //    table: "tbl_client_header",
            //    column: "tbl_client_header_code",
            //    unique: true);

            //migrationBuilder.CreateIndex(
            //    name: "IX_tbl_client_header_tbl_client_header_companyName_tbl_client_h~",
            //    table: "tbl_client_header",
            //    columns: new[] { "tbl_client_header_companyName", "tbl_client_header_address1", "tbl_client_header_postcode" });

            //migrationBuilder.CreateIndex(
            //    name: "IX_tbl_address_ClientContactDetailCode",
            //    table: "tbl_address",
            //    column: "ClientContactDetailCode",
            //    unique: true);

            //migrationBuilder.CreateIndex(
            //    name: "IX_tbl_address_tbl_client_header_id",
            //    table: "tbl_address",
            //    column: "tbl_client_header_id",
            //    unique: true);
            
            migrationBuilder.AddForeignKey(
                name: "FK_address_client_contact_detail_id~",
                table: "tbl_address",
                column: "tbl_client_contact_detail_id",
                principalTable: "tbl_client_contact_details",
                principalColumn: "idtbl_client_contact_detail");
            
            migrationBuilder.AddForeignKey(
                name: "FK_address_client_header_id",
                table: "tbl_address",
                column: "tbl_client_header_id",
                principalTable: "tbl_client_header",
                principalColumn: "idtbl_client_header");
            
            //migrationBuilder.AddForeignKey(
            //    name: "FK_tbl_house_tbl_client_contact_detail_tbl_deliveryClient_id",
            //    table: "tbl_house",
            //    column: "tbl_deliveryClient_id",
            //    principalTable: "tbl_client_contact_details",
            //    principalColumn: "idtbl_client_contact_detail");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_tbl_house_tbl_client_contact_detail_tbl_pickupClient_id",
            //    table: "tbl_house",
            //    column: "tbl_pickupClient_id",
            //    principalTable: "tbl_client_contact_details",
            //    principalColumn: "idtbl_client_contact_detail");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_tbl_house_tbl_incoterms_tbl_incoterm_id",
            //    table: "tbl_house",
            //    column: "tbl_incoterm_id",
            //    principalTable: "tbl_incoterm",
            //    principalColumn: "idtbl_incoterm");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_tbl_shipment_tbl_incoterm_tbl_incoterms_id",
            //    table: "tbl_shipment",
            //    column: "tbl_incoterms_id",
            //    principalTable: "tbl_incoterm",
            //    principalColumn: "idtbl_incoterm");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbl_address_tbl_client_contact_details_ClientContactDetailCo~",
                table: "tbl_address");

            migrationBuilder.DropForeignKey(
                name: "fk_tbl_address_tlb_client_header_id",
                table: "tbl_address");

            migrationBuilder.DropForeignKey(
                name: "FK_tbl_house_tbl_client_contact_detail_tbl_deliveryClient_id",
                table: "tbl_house");

            migrationBuilder.DropForeignKey(
                name: "FK_tbl_house_tbl_client_contact_detail_tbl_pickupClient_id",
                table: "tbl_house");

            migrationBuilder.DropForeignKey(
                name: "FK_tbl_house_tbl_incoterms_tbl_incoterm_id",
                table: "tbl_house");

            migrationBuilder.DropForeignKey(
                name: "FK_tbl_shipment_tbl_incoterm_tbl_incoterms_id",
                table: "tbl_shipment");

            migrationBuilder.DropIndex(
                name: "FK_tbl_house_tbl_incoterm_tbl_incoterm_id_idx",
                table: "tbl_house");

            migrationBuilder.DropIndex(
                name: "IX_tbl_house_tbl_client_header_tbl_deliveryClient_id",
                table: "tbl_house");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_tbl_client_header_tbl_client_header_code",
                table: "tbl_client_header");

            migrationBuilder.DropIndex(
                name: "IX_tbl_client_header_tbl_client_header_code",
                table: "tbl_client_header");

            migrationBuilder.DropIndex(
                name: "IX_tbl_client_header_tbl_client_header_companyName_tbl_client_h~",
                table: "tbl_client_header");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_tbl_client_contact_details_tbl_client_contact_details_code",
                table: "tbl_client_contact_details");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_tbl_address_tbl_address_code",
                table: "tbl_address");

            migrationBuilder.DropIndex(
                name: "IX_tbl_address_ClientContactDetailCode",
                table: "tbl_address");

            migrationBuilder.DropIndex(
                name: "IX_tbl_address_tbl_client_header_id",
                table: "tbl_address");

            migrationBuilder.DropColumn(
                name: "DeliveryClientCode",
                table: "tbl_house");

            migrationBuilder.DropColumn(
                name: "IncotermCode",
                table: "tbl_house");

            migrationBuilder.DropColumn(
                name: "tbl_deliveryClient_id",
                table: "tbl_house");

            migrationBuilder.DropColumn(
                name: "tbl_incoterm_id",
                table: "tbl_house");

            migrationBuilder.DropColumn(
                name: "tbl_client_header_address1",
                table: "tbl_client_header");

            migrationBuilder.DropColumn(
                name: "tbl_client_header_address2",
                table: "tbl_client_header");

            migrationBuilder.DropColumn(
                name: "tbl_client_header_city",
                table: "tbl_client_header");

            migrationBuilder.DropColumn(
                name: "tbl_client_header_country",
                table: "tbl_client_header");

            migrationBuilder.DropColumn(
                name: "tbl_client_header_isAgent",
                table: "tbl_client_header");

            migrationBuilder.DropColumn(
                name: "tbl_client_header_postcode",
                table: "tbl_client_header");

            migrationBuilder.DropColumn(
                name: "tbl_client_header_state",
                table: "tbl_client_header");

            migrationBuilder.DropColumn(
                name: "tbl_client_header_suburb",
                table: "tbl_client_header");

            migrationBuilder.DropColumn(
                name: "ClientContactDetailCode",
                table: "tbl_address");

            migrationBuilder.DropColumn(
                name: "ClientHeaderCode",
                table: "tbl_address");

            migrationBuilder.DropColumn(
                name: "tbl_address_commercial",
                table: "tbl_address");

            migrationBuilder.DropColumn(
                name: "tbl_address_crane",
                table: "tbl_address");

            migrationBuilder.DropColumn(
                name: "tbl_address_customerUnloading",
                table: "tbl_address");

            migrationBuilder.DropColumn(
                name: "tbl_address_endTime",
                table: "tbl_address");

            migrationBuilder.DropColumn(
                name: "tbl_address_forkLift",
                table: "tbl_address");

            migrationBuilder.DropColumn(
                name: "tbl_address_handUnloading",
                table: "tbl_address");

            migrationBuilder.DropColumn(
                name: "tbl_address_isBilling",
                table: "tbl_address");

            migrationBuilder.DropColumn(
                name: "tbl_address_isDelivery",
                table: "tbl_address");

            migrationBuilder.DropColumn(
                name: "tbl_address_isLegalEntity",
                table: "tbl_address");

            migrationBuilder.DropColumn(
                name: "tbl_address_isPickup",
                table: "tbl_address");

            migrationBuilder.DropColumn(
                name: "tbl_address_startTime",
                table: "tbl_address");

            migrationBuilder.DropColumn(
                name: "tbl_address_tailLift",
                table: "tbl_address");

            migrationBuilder.DropColumn(
                name: "tbl_client_contact_detail_id",
                table: "tbl_address");

            migrationBuilder.DropColumn(
                name: "tbl_client_header_id",
                table: "tbl_address");

            migrationBuilder.DropColumn(
                name: "tbl_note_category_status",
                table: "tbl_note_category");

            migrationBuilder.RenameTable(
                name: "tbl_note_category",
                newName: "tbl_note_categories");

            migrationBuilder.RenameTable(
                name: "tbl_incoterm",
                newName: "tbl_incoterms");

            migrationBuilder.RenameColumn(
                name: "tbl_pickupClient_id",
                table: "tbl_house",
                newName: "tbl_incoterms_id");

            migrationBuilder.RenameColumn(
                name: "PickupClientCode",
                table: "tbl_house",
                newName: "IncotermsCode");

            migrationBuilder.RenameIndex(
                name: "IX_tbl_house_tbl_client_header_tbl_pickClient_id",
                table: "tbl_house",
                newName: "FK_tbl_house_tbl_incoterms_tbl_incoterms_id_idx");

            migrationBuilder.RenameColumn(
                name: "tbl_client_header_isWarehouse",
                table: "tbl_client_header",
                newName: "tbl_client_header_is_receivable");

            migrationBuilder.RenameColumn(
                name: "tbl_client_header_isReceivable",
                table: "tbl_client_header",
                newName: "tbl_client_header_is_payable");

            migrationBuilder.RenameColumn(
                name: "tbl_client_header_isPayable",
                table: "tbl_client_header",
                newName: "tbl_client_header_is_consignor");

            migrationBuilder.RenameColumn(
                name: "tbl_client_header_isConsignor",
                table: "tbl_client_header",
                newName: "tbl_client_header_is_consignee");

            migrationBuilder.RenameColumn(
                name: "tbl_client_header_isConsignee",
                table: "tbl_client_header",
                newName: "tbl_client_header_is_carrier");

            migrationBuilder.RenameColumn(
                name: "tbl_client_header_isCarrier",
                table: "tbl_client_header",
                newName: "tbl_client_header_is_broker");

            migrationBuilder.RenameColumn(
                name: "tbl_client_header_isBroker",
                table: "tbl_client_header",
                newName: "tbl_client_header_is_agent");

            migrationBuilder.RenameIndex(
                name: "IX_tbl_client_contact_detail_tbl_client_header_id",
                table: "tbl_client_contact_details",
                newName: "IX_tbl_client_contact_details_tbl_client_header_id");

            migrationBuilder.RenameColumn(
                name: "tbl_address_description",
                table: "tbl_address",
                newName: "tbl_address_type");

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
                name: "tbl_house_incotermCode",
                table: "tbl_house",
                type: "varchar(50)",
                maxLength: 50,
                nullable: true,
                collation: "utf8mb4_general_ci",
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("Relational:Collation", "utf8mb4_general_ci");

            migrationBuilder.AlterColumn<byte>(
                name: "tbl_house_coo",
                table: "tbl_house",
                type: "tinyint(3) unsigned",
                nullable: true,
                oldClrType: typeof(byte),
                oldType: "tinyint(1) unsigned",
                oldNullable: true);

            migrationBuilder.AlterColumn<byte>(
                name: "tbl_house_FTA",
                table: "tbl_house",
                type: "tinyint(3) unsigned",
                nullable: true,
                oldClrType: typeof(byte),
                oldType: "tinyint(1) unsigned",
                oldNullable: true);

            migrationBuilder.AlterColumn<byte>(
                name: "tbl_house_DG",
                table: "tbl_house",
                type: "tinyint(3) unsigned",
                nullable: true,
                oldClrType: typeof(byte),
                oldType: "tinyint(1) unsigned",
                oldNullable: true);

            migrationBuilder.AlterColumn<byte>(
                name: "tbl_doucument_internalAccess",
                table: "tbl_documents",
                type: "tinyint(3) unsigned",
                nullable: true,
                oldClrType: typeof(byte),
                oldType: "tinyint(1) unsigned",
                oldNullable: true);

            migrationBuilder.AlterColumn<byte>(
                name: "tbl_doucument_externalAccess",
                table: "tbl_documents",
                type: "tinyint(3) unsigned",
                nullable: true,
                oldClrType: typeof(byte),
                oldType: "tinyint(1) unsigned",
                oldNullable: true);

            migrationBuilder.AlterColumn<byte>(
                name: "tbl_document_status",
                table: "tbl_documents",
                type: "tinyint(3) unsigned",
                nullable: true,
                oldClrType: typeof(byte),
                oldType: "tinyint(1) unsigned",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "tbl_client_header_code",
                table: "tbl_client_header",
                type: "varchar(50)",
                maxLength: 50,
                nullable: true,
                collation: "utf8mb4_general_ci",
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldMaxLength: 50)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("Relational:Collation", "utf8mb4_general_ci");

            migrationBuilder.AddColumn<string>(
                name: "BillingAddressCode",
                table: "tbl_client_header",
                type: "varchar(50)",
                maxLength: 50,
                nullable: true,
                collation: "utf8mb4_general_ci")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "DeliveryAddressCode",
                table: "tbl_client_header",
                type: "varchar(50)",
                maxLength: 50,
                nullable: true,
                collation: "utf8mb4_general_ci")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "PickupAddressCode",
                table: "tbl_client_header",
                type: "varchar(50)",
                maxLength: 50,
                nullable: true,
                collation: "utf8mb4_general_ci")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "tbl_billing_address_id",
                table: "tbl_client_header",
                type: "int(11)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "tbl_delivery_address_id",
                table: "tbl_client_header",
                type: "int(11)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "tbl_pickup_address_id",
                table: "tbl_client_header",
                type: "int(11)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "tbl_client_contact_details_code",
                table: "tbl_client_contact_details",
                type: "varchar(50)",
                maxLength: 50,
                nullable: true,
                collation: "utf8mb4_general_ci",
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldMaxLength: 50)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("Relational:Collation", "utf8mb4_general_ci");

            migrationBuilder.AddColumn<string>(
                name: "AddressCode",
                table: "tbl_client_contact_details",
                type: "varchar(50)",
                maxLength: 50,
                nullable: true,
                collation: "utf8mb4_general_ci")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "tbl_address_id",
                table: "tbl_client_contact_details",
                type: "int(11)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "tbl_address_code",
                table: "tbl_address",
                type: "varchar(50)",
                maxLength: 50,
                nullable: true,
                collation: "utf8mb4_general_ci",
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldMaxLength: 50)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("Relational:Collation", "utf8mb4_general_ci");

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
                name: "FK_tbl_client_contact_details_tbl_address_tbl_address_id_idx",
                table: "tbl_client_contact_details",
                column: "tbl_address_id");

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_client_contact_details_tbl_address_tbl_address_id",
                table: "tbl_client_contact_details",
                column: "tbl_address_id",
                principalTable: "tbl_address",
                principalColumn: "idtbl_address");

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_client_header_tbl_address_tbl_address_billing_address_id",
                table: "tbl_client_header",
                column: "tbl_billing_address_id",
                principalTable: "tbl_address",
                principalColumn: "idtbl_address");

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_client_header_tbl_address_tbl_address_delivery_address_id",
                table: "tbl_client_header",
                column: "tbl_delivery_address_id",
                principalTable: "tbl_address",
                principalColumn: "idtbl_address");

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_client_header_tbl_address_tbl_address_id",
                table: "tbl_client_header",
                column: "tbl_pickup_address_id",
                principalTable: "tbl_address",
                principalColumn: "idtbl_address");

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_house_tbl_incoterms_tbl_incoterms_id",
                table: "tbl_house",
                column: "tbl_incoterms_id",
                principalTable: "tbl_incoterms",
                principalColumn: "idtbl_incoterm");

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_shipment_tbl_incoterms_tbl_incoterms_id",
                table: "tbl_shipment",
                column: "tbl_incoterms_id",
                principalTable: "tbl_incoterms",
                principalColumn: "idtbl_incoterm");
        }
    }
}
