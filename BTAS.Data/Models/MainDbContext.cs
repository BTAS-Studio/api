using Microsoft.EntityFrameworkCore;
using System;
#nullable disable

namespace BTAS.Data.Models
{
    public partial class MainDbContext : DbContext
    {
        public MainDbContext()
        {
        }

        public MainDbContext(DbContextOptions<MainDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<tbl_3pl_routing> tbl_3pl_routings { get; set; }
        public virtual DbSet<tbl_address> tbl_addresses { get; set; }
        public virtual DbSet<tbl_amazon_routing> tbl_amazon_routings { get; set; }
        public virtual DbSet<tbl_austway_routing> tbl_austway_routings { get; set; }
        public virtual DbSet<tbl_barcode> tbl_barcodes { get; set; }
        public virtual DbSet<tbl_border_routing> tbl_border_routings { get; set; }
        public virtual DbSet<tbl_carrier_api_response> tbl_carrier_api_responses { get; set; }
        public virtual DbSet<tbl_carrier_info> tbl_carrier_infos { get; set; }
        public virtual DbSet<tbl_client_contact_detail> tbl_client_contact_details { get; set; }
        public virtual DbSet<tbl_client_contact_group> tbl_client_contact_groups { get; set; }
        public virtual DbSet<tbl_client_header> tbl_client_headers { get; set; }
        public virtual DbSet<tbl_container> tbl_containers { get; set; }
        public virtual DbSet<tbl_containerType> tbl_containerTypes { get; set; }
        public virtual DbSet<tbl_default_setting> tbl_default_settings { get; set; }
        public virtual DbSet<tbl_document> tbl_documents { get; set; }
        public virtual DbSet<tbl_dynamic_filter> tbl_dynamic_filters { get; set; }
        public virtual DbSet<tbl_field_condition> tbl_field_conditions { get; set; }
        public virtual DbSet<tbl_house> tbl_houses { get; set; }
        public virtual DbSet<tbl_house_item> tbl_house_items { get; set; }
        public virtual DbSet<tbl_hunterrate> tbl_hunterrates { get; set; }
        public virtual DbSet<tbl_hunterzone> tbl_hunterzones { get; set; }
        public virtual DbSet<tbl_incoterm> tbl_incoterms { get; set; }
        public virtual DbSet<tbl_item_sku> tbl_item_skus { get; set; }
        public virtual DbSet<tbl_manifest> tbl_manifests { get; set; }
        public virtual DbSet<tbl_master> tbl_masters { get; set; }
        public virtual DbSet<tbl_milestone_header> tbl_milestone_headers { get; set; }
        public virtual DbSet<tbl_milestone_link> tbl_milestone_links { get; set; }
        public virtual DbSet<tbl_note_category> tbl_note_categories { get; set; }
        public virtual DbSet<tbl_note> tbl_notes { get; set; }
        public virtual DbSet<tbl_nz_routing> tbl_nz_routings { get; set; }
        public virtual DbSet<tbl_parcel_tracking> tbl_parcel_trackings { get; set; }
        public virtual DbSet<tbl_pluscourier> tbl_pluscouriers { get; set; }
        public virtual DbSet<tbl_pluscourier_rate> tbl_pluscourier_rates { get; set; }
        public virtual DbSet<tbl_receptacle> tbl_receptacles { get; set; }
        public virtual DbSet<tbl_return> tbl_returns { get; set; }
        public virtual DbSet<tbl_returns_sku> tbl_returns_skus { get; set; }
        public virtual DbSet<tbl_routing> tbl_routings { get; set; }
        public virtual DbSet<tbl_sea_shipment> tbl_sea_shipments { get; set; }
        public virtual DbSet<tbl_service> tbl_services { get; set; }
        public virtual DbSet<tbl_shipment> tbl_shipments { get; set; }
        public virtual DbSet<tbl_shipment_item> tbl_shipment_items { get; set; }
        public virtual DbSet<tbl_shipper> tbl_shippers { get; set; }
        public virtual DbSet<tbl_shippers_air_ref> tbl_shippers_air_refs { get; set; }
        public virtual DbSet<tbl_shippers_tracking_ref> tbl_shippers_tracking_refs { get; set; }
        public virtual DbSet<tbl_shipping_billing> tbl_shipping_billings { get; set; }
        public virtual DbSet<tbl_ticket> tbl_tickets { get; set; }
        public virtual DbSet<tbl_tracking_3pl> tbl_tracking_3pls { get; set; }
        public virtual DbSet<tbl_tracking_amazon> tbl_tracking_amazons { get; set; }
        public virtual DbSet<tbl_tracking_austway> tbl_tracking_austways { get; set; }
        public virtual DbSet<tbl_tracking_border> tbl_tracking_borders { get; set; }
        public virtual DbSet<tbl_tracking_nz> tbl_tracking_nzs { get; set; }
        public virtual DbSet<tbl_tracking_tnt> tbl_tracking_tnts { get; set; }
        public virtual DbSet<tbl_voyage> tbl_voyages { get; set; }
        public virtual DbSet<tbl_xml_template> tbl_xml_template { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //optionsBuilder.UseMySql("server=api.austwayexpress.com;port=3306;database=db3kelolqhhvrr;user=uu7gangnepira;password=lygqjpgaf5zw", Microsoft.EntityFrameworkCore.ServerVersion.Parse("5.7.39-mysql"));//dev
                optionsBuilder.UseMySql("server=api.austwayexpress.com;port=3306;database=dbas5njhyhtcvu;user=uu7gangnepira;password=lygqjpgaf5zw", ServerVersion.Parse("5.7.39-mysql"));//poststaging
                //ServerVersion.AutoDetect("server=api.austwayexpress.com;port=3306;database=dbmubv5jluex76;user=ucbm95jl7gxdr;password=%$-1#~%7113p;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_general_ci");

            modelBuilder.Entity<tbl_3pl_routing>(entity =>
            {
                entity.HasKey(e => e.tbl_routings_id)
                    .HasName("PRIMARY");

                entity.Property(e => e.tbl_routings_id).HasColumnType("int(11)");

                entity.Property(e => e.tbl_routings_code)
                    .IsRequired()
                    .HasMaxLength(3);

                entity.Property(e => e.tbl_routings_states)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.tbl_routings_suburbs)
                    .IsRequired()
                    .HasMaxLength(5);
            });

            modelBuilder.Entity<tbl_address>(entity =>
            {
                entity.HasKey(e => e.idtbl_address)
                    .HasName("PRIMARY");

                entity.ToTable("tbl_address");

                entity.HasIndex(e => e.tbl_client_header_id, "IX_tbl_address_tbl_client_header_id");

                entity.Property(e => e.idtbl_address).HasColumnType("int(11)");

                entity.Property(e => e.tbl_address_code).HasMaxLength(50);

                entity.Property(e => e.tbl_address_isLegalEntity).HasColumnType("tinyint(1) unsigned");

                entity.Property(e => e.tbl_address_isPickup).HasColumnType("tinyint(1) unsigned");

                entity.Property(e => e.tbl_address_isDelivery).HasColumnType("tinyint(1) unsigned");

                entity.Property(e => e.tbl_address_isBilling).HasColumnType("tinyint(1) unsigned");

                entity.Property(e => e.tbl_address_address1).HasMaxLength(150);

                entity.Property(e => e.tbl_address_address2).HasMaxLength(150);

                entity.Property(e => e.tbl_address_city).HasMaxLength(50);

                entity.Property(e => e.tbl_address_suburb).HasMaxLength(50);

                entity.Property(e => e.tbl_address_state).HasMaxLength(50);

                entity.Property(e => e.tbl_address_postcode).HasMaxLength(50);

                entity.Property(e => e.tbl_address_country).HasMaxLength(50);

                entity.Property(e => e.tbl_address_tailLift).HasColumnType("tinyint(1) unsigned");

                entity.Property(e => e.tbl_address_forkLift).HasColumnType("tinyint(1) unsigned");

                entity.Property(e => e.tbl_address_customerUnloading).HasColumnType("tinyint(1) unsigned");

                entity.Property(e => e.tbl_address_handUnloading).HasColumnType("tinyint(1) unsigned");

                entity.Property(e => e.tbl_address_crane).HasColumnType("tinyint(1) unsigned");

                entity.Property(e => e.tbl_address_commercial).HasColumnType("tinyint(1) unsigned");

                entity.Property(e => e.tbl_address_description).HasMaxLength(50);
                //??
                entity.Property(e => e.tbl_address_startTime).HasColumnType("time");

                entity.Property(e => e.tbl_address_endTime).HasColumnType("time");


                entity.Property(e => e.tbl_client_header_id).HasColumnType("int(11)");

                entity.Property(e => e.ClientHeaderCode).HasMaxLength(50);

                //entity.HasOne(d => d.clientHeader)
                //    .WithOne(p => p.legalEntityAddress)
                //    .HasForeignKey<tbl_address>(d => d.tbl_client_header_id)
                //    .HasConstraintName("FK_tbl_address_tlb_client_header");

                //entity.Property(e => e.tbl_address_type).HasMaxLength(50);
            });

            modelBuilder.Entity<tbl_amazon_routing>(entity =>
            {
                entity.HasKey(e => e.tbl_routings_id)
                    .HasName("PRIMARY");

                entity.Property(e => e.tbl_routings_id).HasColumnType("int(11)");

                entity.Property(e => e.tbl_routings_code)
                    .IsRequired()
                    .HasMaxLength(3);

                entity.Property(e => e.tbl_routings_states)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.tbl_routings_suburbs)
                    .IsRequired()
                    .HasMaxLength(5);
            });

            modelBuilder.Entity<tbl_austway_routing>(entity =>
            {
                entity.HasKey(e => e.tbl_routings_id)
                    .HasName("PRIMARY");

                entity.Property(e => e.tbl_routings_id).HasColumnType("int(11)");

                entity.Property(e => e.tbl_routings_code)
                    .IsRequired()
                    .HasMaxLength(3);

                entity.Property(e => e.tbl_routings_states)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.tbl_routings_suburbs)
                    .IsRequired()
                    .HasMaxLength(5);
            });

            modelBuilder.Entity<tbl_barcode>(entity =>
            {
                entity.HasKey(e => e.tbl_barcodes_id)
                    .HasName("PRIMARY");

                entity.Property(e => e.tbl_barcodes_id).HasColumnType("int(11)");

                entity.Property(e => e.tbl_barcodes_code).HasMaxLength(50);

                entity.Property(e => e.tbl_barcodes_manifest_link_id).HasColumnType("int(11)");

                entity.Property(e => e.tbl_barcodes_parcel_id).HasColumnType("int(11)");

                entity.Property(e => e.tbl_barcodes_sequence)
                    .IsRequired()
                    .HasMaxLength(3);

                entity.Property(e => e.tbl_barcodes_shipment_id).HasColumnType("int(11)");
            });

            modelBuilder.Entity<tbl_border_routing>(entity =>
            {
                entity.HasKey(e => e.tbl_routings_id)
                    .HasName("PRIMARY");

                entity.Property(e => e.tbl_routings_id).HasColumnType("int(11)");

                entity.Property(e => e.tbl_routings_code)
                    .IsRequired()
                    .HasMaxLength(3);

                entity.Property(e => e.tbl_routings_states)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.tbl_routings_suburbs)
                    .IsRequired()
                    .HasMaxLength(5);
            });

            modelBuilder.Entity<tbl_carrier_api_response>(entity =>
            {
                entity.HasKey(e => e.idtbl_carrier_api_response)
                    .HasName("PRIMARY");

                entity.ToTable("tbl_carrier_api_response");

                entity.Property(e => e.idtbl_carrier_api_response).HasColumnType("int(11)");

                entity.Property(e => e.tbl_carrier_api_manifestId).HasColumnType("int(11)");

                entity.Property(e => e.tbl_carrier_api_response_ind).HasColumnType("int(1)");

                entity.Property(e => e.tbl_carrier_api_response_parcelId).HasColumnType("int(11)");

                entity.Property(e => e.tbl_carrier_api_trackingRef).HasMaxLength(45);
            });

            modelBuilder.Entity<tbl_carrier_info>(entity =>
            {
                entity.HasKey(e => e.idtbl_carrier_info)
                    .HasName("PRIMARY");

                entity.ToTable("tbl_carrier_info");

                entity.Property(e => e.idtbl_carrier_info).HasColumnType("int(11)");

                entity.Property(e => e.tbl_carrier_active).HasColumnType("tinyint(4)");

                entity.Property(e => e.tbl_carrier_address1).HasMaxLength(60);

                entity.Property(e => e.tbl_carrier_address2).HasMaxLength(45);

                entity.Property(e => e.tbl_carrier_city).HasMaxLength(45);

                entity.Property(e => e.tbl_carrier_code)
                    .IsRequired()
                    .HasMaxLength(45);

                entity.Property(e => e.tbl_carrier_contactName).HasMaxLength(45);

                entity.Property(e => e.tbl_carrier_country_destination).HasMaxLength(3);

                entity.Property(e => e.tbl_carrier_country_origin).HasMaxLength(3);

                entity.Property(e => e.tbl_carrier_email).HasMaxLength(45);

                entity.Property(e => e.tbl_carrier_name).HasMaxLength(45);

                entity.Property(e => e.tbl_carrier_phone).HasMaxLength(45);

                entity.Property(e => e.tbl_carrier_postCode).HasMaxLength(15);

                entity.Property(e => e.tbl_carrier_state).HasMaxLength(3);

                entity.Property(e => e.tbl_carrier_suburb).HasMaxLength(45);

                entity.Property(e => e.tbl_carrier_type).HasMaxLength(45);
            });

            modelBuilder.Entity<tbl_client_contact_detail>(entity =>
            {
                entity.HasKey(e => e.idtbl_client_contact_detail)
                    .HasName("PRIMARY");

                entity.HasIndex(e => e.tbl_address_id, "FK_tbl_client_contact_details_tbl_address_tbl_address_id_idx");

                entity.HasIndex(e => e.tbl_client_header_id, "IX_tbl_client_contact_details_tbl_client_header_id");

                entity.Property(e => e.idtbl_client_contact_detail).HasColumnType("int(11)");

                entity.Property(e => e.AddressCode).HasMaxLength(50);

                entity.Property(e => e.ClientHeaderCode).HasMaxLength(50);

                entity.Property(e => e.tbl_address_id).HasColumnType("int(11)");

                entity.Property(e => e.tbl_client_contact_details_code).HasMaxLength(50);

                entity.Property(e => e.tbl_client_contact_details_companyName).HasMaxLength(50);

                entity.Property(e => e.tbl_client_contact_details_contactName).HasMaxLength(50);

                entity.Property(e => e.tbl_client_contact_details_email).HasMaxLength(50);

                entity.Property(e => e.tbl_client_contact_details_isActive).HasDefaultValueSql("'0'");

                entity.Property(e => e.tbl_client_contact_details_phone).HasMaxLength(50);

                entity.Property(e => e.tbl_client_contact_details_type).HasMaxLength(50);

                entity.Property(e => e.tbl_client_header_id).HasColumnType("int(11)");

                entity.HasOne(d => d.address)
                    .WithMany(p => p.contactDetails)
                    .HasForeignKey(d => d.tbl_address_id);

                entity.HasOne(d => d.clientHeader)
                    .WithMany(p => p.contactDetails)
                    .HasForeignKey(d => d.tbl_client_header_id)
                    .HasConstraintName("FK_tbl_client_contact_details_tlb_client_header");
            });

            modelBuilder.Entity<tbl_client_contact_group>(entity =>
            {
                entity.HasKey(e => e.idtbl_client_contact_group)
                    .HasName("PRIMARY");

                entity.ToTable("tbl_client_contact_group");

                entity.Property(e => e.idtbl_client_contact_group).HasColumnType("int(11)");

                entity.Property(e => e.tbl_client_contact_group_code).HasColumnType("int(11)");

                entity.Property(e => e.tbl_client_contact_group_isActive).HasColumnType("tinyint(3) unsigned");

                entity.Property(e => e.tbl_client_contact_group_isDefault).HasColumnType("tinyint(3) unsigned");
            });

            modelBuilder.Entity<tbl_client_header>(entity =>
            {
                entity.HasKey(e => e.idtbl_client_header)
                    .HasName("PRIMARY");

                entity.ToTable("tbl_client_header");

                entity.Property(e => e.idtbl_client_header).HasColumnType("int(11)");

                entity.Property(e => e.tbl_client_header_code).HasMaxLength(50);
                
                entity.Property(e => e.tbl_client_header_createdDate).HasMaxLength(6);

                entity.Property(e => e.tbl_client_header_createdBy).IsRequired().HasMaxLength(50);

                entity.Property(e => e.tbl_client_header_companyName).HasMaxLength(100);

                entity.Property(e => e.tbl_client_header_contactName).HasMaxLength(50);

                entity.Property(e => e.tbl_client_header_email).HasMaxLength(50);

                entity.Property(e => e.tbl_client_header_phone).HasMaxLength(50);

                entity.Property(e => e.tbl_client_header_abn).HasMaxLength(50);

                entity.Property(e => e.tbl_client_header_closestPort).HasMaxLength(50);

                entity.HasOne<tbl_address>(d => d.legalEntityAddress)
                    .WithOne(p => p.clientHeader)
                    .HasForeignKey<tbl_address>(d => d.tbl_client_header_id)
                    .HasConstraintName("fk_tbl_address_tlb_client_header");

            });

            modelBuilder.Entity<tbl_container>(entity =>
            {
                entity.HasKey(e => e.idtbl_container)
                    .HasName("PRIMARY");

                entity.ToTable("tbl_container");

                entity.HasIndex(e => e.tbl_master_id, "FK_tbl_container_tbl_master_tbl_master_id_idx");

                entity.Property(e => e.idtbl_container).HasColumnType("int(11)");

                entity.Property(e => e.MasterCode).HasMaxLength(30);

                entity.Property(e => e.tbl_container_cargoType).HasMaxLength(30);

                entity.Property(e => e.tbl_container_code).HasMaxLength(50);

                entity.Property(e => e.tbl_container_createdDate).HasMaxLength(6);

                entity.Property(e => e.tbl_container_grossWeight).HasPrecision(12, 3);

                entity.Property(e => e.tbl_container_isoType).HasMaxLength(30);

                entity.Property(e => e.tbl_container_number).HasMaxLength(30);

                entity.Property(e => e.tbl_container_qty).HasColumnType("int(11)");

                entity.Property(e => e.tbl_container_sealNumber).HasMaxLength(30);

                entity.Property(e => e.tbl_container_sealedBy).HasMaxLength(30);

                entity.Property(e => e.tbl_container_status).HasMaxLength(50);

                entity.Property(e => e.tbl_master_id).HasColumnType("int(11)");

                entity.HasOne(d => d.master)
                    .WithMany(p => p.containers)
                    .HasForeignKey(d => d.tbl_master_id);
            });

            modelBuilder.Entity<tbl_containerType>(entity =>
            {
                entity.HasKey(e => e.idtbl_containerType)
                    .HasName("PRIMARY");

                entity.ToTable("tbl_containerType");

                entity.Property(e => e.idtbl_containerType).HasColumnType("int(11)");
            });

            modelBuilder.Entity<tbl_default_setting>(entity =>
            {
                entity.HasKey(e => e.idtbl_default_settings)
                    .HasName("PRIMARY");

                entity.Property(e => e.idtbl_default_settings).HasColumnType("int(11)");

                entity.Property(e => e.AddedBy).HasMaxLength(30);

                entity.Property(e => e.DateAdded).HasMaxLength(6);

                entity.Property(e => e.tbl_address_type).HasMaxLength(30);

                entity.Property(e => e.tbl_contact_group_id).HasColumnType("int(11)");

                entity.Property(e => e.tbl_incoterm_id).HasColumnType("int(11)");
            });

            modelBuilder.Entity<tbl_document>(entity =>
            {
                entity.HasKey(e => e.idtbl_document)
                    .HasName("PRIMARY");

                entity.HasIndex(e => e.tbl_house_id, "idx_document_house_link_idx");
                entity.HasIndex(e => e.tbl_shipment_id, "idx_document_shipment_link_idx");
                entity.HasIndex(e => e.tbl_master_id, "idx_document_master_link_idx");
                entity.HasIndex(e => e.tbl_note_id, "idx_document_note_link_idx");

                entity.Property(e => e.idtbl_document).HasColumnType("int(11)");
                entity.Property(e => e.tbl_document_code).HasMaxLength(50);
                entity.Property(e => e.tbl_document_status).HasColumnType("tinyint(1) unsigned");
                entity.Property(e => e.tbl_document_createdDate).HasMaxLength(6);
                entity.Property(e => e.tbl_document_name).HasMaxLength(50);
                entity.Property(e => e.tbl_document_extension).HasMaxLength(50);
                entity.Property(e => e.tbl_document_group).HasMaxLength(50);
                entity.Property(e => e.tbl_document_description).HasMaxLength(150);
                entity.Property(e => e.tbl_doucument_internalAccess).HasColumnType("tinyint(1) unsigned");
                entity.Property(e => e.tbl_doucument_externalAccess).HasColumnType("tinyint(1) unsigned");
                entity.Property(e => e.tbl_document_blobToken).HasMaxLength(150);
                entity.Property(e => e.tbl_document_route).HasMaxLength(150);
                entity.Property(e => e.tbl_doucument_updatedBy).HasMaxLength(50);
                
                entity.Property(e => e.tbl_house_id).HasColumnType("int(11)");
                entity.Property(e => e.tbl_shipment_id).HasColumnType("int(11)");
                entity.Property(e => e.tbl_master_id).HasColumnType("int(11)");
                entity.Property(e => e.tbl_note_id).HasColumnType("int(11)");

                entity.Property(e => e.MasterCode).HasMaxLength(50);
                entity.Property(e => e.HouseCode).HasMaxLength(50);
                entity.Property(e => e.ShipmentCode).HasMaxLength(50);
                entity.Property(e => e.NoteCode).HasMaxLength(50);

                entity.HasOne(d => d.house)
                    .WithMany(p => p.documents)
                    .HasForeignKey(d => d.tbl_house_id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("document_house_link");

                entity.HasOne(d => d.shipment)
                    .WithMany(p => p.documents)
                    .HasForeignKey(d => d.tbl_shipment_id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("document_shipment_link");

                entity.HasOne(d => d.master)
                    .WithMany(p => p.documents)
                    .HasForeignKey(d => d.tbl_master_id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("document_master_link");
                entity.HasOne(d => d.note)
                    .WithMany(p => p.documents)
                    .HasForeignKey(d => d.tbl_note_id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("document_note_link");
            });

            modelBuilder.Entity<tbl_dynamic_filter>(entity =>
            {
                entity.HasKey(e => e.idtbl_dynamic_filters)
                    .HasName("PRIMARY");

                entity.HasIndex(e => e.idtbl_dynamic_filters, "idtbl_dynamic_filters_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.idtbl_dynamic_filters).HasColumnType("int(11)");

                entity.Property(e => e.tbl_dynamic_filters_column).HasMaxLength(45);

                entity.Property(e => e.tbl_dynamic_filters_condition).HasMaxLength(45);

                entity.Property(e => e.tbl_dynamic_filters_module).HasMaxLength(45);

                entity.Property(e => e.tbl_dynamic_filters_user).HasMaxLength(100);

                entity.Property(e => e.tbl_dynamic_filters_value).HasMaxLength(100);
            });

            modelBuilder.Entity<tbl_field_condition>(entity =>
            {
                entity.HasKey(e => e.tbl_field_conditions_id)
                    .HasName("PRIMARY");

                entity.Property(e => e.tbl_field_conditions_id).HasColumnType("int(11)");

                entity.Property(e => e.tbl_field_conditions).HasMaxLength(45);

                entity.Property(e => e.tbl_field_conditions_name).HasMaxLength(45);

                entity.Property(e => e.tbl_field_conditions_requirement).HasMaxLength(45);

                entity.Property(e => e.tbl_field_conditions_type).HasMaxLength(45);
            });

            modelBuilder.Entity<tbl_house>(entity =>
            {
                entity.HasKey(e => e.idtbl_house)
                    .HasName("PRIMARY");

                entity.ToTable("tbl_house");

                entity.HasIndex(e => e.tbl_consignee_id, "FK_tbl_house_tbl_client_header_tbl_consignee_id_idx");

                entity.HasIndex(e => e.tbl_consignor_id, "FK_tbl_house_tbl_client_header_tbl_consignor_id_idx");

                entity.HasIndex(e => e.tbl_incoterm_id, "FK_tbl_house_tbl_incoterm_tbl_incoterm_id_idx");

                entity.HasIndex(e => e.tbl_container_id, "IX_tbl_house_tbl_container_id");

                entity.HasIndex(e => e.tbl_master_id, "IX_tbl_house_tbl_master_id");

                entity.HasIndex(e => e.tbl_voyage_id, "IX_tbl_house_tbl_voyage_id");

                entity.HasIndex(e => e.tbl_pickupClient_id, "IX_tbl_house_tbl_client_header_tbl_pickClient_id");

                entity.HasIndex(e => e.tbl_deliveryClient_id, "IX_tbl_house_tbl_client_header_tbl_deliveryClient_id");

                entity.HasIndex(e => e.tbl_pickupAddress_id, "IX_tbl_house_tbl_address_tbl_pickAddress_id");

                entity.HasIndex(e => e.tbl_deliveryAddress_id, "IX_tbl_house_tbl_address_tbl_deliveryAddress_id");

                entity.Property(e => e.idtbl_house).HasColumnType("int(11)");

                entity.Property(e => e.tbl_house_DG).HasColumnType("tinyint(1) unsigned");

                entity.Property(e => e.tbl_house_FTA).HasColumnType("tinyint(1) unsigned");

                entity.Property(e => e.tbl_house_airJobReference).HasMaxLength(50);

                entity.Property(e => e.tbl_house_billNumber).HasMaxLength(30);

                entity.Property(e => e.tbl_house_class).HasMaxLength(50);

                entity.Property(e => e.tbl_house_clearanceDate).HasMaxLength(6);

                entity.Property(e => e.tbl_house_code).HasMaxLength(30);

                entity.Property(e => e.tbl_house_coloaderCode).HasMaxLength(50);

                entity.Property(e => e.tbl_house_coo).HasColumnType("tinyint(1) unsigned");

                entity.Property(e => e.tbl_house_createdDate).HasMaxLength(6);

                entity.Property(e => e.tbl_house_currency).HasMaxLength(50);

                entity.Property(e => e.tbl_house_delivery).HasMaxLength(50);

                entity.Property(e => e.tbl_house_deliveryDate).HasMaxLength(6);

                entity.Property(e => e.tbl_house_deliveryInstructions).HasMaxLength(150);

                entity.Property(e => e.tbl_house_description).HasMaxLength(150);

                entity.Property(e => e.tbl_house_destinationAirport).HasMaxLength(50);

                entity.Property(e => e.tbl_house_height).HasPrecision(12, 3);

                //entity.Property(e => e.tbl_house_incotermCode).HasMaxLength(50);

                entity.Property(e => e.tbl_house_latestTracking).HasMaxLength(50);

                entity.Property(e => e.tbl_house_length).HasPrecision(12, 3);

                entity.Property(e => e.tbl_house_native_description).HasMaxLength(150);

                entity.Property(e => e.tbl_house_originAirport).HasMaxLength(50);

                entity.Property(e => e.tbl_house_packaging).HasMaxLength(50);

                entity.Property(e => e.tbl_house_qty).HasColumnType("int(11)");

                entity.Property(e => e.tbl_house_serviceCode).HasMaxLength(50);

                entity.Property(e => e.tbl_house_shipperCode).HasMaxLength(50);

                entity.Property(e => e.tbl_house_status).HasMaxLength(50);

                entity.Property(e => e.tbl_house_tailLiftD).HasColumnType("tinyint(3) unsigned");

                entity.Property(e => e.tbl_house_tailLiftO).HasColumnType("tinyint(3) unsigned");

                entity.Property(e => e.tbl_house_type).HasMaxLength(50);

                entity.Property(e => e.tbl_house_value).HasPrecision(12, 2);

                entity.Property(e => e.tbl_house_volume).HasPrecision(12, 3);

                entity.Property(e => e.tbl_house_volumeUnit).HasMaxLength(50);

                entity.Property(e => e.tbl_house_weight).HasPrecision(12, 3);

                entity.Property(e => e.tbl_house_weightUnit).HasMaxLength(50);

                entity.Property(e => e.tbl_house_width).HasPrecision(12, 3);

                entity.Property(e => e.ConsigneeCode).HasMaxLength(50);

                entity.Property(e => e.ConsignorCode).HasMaxLength(50);

                entity.Property(e => e.ContainerCode).HasMaxLength(50);

                entity.Property(e => e.IncotermCode).HasMaxLength(50);

                entity.Property(e => e.VoyageCode).HasMaxLength(50);

                entity.Property(e => e.MasterCode).HasMaxLength(50);

                entity.Property(e => e.PickupClientCode).HasMaxLength(50);

                entity.Property(e => e.DeliveryClientCode).HasMaxLength(50);

                entity.Property(e => e.PickAddressCode).HasMaxLength(50);

                entity.Property(e => e.DeliveryAddressCode).HasMaxLength(50);

                entity.Property(e => e.tbl_consignee_id).HasColumnType("int(11)");

                entity.Property(e => e.tbl_consignor_id).HasColumnType("int(11)");

                entity.Property(e => e.tbl_container_id).HasColumnType("int(11)");

                entity.Property(e => e.tbl_incoterm_id).HasColumnType("int(11)");

                entity.Property(e => e.tbl_master_id).HasColumnType("int(11)");

                entity.Property(e => e.tbl_voyage_id).HasColumnType("int(11)");

                entity.Property(e => e.tbl_pickupClient_id).HasColumnType("int(11)");

                entity.Property(e => e.tbl_deliveryClient_id).HasColumnType("int(11)");

                entity.Property(e => e.tbl_pickupAddress_id).HasColumnType("int(11)");

                entity.Property(e => e.tbl_deliveryAddress_id).HasColumnType("int(11)");

                entity.HasOne(d => d.consignee)
                    .WithMany(p => p.consigneeHouses)
                    .HasForeignKey(d => d.tbl_consignee_id)
                    .HasConstraintName("FK_tbl_house_tbl_client_header_tbl_consignee_id");

                entity.HasOne(d => d.consignor)
                    .WithMany(p => p.consignorHouses)
                    .HasForeignKey(d => d.tbl_consignor_id)
                    .HasConstraintName("FK_tbl_house_tbl_client_header_tbl_consignor_id");

                entity.HasOne(d => d.container)
                    .WithMany(p => p.houses)
                    .HasForeignKey(d => d.tbl_container_id)
                    .HasConstraintName("FK_tbl_house_tbl_container_tbl_container_id");

                entity.HasOne(d => d.incoterm)
                    .WithMany(p => p.houses)
                    .HasForeignKey(d => d.tbl_incoterm_id)
                    .HasConstraintName("FK_tbl_house_tbl_incoterms_tbl_incoterm_id");

                entity.HasOne(d => d.master)
                    .WithMany(p => p.houses)
                    .HasForeignKey(d => d.tbl_master_id)
                    .HasConstraintName("FK_tbl_house_tbl_master_tbl_master_id");

                entity.HasOne(d => d.voyage)
                .WithMany(p => p.houses)
                .HasForeignKey(d => d.tbl_voyage_id)
                .HasConstraintName("FK_tbl_house_tbl_voyage_tbl_voyage_id");

                entity.HasOne(d => d.pickupClient)
                .WithMany(p => p.pickupClientHouses)
                .HasForeignKey(d => d.tbl_pickupClient_id)
                .HasConstraintName("FK_tbl_house_tbl_client_header_tbl_pickClient_id");

                entity.HasOne(d => d.deliveryClient)
                .WithMany(p => p.deliveryClientHouses)
                .HasForeignKey(d => d.tbl_deliveryClient_id)
                .HasConstraintName("FK_tbl_house_tbl_client_header_tbl_deliveryClient_id");

                entity.HasOne(d => d.pickupAddress)
                .WithMany(p => p.pickupAddressHouses)
                .HasForeignKey(d => d.tbl_pickupAddress_id)
                .HasConstraintName("FK_tbl_house_tbl_address_tbl_pickupAddress_id");

                entity.HasOne(d => d.deliveryAddress)
                .WithMany(p => p.deliveryAddressHouses)
                .HasForeignKey(d => d.tbl_deliveryAddress_id)
                .HasConstraintName("FK_tbl_house_tbl_address_tbl_deliveryAddress_id");
            });

            modelBuilder.Entity<tbl_house_item>(entity =>
            {
                entity.HasKey(e => e.idtbl_house_item)
                    .HasName("PRIMARY");

                entity.HasIndex(e => e.tbl_house_id, "FK_tbl_house_items_tbl_house_tbl_house_id_idx");

                entity.Property(e => e.idtbl_house_item).HasColumnType("int(11)");

                entity.Property(e => e.HouseCode).HasMaxLength(30);

                entity.Property(e => e.tbl_house_id).HasColumnType("int(11)");

                entity.Property(e => e.tbl_house_item_code).HasMaxLength(50);

                entity.Property(e => e.tbl_house_item_description).HasMaxLength(150);

                entity.Property(e => e.tbl_house_item_dg).HasColumnType("tinyint(3) unsigned");

                entity.Property(e => e.tbl_house_item_height).HasPrecision(12, 3);

                entity.Property(e => e.tbl_house_item_length).HasPrecision(12, 3);

                entity.Property(e => e.tbl_house_item_qty).HasColumnType("int(11)");

                entity.Property(e => e.tbl_house_item_type).HasMaxLength(50);

                entity.Property(e => e.tbl_house_item_volumeUnit).HasMaxLength(50);

                entity.Property(e => e.tbl_house_item_weight).HasPrecision(12, 3);

                entity.Property(e => e.tbl_house_item_weightUnit).HasMaxLength(50);

                entity.Property(e => e.tbl_house_item_width).HasPrecision(12, 3);

                entity.HasOne(d => d.house)
                    .WithMany(p => p.houseItems)
                    .HasForeignKey(d => d.tbl_house_id);
            });

            modelBuilder.Entity<tbl_hunterrate>(entity =>
            {
                entity.HasKey(e => new { e.tbl_hunterrates_injectionport, e.tbl_hunterrates_zone })
                    .HasName("PRIMARY")
                    .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

                entity.Property(e => e.tbl_hunterrates_injectionport).HasMaxLength(3);

                entity.Property(e => e.tbl_hunterrates_zone).HasColumnType("int(3)");

                entity.Property(e => e.tbl_hunterrates_base).HasPrecision(15, 2);

                entity.Property(e => e.tbl_hunterrates_min).HasPrecision(15, 2);

                entity.Property(e => e.tbl_hunterrates_perkg).HasPrecision(15, 2);
            });

            modelBuilder.Entity<tbl_hunterzone>(entity =>
            {
                entity.HasKey(e => new { e.tbl_hunterzones_suburb, e.tbl_hunterzones_postcode })
                    .HasName("PRIMARY")
                    .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

                entity.Property(e => e.tbl_hunterzones_suburb).HasMaxLength(55);

                entity.Property(e => e.tbl_hunterzones_postcode).HasColumnType("int(5)");

                entity.Property(e => e.tbl_hunterzones_labelzone).HasMaxLength(3);

                entity.Property(e => e.tbl_hunterzones_routescan).HasMaxLength(3);

                entity.Property(e => e.tbl_hunterzones_state).HasMaxLength(3);

                entity.Property(e => e.tbl_hunterzones_zone).HasColumnType("int(2)");
            });

            modelBuilder.Entity<tbl_incoterm>(entity =>
            {
                entity.HasKey(e => e.idtbl_incoterm)
                    .HasName("PRIMARY");
                entity.ToTable("tbl_incoterm");

                entity.Property(e => e.idtbl_incoterm).HasColumnType("int(11)");

                entity.Property(e => e.tbl_incoterm_code).HasMaxLength(50);

                entity.Property(e => e.tbl_incoterm_description).HasMaxLength(150);
            });

            modelBuilder.Entity<tbl_item_sku>(entity =>
            {
                entity.HasKey(e => e.idtbl_item_sku)
                    .HasName("PRIMARY");

                entity.ToTable("tbl_item_sku");

                entity.Property(e => e.idtbl_item_sku).HasColumnType("int(11)");

                entity.Property(e => e.tbl_items_batchNumber).HasMaxLength(50);

                entity.Property(e => e.tbl_items_batteryPacking).HasMaxLength(50);

                entity.Property(e => e.tbl_items_batteryType).HasMaxLength(50);

                entity.Property(e => e.tbl_items_dangerousGoods).HasColumnType("tinyint(3) unsigned");

                entity.Property(e => e.tbl_items_description).HasMaxLength(150);

                entity.Property(e => e.tbl_items_height).HasPrecision(12, 3);

                entity.Property(e => e.tbl_items_hsCode).HasMaxLength(50);

                entity.Property(e => e.tbl_items_length).HasPrecision(12, 3);

                entity.Property(e => e.tbl_items_nativeDescription).HasMaxLength(150);

                entity.Property(e => e.tbl_items_originCountry).HasMaxLength(50);

                entity.Property(e => e.tbl_items_productUrl).HasMaxLength(50);

                entity.Property(e => e.tbl_items_qty).HasColumnType("int(11)");

                entity.Property(e => e.tbl_item_sku_code).HasMaxLength(50);

                entity.Property(e => e.tbl_items_value).HasPrecision(12, 2);

                entity.Property(e => e.tbl_items_volume).HasPrecision(12, 3);

                entity.Property(e => e.tbl_items_volumeUnit).HasMaxLength(50);

                entity.Property(e => e.tbl_items_weight).HasPrecision(12, 3);

                entity.Property(e => e.tbl_items_weightUnit).HasMaxLength(50);

                entity.Property(e => e.tbl_items_width).HasPrecision(12, 3);
            });

            modelBuilder.Entity<tbl_master>(entity =>
            {
                entity.HasKey(e => e.idtbl_master)
                    .HasName("PRIMARY");

                entity.ToTable("tbl_master");

                entity.HasIndex(e => e.tbl_client_header_carrier_id, "IX_tbl_master_tbl_client_header_carrier_id");

                entity.HasIndex(e => e.tbl_client_header_creditor_id, "IX_tbl_master_tbl_client_header_creditor_id");

                entity.HasIndex(e => e.tbl_client_header_destination_id, "IX_tbl_master_tbl_client_header_destination_id");

                entity.HasIndex(e => e.tbl_client_header_origin_id, "IX_tbl_master_tbl_client_header_origin_id");

                entity.HasIndex(e => e.tbl_voyage_id, "IX_tbl_master_tbl_voyage_id");

                entity.Property(e => e.idtbl_master).HasColumnType("int(11)");

                entity.Property(e => e.VoyageCode).HasMaxLength(30);

                entity.Property(e => e.carrierAgentCode).HasMaxLength(30);

                entity.Property(e => e.creditorAgentCode).HasMaxLength(30);

                entity.Property(e => e.destinationAgentCode).HasMaxLength(30);

                entity.Property(e => e.originAgentCode).HasMaxLength(30);

                entity.Property(e => e.tbl_client_header_carrier_id).HasColumnType("int(11)");

                entity.Property(e => e.tbl_client_header_creditor_id).HasColumnType("int(11)");

                entity.Property(e => e.tbl_client_header_destination_id).HasColumnType("int(11)");

                entity.Property(e => e.tbl_client_header_origin_id).HasColumnType("int(11)");

                entity.Property(e => e.tbl_master_billNumber).HasMaxLength(50);

                entity.Property(e => e.tbl_master_bookingNumber).HasMaxLength(50);

                entity.Property(e => e.tbl_master_code).HasMaxLength(30);

                entity.Property(e => e.tbl_master_containerMode).HasMaxLength(30);

                entity.Property(e => e.tbl_master_createdDate).HasColumnType("datetime");

                entity.Property(e => e.tbl_master_status).HasMaxLength(50);

                entity.Property(e => e.tbl_master_transportType).HasMaxLength(30);

                entity.Property(e => e.tbl_master_type).HasMaxLength(30);

                entity.Property(e => e.tbl_voyage_id).HasColumnType("int(11)");

                entity.HasOne(d => d.carrierAgent)
                    .WithMany(p => p.carrierMasters)
                    .HasForeignKey(d => d.tbl_client_header_carrier_id)
                    .HasConstraintName("FK_tbl_master_tbl_client_header_tbl_client_header_carrier_id");

                entity.HasOne(d => d.creditorAgent)
                    .WithMany(p => p.creditorMasters)
                    .HasForeignKey(d => d.tbl_client_header_creditor_id)
                    .HasConstraintName("FK_tbl_master_tbl_client_header_tbl_client_header_creditor_id");

                entity.HasOne(d => d.destinationAgent)
                    .WithMany(p => p.destinationClientMasters)
                    .HasForeignKey(d => d.tbl_client_header_destination_id)
                    .HasConstraintName("FK_tbl_master_tbl_client_header_tbl_client_header_destination_id");

                entity.HasOne(d => d.originAgent)
                    .WithMany(p => p.originClientMasters)
                    .HasForeignKey(d => d.tbl_client_header_origin_id)
                    .HasConstraintName("FK_tbl_master_tbl_client_header_tbl_client_header_origin_id");

                entity.HasOne(d => d.voyage)
                    .WithMany(p => p.masters)
                    .HasForeignKey(d => d.tbl_voyage_id)
                    .HasConstraintName("FK_tbl_master_tbl_voyage_tbl_voyage_id");
            });

            modelBuilder.Entity<tbl_milestone_header>(entity =>
            {
                entity.HasKey(e => e.idtbl_milestone_header)
                .HasName("PRIMARY");

                entity.ToTable("tbl_milestone_header");

                entity.Property(e => e.idtbl_milestone_header).HasColumnType("int(11)");
                entity.Property(e => e.tbl_milestone_header_code).HasMaxLength(50);
                entity.Property(e => e.tbl_milestone_header_name).HasMaxLength(50);
                entity.Property(e => e.tbl_milestone_header_description).HasMaxLength(50);
                entity.Property(e => e.tbl_milestone_header_createdBy).HasMaxLength(50);
                entity.Property(e => e.tbl_milestone_header_createdDate).HasMaxLength(6);
            });

            modelBuilder.Entity<tbl_milestone_link>(entity =>
            {
                entity.HasKey(e => e.idtbl_milestone_link)
                .HasName("PRIMARY");

                entity.ToTable("tbl_milestone_link");

                entity.HasIndex(e => e.tbl_house_id, "idx_mslink_house_link_idx");
                entity.HasIndex(e => e.tbl_shipment_id, "idx_mslink_shipment_link_idx");
                entity.HasIndex(e => e.tbl_master_id, "idx_mslink_master_link_idx");

                entity.Property(e => e.idtbl_milestone_link).HasColumnType("int(11)");
                entity.Property(e => e.tbl_milestone_link_code).HasMaxLength(50);
                entity.Property(e => e.tbl_milestone_link_value).HasMaxLength(6);
                entity.Property(e => e.tbl_milestone_link_createdBy).HasMaxLength(50);
                entity.Property(e => e.tbl_milestone_link_createdDate).HasMaxLength(6);

                entity.Property(e => e.tbl_house_id).HasColumnType("int(11)");
                entity.Property(e => e.tbl_shipment_id).HasColumnType("int(11)");
                entity.Property(e => e.tbl_master_id).HasColumnType("int(11)");
                entity.Property(e => e.tbl_milestone_header_id).HasColumnType("int(11)");


                entity.Property(e => e.MasterCode).HasMaxLength(50);
                entity.Property(e => e.HouseCode).HasMaxLength(50);
                entity.Property(e => e.ShipmentCode).HasMaxLength(50);
                entity.Property(e => e.MilestoneHeaderCode).HasMaxLength(50);

                entity.HasOne(d => d.house)
                   .WithMany(p => p.milestoneLinks)
                   .HasForeignKey(d => d.tbl_house_id)
                   .OnDelete(DeleteBehavior.ClientSetNull)
                   .HasConstraintName("msLink_house_link");

                entity.HasOne(d => d.shipment)
                    .WithMany(p => p.milestoneLinks)
                    .HasForeignKey(d => d.tbl_shipment_id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("msLink_shipment_link");

                entity.HasOne(d => d.master)
                    .WithMany(p => p.milestoneLinks)
                    .HasForeignKey(d => d.tbl_master_id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("msLink_master_link");
                entity.HasOne(d => d.milestoneHeader)
                    .WithMany(p => p.milestoneLinks)
                    .HasForeignKey(d => d.tbl_milestone_header_id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("msLink_msHeader_link");
            });

            modelBuilder.Entity<tbl_note_category>(entity =>
            {
                entity.HasKey(e => e.idtbl_note_category)
                    .HasName("PRIMARY");

                entity.ToTable("tbl_note_category");
                entity.Property(e => e.idtbl_note_category).HasColumnType("int(11)");
                entity.Property(e => e.tbl_note_category_code).HasMaxLength(50);
                entity.Property(e => e.tbl_note_category_status).HasColumnType("tinyint(1)");
                entity.Property(e => e.tbl_note_category_name).HasMaxLength(50);
                entity.Property(e => e.tbl_note_category_color).HasMaxLength(50);
                entity.Property(e => e.tbl_note_category_value).HasMaxLength(50);

            });

            modelBuilder.Entity<tbl_note>(entity =>
            {
                entity.HasKey(e => e.idtbl_note)
                    .HasName("PRIMARY");

                entity.ToTable("tbl_note");
                entity.HasIndex(e => e.tbl_house_id, "idx_note_house_link_idx");
                entity.HasIndex(e => e.tbl_shipment_id, "idx_note_shipment_link_idx");
                entity.HasIndex(e => e.tbl_master_id, "idx_note_master_link_idx");
                entity.HasIndex(e => e.tbl_client_header_id, "idx_note_client_header_link_idx");
                entity.HasIndex(e => e.tbl_note_category_id, "idx_note_note_category_link_idx");

                entity.Property(e => e.idtbl_note).HasColumnType("int(11)");
                entity.Property(e => e.tbl_note_code).HasMaxLength(50);
                entity.Property(e => e.tbl_note_status).HasColumnType("tinyint(3) unsigned");
                entity.Property(e => e.tbl_note_createdDate).HasMaxLength(6);
                entity.Property(e => e.tbl_note_title).HasMaxLength(50);
                entity.Property(e => e.tbl_note_description).HasMaxLength(150);

                entity.Property(e => e.tbl_house_id).HasColumnType("int(11)");
                entity.Property(e => e.tbl_shipment_id).HasColumnType("int(11)");
                entity.Property(e => e.tbl_master_id).HasColumnType("int(11)");
                entity.Property(e => e.tbl_note_category_id).HasColumnType("int(11)");
                entity.Property(e => e.tbl_client_header_id).HasColumnType("int(11)");

                entity.Property(e => e.MasterCode).HasMaxLength(50);
                entity.Property(e => e.HouseCode).HasMaxLength(50);
                entity.Property(e => e.ShipmentCode).HasMaxLength(50);
                entity.Property(e => e.ClientHeaderCode).HasMaxLength(50);
                entity.Property(e => e.NoteCategoryCode).HasMaxLength(50);

                entity.HasOne(d => d.house)
                    .WithMany(p => p.notes)
                    .HasForeignKey(d => d.tbl_house_id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("note_house_link");

                entity.HasOne(d => d.shipment)
                    .WithMany(p => p.notes)
                    .HasForeignKey(d => d.tbl_shipment_id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("note_shipment_link");

                entity.HasOne(d => d.master)
                    .WithMany(p => p.notes)
                    .HasForeignKey(d => d.tbl_master_id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("note_master_link");
                entity.HasOne(d => d.clientHeader)
                    .WithMany(p => p.notes)
                    .HasForeignKey(d => d.tbl_client_header_id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("note_client_header_link");
                entity.HasOne(d => d.noteCategory)
                    .WithMany(p => p.notes)
                    .HasForeignKey(d => d.tbl_note_category_id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("note_note_category_link");
            });

            modelBuilder.Entity<tbl_nz_routing>(entity =>
            {
                entity.HasKey(e => e.tbl_routings_id)
                    .HasName("PRIMARY");

                entity.Property(e => e.tbl_routings_id).HasColumnType("int(11)");

                entity.Property(e => e.tbl_routings_code)
                    .IsRequired()
                    .HasMaxLength(3);

                entity.Property(e => e.tbl_routings_states)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.tbl_routings_suburbs)
                    .IsRequired()
                    .HasMaxLength(5);
            });

            modelBuilder.Entity<tbl_parcel_tracking>(entity =>
            {
                entity.HasKey(e => e.tbl_parcel_tracking_id)
                    .HasName("PRIMARY");

                entity.ToTable("tbl_parcel_tracking");

                entity.Property(e => e.tbl_parcel_tracking_id)
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever();

                entity.Property(e => e.tbl_parcel_tracking_received).HasColumnType("tinyint(4)");

                entity.Property(e => e.tbl_parcel_tracking_shipmentId)
                    .IsRequired()
                    .HasMaxLength(5);
            });

            modelBuilder.Entity<tbl_pluscourier>(entity =>
            {
                entity.HasKey(e => e.tbl_pluscourier_id)
                    .HasName("PRIMARY");

                entity.ToTable("tbl_pluscourier");

                entity.Property(e => e.tbl_pluscourier_id).HasColumnType("int(11)");

                entity.Property(e => e.tbl_pluscourier_distance).HasColumnType("int(11)");

                entity.Property(e => e.tbl_pluscourier_postcode).HasMaxLength(15);

                entity.Property(e => e.tbl_pluscourier_suburb).HasMaxLength(45);
            });

            modelBuilder.Entity<tbl_pluscourier_rate>(entity =>
            {
                entity.HasKey(e => e.tbl_pluscourier_rate_id)
                    .HasName("PRIMARY");

                entity.ToTable("tbl_pluscourier_rate");

                entity.Property(e => e.tbl_pluscourier_rate_id).HasColumnType("int(11)");

                entity.Property(e => e.tbl_pluscourier_rate_km).HasColumnType("int(11)");

                entity.Property(e => e.tbl_pluscourier_rate_notes).HasMaxLength(45);

                entity.Property(e => e.tbl_pluscourier_rate_pallet).HasPrecision(10, 2);
            });

            modelBuilder.Entity<tbl_receptacle>(entity =>
            {
                entity.HasKey(e => e.idtbl_receptacle)
                    .HasName("PRIMARY");

                entity.ToTable("tbl_receptacle");

                entity.HasIndex(e => e.tbl_house_id, "IX_tbl_receptacle_tbl_house_id");

                entity.Property(e => e.idtbl_receptacle).HasColumnType("int(11)");

                entity.Property(e => e.HouseCode).HasMaxLength(30);

                entity.Property(e => e.tbl_house_id).HasColumnType("int(11)");

                entity.Property(e => e.tbl_receptacle_code).HasMaxLength(50);

                entity.Property(e => e.tbl_receptacle_createdDate).HasMaxLength(6);

                entity.Property(e => e.tbl_receptacle_destination).HasMaxLength(50);

                entity.Property(e => e.tbl_receptacle_height).HasPrecision(12, 3);

                entity.Property(e => e.tbl_receptacle_length).HasPrecision(12, 3);

                entity.Property(e => e.tbl_receptacle_mode).HasMaxLength(50);

                entity.Property(e => e.tbl_receptacle_origin).HasMaxLength(50);

                entity.Property(e => e.tbl_receptacle_qty).HasColumnType("int(11)");

                entity.Property(e => e.tbl_receptacle_shipper_code).HasMaxLength(50);

                entity.Property(e => e.tbl_receptacle_status).HasMaxLength(50);

                entity.Property(e => e.tbl_receptacle_type).HasMaxLength(50);

                entity.Property(e => e.tbl_receptacle_weight).HasPrecision(12, 3);

                entity.Property(e => e.tbl_receptacle_width).HasPrecision(12, 3);

                entity.Property(e => e.tbl_house_id).HasColumnType("int(11)");

                entity.HasOne(d => d.house)
                    .WithMany(p => p.receptacles)
                    .HasForeignKey(d => d.tbl_house_id);
            });

            modelBuilder.Entity<tbl_return>(entity =>
            {
                entity.HasKey(e => e.tbl_returns_id)
                    .HasName("PRIMARY");

                entity.Property(e => e.tbl_returns_id)
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever();

                entity.Property(e => e.tbl_returns_address1).HasMaxLength(45);

                entity.Property(e => e.tbl_returns_address2).HasMaxLength(45);

                entity.Property(e => e.tbl_returns_address3).HasMaxLength(45);

                entity.Property(e => e.tbl_returns_city).HasMaxLength(45);

                entity.Property(e => e.tbl_returns_country).HasMaxLength(45);

                entity.Property(e => e.tbl_returns_name).HasMaxLength(45);

                entity.Property(e => e.tbl_returns_option).HasMaxLength(45);

                entity.Property(e => e.tbl_returns_postcode).HasMaxLength(45);

                entity.Property(e => e.tbl_returns_reference).HasMaxLength(45);

                entity.Property(e => e.tbl_returns_state).HasMaxLength(45);

                entity.Property(e => e.tbl_returns_status).HasMaxLength(45);

                entity.Property(e => e.tbl_returns_suburb).HasMaxLength(45);
            });

            modelBuilder.Entity<tbl_returns_sku>(entity =>
            {
                entity.HasKey(e => e.tbl_returns_sku_id)
                    .HasName("PRIMARY");

                entity.ToTable("tbl_returns_sku");

                entity.Property(e => e.tbl_returns_sku_id)
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever();

                entity.Property(e => e.tbl_returns_sku_action).HasMaxLength(45);

                entity.Property(e => e.tbl_returns_sku_batch).HasMaxLength(45);

                entity.Property(e => e.tbl_returns_sku_dangerousgoods).HasMaxLength(45);

                entity.Property(e => e.tbl_returns_sku_description).HasMaxLength(45);

                entity.Property(e => e.tbl_returns_sku_hscode).HasMaxLength(45);

                entity.Property(e => e.tbl_returns_sku_value).HasMaxLength(45);
            });

            modelBuilder.Entity<tbl_routing>(entity =>
            {
                entity.HasKey(e => e.idtbl_routing)
                    .HasName("PRIMARY");

                entity.ToTable("tbl_routing");

                entity.HasIndex(e => e.tbl_voyage_id, "IX_tbl_routing_tbl_voyage_id");

                entity.Property(e => e.idtbl_routing).HasColumnType("int(11)");

                entity.Property(e => e.VoyageNumber).HasMaxLength(30);

                entity.Property(e => e.tbl_routing_cutoffDate).HasMaxLength(6);

                entity.Property(e => e.tbl_voyage_ata).HasMaxLength(6);

                entity.Property(e => e.tbl_voyage_atd).HasMaxLength(6);

                entity.Property(e => e.tbl_voyage_dischargePort).HasMaxLength(50);

                entity.Property(e => e.tbl_voyage_eta).HasMaxLength(6);

                entity.Property(e => e.tbl_voyage_etd).HasMaxLength(6);

                entity.Property(e => e.tbl_voyage_id).HasColumnType("int(11)");

                entity.Property(e => e.tbl_voyage_loadPort).HasMaxLength(50);

                entity.HasOne(d => d.voyage)
                    .WithMany(p => p.routings)
                    .HasForeignKey(d => d.tbl_voyage_id);
            });

            modelBuilder.Entity<tbl_sea_shipment>(entity =>
            {
                entity.HasKey(e => e.tbl_sea_shipment_id)
                    .HasName("PRIMARY");

                entity.ToTable("tbl_sea_shipment");

                entity.Property(e => e.tbl_sea_shipment_id).HasColumnType("int(11)");

                entity.Property(e => e.tbl_sea_shipment_COO).HasColumnType("tinyint(4)");

                entity.Property(e => e.tbl_sea_shipment_DG).HasColumnType("tinyint(4)");

                entity.Property(e => e.tbl_sea_shipment_FTA).HasColumnType("tinyint(4)");

                entity.Property(e => e.tbl_sea_shipment_UN).HasPrecision(10);

                entity.Property(e => e.tbl_sea_shipment_ata).HasColumnType("datetime");

                entity.Property(e => e.tbl_sea_shipment_atd).HasColumnType("datetime");

                entity.Property(e => e.tbl_sea_shipment_class).HasMaxLength(45);

                entity.Property(e => e.tbl_sea_shipment_clearancedate).HasColumnType("datetime");

                entity.Property(e => e.tbl_sea_shipment_coloaderCode).HasMaxLength(45);

                entity.Property(e => e.tbl_sea_shipment_currency).HasMaxLength(5);

                entity.Property(e => e.tbl_sea_shipment_deliverydate).HasColumnType("datetime");

                entity.Property(e => e.tbl_sea_shipment_description).HasMaxLength(45);

                entity.Property(e => e.tbl_sea_shipment_destinationPort).HasMaxLength(5);

                entity.Property(e => e.tbl_sea_shipment_eta).HasColumnType("datetime");

                entity.Property(e => e.tbl_sea_shipment_etd).HasColumnType("datetime");

                entity.Property(e => e.tbl_sea_shipment_howb).HasMaxLength(45);

                entity.Property(e => e.tbl_sea_shipment_incotermCode).HasMaxLength(5);

                entity.Property(e => e.tbl_sea_shipment_latestTracking).HasMaxLength(45);

                entity.Property(e => e.tbl_sea_shipment_mowb).HasMaxLength(45);

                entity.Property(e => e.tbl_sea_shipment_notes).HasMaxLength(45);

                entity.Property(e => e.tbl_sea_shipment_originPort).HasMaxLength(5);

                entity.Property(e => e.tbl_sea_shipment_packaging).HasMaxLength(45);

                entity.Property(e => e.tbl_sea_shipment_pieces).HasColumnType("int(11)");

                entity.Property(e => e.tbl_sea_shipment_receiverAddress1).HasMaxLength(45);

                entity.Property(e => e.tbl_sea_shipment_receiverAddress2).HasMaxLength(45);

                entity.Property(e => e.tbl_sea_shipment_receiverBusiness).HasMaxLength(45);

                entity.Property(e => e.tbl_sea_shipment_receiverCity).HasMaxLength(25);

                entity.Property(e => e.tbl_sea_shipment_receiverCountry).HasMaxLength(15);

                entity.Property(e => e.tbl_sea_shipment_receiverEmail).HasMaxLength(45);

                entity.Property(e => e.tbl_sea_shipment_receiverName).HasMaxLength(45);

                entity.Property(e => e.tbl_sea_shipment_receiverPhone).HasMaxLength(15);

                entity.Property(e => e.tbl_sea_shipment_receiverPostcode).HasMaxLength(15);

                entity.Property(e => e.tbl_sea_shipment_receiverState).HasMaxLength(15);

                entity.Property(e => e.tbl_sea_shipment_receiverSuburb).HasMaxLength(45);

                entity.Property(e => e.tbl_sea_shipment_seaJobReference).HasMaxLength(45);

                entity.Property(e => e.tbl_sea_shipment_senderAddress1).HasMaxLength(45);

                entity.Property(e => e.tbl_sea_shipment_senderAddress2).HasMaxLength(45);

                entity.Property(e => e.tbl_sea_shipment_senderBusiness).HasMaxLength(45);

                entity.Property(e => e.tbl_sea_shipment_senderCity).HasMaxLength(45);

                entity.Property(e => e.tbl_sea_shipment_senderCountry).HasMaxLength(45);

                entity.Property(e => e.tbl_sea_shipment_senderEmail).HasMaxLength(45);

                entity.Property(e => e.tbl_sea_shipment_senderName).HasMaxLength(45);

                entity.Property(e => e.tbl_sea_shipment_senderPhone).HasMaxLength(45);

                entity.Property(e => e.tbl_sea_shipment_senderPostcode).HasMaxLength(45);

                entity.Property(e => e.tbl_sea_shipment_senderRef).HasMaxLength(45);

                entity.Property(e => e.tbl_sea_shipment_senderState).HasMaxLength(45);

                entity.Property(e => e.tbl_sea_shipment_senderSuburb).HasMaxLength(45);

                entity.Property(e => e.tbl_sea_shipment_service).HasMaxLength(45);

                entity.Property(e => e.tbl_sea_shipment_shipperID).HasMaxLength(15);

                entity.Property(e => e.tbl_sea_shipment_shippingLine).HasMaxLength(45);

                entity.Property(e => e.tbl_sea_shipment_status).HasMaxLength(45);

                entity.Property(e => e.tbl_sea_shipment_tailLiftD).HasColumnType("tinyint(4)");

                entity.Property(e => e.tbl_sea_shipment_tailLiftO).HasColumnType("tinyint(4)");

                entity.Property(e => e.tbl_sea_shipment_timestamp).HasColumnType("datetime");

                entity.Property(e => e.tbl_sea_shipment_transit1).HasMaxLength(5);

                entity.Property(e => e.tbl_sea_shipment_transit2).HasMaxLength(5);

                entity.Property(e => e.tbl_sea_shipment_transit3).HasMaxLength(5);

                entity.Property(e => e.tbl_sea_shipment_type).HasMaxLength(45);

                entity.Property(e => e.tbl_sea_shipment_value).HasPrecision(10);

                entity.Property(e => e.tbl_sea_shipment_volume).HasPrecision(10);

                entity.Property(e => e.tbl_sea_shipment_weight).HasPrecision(10);
            });

            modelBuilder.Entity<tbl_service>(entity =>
            {
                entity.HasKey(e => e.tbl_services_id)
                    .HasName("PRIMARY");

                entity.Property(e => e.tbl_services_id).HasColumnType("int(11)");

                entity.Property(e => e.tbl_services_carrierAccount).HasMaxLength(45);

                entity.Property(e => e.tbl_services_carrierCode).HasMaxLength(45);

                entity.Property(e => e.tbl_services_carrierId)
                    .IsRequired()
                    .HasMaxLength(15);

                entity.Property(e => e.tbl_services_code)
                    .IsRequired()
                    .HasMaxLength(22);

                entity.Property(e => e.tbl_services_name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.tbl_services_prefixCode).HasMaxLength(10);
            });

            modelBuilder.Entity<tbl_shipment>(entity =>
            {
                entity.HasKey(e => e.idtbl_shipment)
                    .HasName("PRIMARY");

                entity.ToTable("tbl_shipment");

                entity.HasIndex(e => e.tbl_incoterms_id, "FK_tbl_shipment_tbl_incoterms_tbl_incoterms_id_idx");
                //Edit by HS on 25/05/2023
                //entity.HasIndex(e => e.tbl_receptable_id, "FK_tbl_shipment_tbl_receptacle_tbl_receptacle_id_idx");
                entity.HasIndex(e => e.tbl_receptacle_id, "FK_tbl_shipment_tbl_receptacle_tbl_receptacle_id_idx");

                entity.Property(e => e.idtbl_shipment).HasColumnType("int(11)");

                entity.Property(e => e.IncotermsCode).HasMaxLength(30);

                entity.Property(e => e.ReceptacleCode).HasMaxLength(30);

                entity.Property(e => e.tbl_incoterms_id).HasColumnType("int(11)");
                //Edit by HS on 25/05/2023
                //entity.Property(e => e.tbl_receptable_id).HasColumnType("int(11)");
                entity.Property(e => e.tbl_receptacle_id).HasColumnType("int(11)");

                entity.Property(e => e.tbl_shipment_abnNumber).HasMaxLength(45);

                entity.Property(e => e.tbl_shipment_authorityToLeave).HasDefaultValueSql("'0'");

                entity.Property(e => e.tbl_shipment_batchCode).HasMaxLength(15);

                entity.Property(e => e.tbl_shipment_code).HasMaxLength(30);

                entity.Property(e => e.tbl_shipment_coverAmount).HasPrecision(11, 2);

                entity.Property(e => e.tbl_shipment_createdDate).HasColumnType("datetime");

                entity.Property(e => e.tbl_shipment_deliveryAddressLine1).HasMaxLength(150);

                entity.Property(e => e.tbl_shipment_deliveryAddressLine2).HasMaxLength(150);

                entity.Property(e => e.tbl_shipment_deliveryAddressLine3).HasMaxLength(150);

                entity.Property(e => e.tbl_shipment_deliveryCity).HasMaxLength(45);

                entity.Property(e => e.tbl_shipment_deliveryCompany).HasMaxLength(45);

                entity.Property(e => e.tbl_shipment_deliveryContact).HasMaxLength(45);

                entity.Property(e => e.tbl_shipment_deliveryContactEmail).HasMaxLength(45);

                entity.Property(e => e.tbl_shipment_deliveryContactPhone).HasMaxLength(45);

                entity.Property(e => e.tbl_shipment_deliveryCountry).HasMaxLength(2);

                entity.Property(e => e.tbl_shipment_deliveryDate).HasColumnType("datetime");

                entity.Property(e => e.tbl_shipment_deliveryEmail).HasMaxLength(45);

                entity.Property(e => e.tbl_shipment_deliveryInstructions).HasMaxLength(150);

                entity.Property(e => e.tbl_shipment_deliveryName).HasMaxLength(45);

                entity.Property(e => e.tbl_shipment_deliveryPhone).HasMaxLength(45);

                entity.Property(e => e.tbl_shipment_deliveryPostcode).HasMaxLength(45);

                entity.Property(e => e.tbl_shipment_deliveryState).HasMaxLength(45);

                entity.Property(e => e.tbl_shipment_deliverySuburb).HasMaxLength(45);

                entity.Property(e => e.tbl_shipment_description).HasMaxLength(150);

                entity.Property(e => e.tbl_shipment_dg).HasDefaultValueSql("'0'");

                entity.Property(e => e.tbl_shipment_dgClass).HasMaxLength(45);

                entity.Property(e => e.tbl_shipment_dgPackaging).HasMaxLength(45);

                entity.Property(e => e.tbl_shipment_dgUn).HasMaxLength(45);

                entity.Property(e => e.tbl_shipment_facility).HasMaxLength(150);

                entity.Property(e => e.tbl_shipment_gstExemptionCode).HasDefaultValueSql("'0'");

                entity.Property(e => e.tbl_shipment_hasLockerService).HasDefaultValueSql("'0'");

                entity.Property(e => e.tbl_shipment_incoterm).HasMaxLength(5);

                entity.Property(e => e.tbl_shipment_instruction).HasMaxLength(150);

                entity.Property(e => e.tbl_shipment_invoiceCurrency).HasMaxLength(3);

                entity.Property(e => e.tbl_shipment_invoiceValue).HasPrecision(11, 2);

                entity.Property(e => e.tbl_shipment_nativeDescription).HasMaxLength(150);

                entity.Property(e => e.tbl_shipment_orderItems).HasMaxLength(2000);

                entity.Property(e => e.tbl_shipment_phone).HasMaxLength(45);

                entity.Property(e => e.tbl_shipment_platform).HasMaxLength(45);

                entity.Property(e => e.tbl_shipment_readyDate).HasColumnType("datetime");

                entity.Property(e => e.tbl_shipment_referenceNo).HasMaxLength(50);

                entity.Property(e => e.tbl_shipment_returnAddress1).HasMaxLength(150);

                entity.Property(e => e.tbl_shipment_returnAddress2).HasMaxLength(150);

                entity.Property(e => e.tbl_shipment_returnAddress3).HasMaxLength(150);

                entity.Property(e => e.tbl_shipment_returnCity).HasMaxLength(45);

                entity.Property(e => e.tbl_shipment_returnCountry).HasMaxLength(2);

                entity.Property(e => e.tbl_shipment_returnName).HasMaxLength(150);

                entity.Property(e => e.tbl_shipment_returnOption).HasMaxLength(20);

                entity.Property(e => e.tbl_shipment_returnPostcode).HasMaxLength(15);

                entity.Property(e => e.tbl_shipment_returnState).HasMaxLength(3);

                entity.Property(e => e.tbl_shipment_serviceCode).HasMaxLength(45);

                entity.Property(e => e.tbl_shipment_serviceOption).HasMaxLength(45);

                entity.Property(e => e.tbl_shipment_shipmentItems).HasMaxLength(2000);

                entity.Property(e => e.tbl_shipment_shipperAddressLine1).HasMaxLength(150);

                entity.Property(e => e.tbl_shipment_shipperAddressLine2).HasMaxLength(150);

                entity.Property(e => e.tbl_shipment_shipperAddressLine3).HasMaxLength(150);

                entity.Property(e => e.tbl_shipment_shipperCity).HasMaxLength(45);

                entity.Property(e => e.tbl_shipment_shipperCode).HasMaxLength(10);

                entity.Property(e => e.tbl_shipment_shipperCompany).HasMaxLength(45);

                entity.Property(e => e.tbl_shipment_shipperContact).HasMaxLength(45);

                entity.Property(e => e.tbl_shipment_shipperCountry).HasMaxLength(2);

                entity.Property(e => e.tbl_shipment_shipperEmail).HasMaxLength(45);

                entity.Property(e => e.tbl_shipment_shipperInstructions).HasMaxLength(150);

                entity.Property(e => e.tbl_shipment_shipperName).HasMaxLength(45);

                entity.Property(e => e.tbl_shipment_shipperPhone).HasMaxLength(45);

                entity.Property(e => e.tbl_shipment_shipperPostcode).HasMaxLength(15);

                entity.Property(e => e.tbl_shipment_shipperState).HasMaxLength(45);

                entity.Property(e => e.tbl_shipment_shipperSuburb).HasMaxLength(45);

                entity.Property(e => e.tbl_shipment_sortCode).HasMaxLength(45);

                entity.Property(e => e.tbl_shipment_status).HasMaxLength(30);

                entity.Property(e => e.tbl_shipment_tailLiftD).HasDefaultValueSql("'0'");

                entity.Property(e => e.tbl_shipment_tailLiftO).HasDefaultValueSql("'0'");

                entity.Property(e => e.tbl_shipment_trackingNo).HasMaxLength(50);

                entity.Property(e => e.tbl_shipment_vendorId).HasMaxLength(45);

                entity.Property(e => e.tbl_shipment_warehouse).HasMaxLength(45);

                entity.HasOne(d => d.incoterm)
                    .WithMany(p => p.shipments)
                    .HasForeignKey(d => d.tbl_incoterms_id);

                //Edit by HS on 25/05/2023
                //entity.HasOne(d => d.receptable)
                //    .WithMany(p => p.shipments)
                //    .HasForeignKey(d => d.tbl_receptable_id)
                //    .HasConstraintName("FK_tbl_shipment_tbl_receptacle_tbl_receptacle_id");
                entity.HasOne(d => d.receptacle)
                    .WithMany(p => p.shipments)
                    .HasForeignKey(d => d.tbl_receptacle_id)
                    .HasConstraintName("FK_tbl_shipment_tbl_receptacle_tbl_receptacle_id");
            });

            modelBuilder.Entity<tbl_shipment_item>(entity =>
            {
                entity.HasKey(e => e.idtbl_shipment_item)
                    .HasName("PRIMARY");

                entity.HasIndex(e => e.tbl_shipment_id, "FK_tbl_shipmentl_items_tbl_shipment_tbl_shipment_id_idx");

                entity.Property(e => e.idtbl_shipment_item).HasColumnType("int(11)");

                entity.Property(e => e.ShipmentCode).HasMaxLength(30);

                entity.Property(e => e.tbl_shipment_id).HasColumnType("int(11)");

                entity.Property(e => e.tbl_shipment_item_code).HasMaxLength(50);

                entity.Property(e => e.tbl_shipment_item_description).HasMaxLength(150);

                entity.Property(e => e.tbl_shipment_item_height).HasPrecision(12, 3);

                entity.Property(e => e.tbl_shipment_item_length).HasPrecision(12, 3);

                entity.Property(e => e.tbl_shipment_item_qty).HasColumnType("int(3)");

                entity.Property(e => e.tbl_shipment_item_type).HasMaxLength(5);

                entity.Property(e => e.tbl_shipment_item_volumeUnit).HasMaxLength(50);

                entity.Property(e => e.tbl_shipment_item_weight).HasPrecision(12, 3);

                entity.Property(e => e.tbl_shipment_item_width).HasPrecision(12, 3);

                entity.Property(e => e.tbl_shipment_item_dangerousGoods).HasColumnType("tinyint(4)");

                entity.Property(e => e.tbl_shipment_item_weightUnit).HasMaxLength(50);

                entity.HasOne(d => d.shipment)
                    .WithMany(p => p.shipmentItems)
                    .HasForeignKey(d => d.tbl_shipment_id)
                    .HasConstraintName("FK_tbl_shipment_item_tbl_shipment_tbl_shipment_id");
            });

            modelBuilder.Entity<tbl_shipper>(entity =>
            {
                entity.HasKey(e => e.tbl_shippers_id)
                    .HasName("PRIMARY");

                entity.Property(e => e.tbl_shippers_id).HasColumnType("int(11)");

                entity.Property(e => e.tbl_air_prefix).HasMaxLength(3);

                entity.Property(e => e.tbl_shippers_code)
                    .IsRequired()
                    .HasMaxLength(7);

                entity.Property(e => e.tbl_shippers_country).IsRequired();

                entity.Property(e => e.tbl_shippers_creation_date).HasColumnType("date");

                entity.Property(e => e.tbl_shippers_name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.tbl_shippers_prefix).HasMaxLength(3);

                entity.Property(e => e.tbl_shipperscol).HasMaxLength(45);
            });

            modelBuilder.Entity<tbl_shippers_air_ref>(entity =>
            {
                entity.HasKey(e => e.idtbl_shippers_air_ref)
                    .HasName("PRIMARY");

                entity.ToTable("tbl_shippers_air_ref");

                entity.Property(e => e.idtbl_shippers_air_ref).HasColumnType("int(11)");

                entity.Property(e => e.tbl_shippers_air_batch_id).HasMaxLength(45);

                entity.Property(e => e.tbl_shippers_air_createDate).HasColumnType("datetime");

                entity.Property(e => e.tbl_shippers_air_prefix).HasMaxLength(45);

                entity.Property(e => e.tbl_shippers_air_shipmentId).HasColumnType("int(11)");
            });

            modelBuilder.Entity<tbl_shippers_tracking_ref>(entity =>
            {
                entity.HasKey(e => e.idshippers_tracking_ref)
                    .HasName("PRIMARY");

                entity.ToTable("tbl_shippers_tracking_ref");

                entity.Property(e => e.idshippers_tracking_ref).HasColumnType("int(11)");

                entity.Property(e => e.tbl_shippers_tracking_batch_id).HasMaxLength(20);

                entity.Property(e => e.tbl_shippers_tracking_createDate).HasColumnType("datetime");

                entity.Property(e => e.tbl_shippers_tracking_est_cost).HasPrecision(10, 2);

                entity.Property(e => e.tbl_shippers_tracking_prefix).HasMaxLength(3);

                entity.Property(e => e.tbl_shippers_tracking_shipmentId).HasColumnType("int(11)");
            });

            modelBuilder.Entity<tbl_shipping_billing>(entity =>
            {
                entity.HasKey(e => e.idtbl_shipping_billing)
                    .HasName("PRIMARY");

                entity.ToTable("tbl_shipping_billing");

                entity.HasIndex(e => e.tbl_shipment_id, "IX_tbl_shipping_billing_tbl_shipment_id");

                entity.Property(e => e.idtbl_shipping_billing).HasColumnType("int(11)");

                entity.Property(e => e.tbl_shipment_id).HasColumnType("int(11)");

                entity.Property(e => e.tbl_shipping_billing_dateAdded).HasMaxLength(6);

                entity.Property(e => e.tbl_shipping_billing_orderId).HasMaxLength(30);

                entity.Property(e => e.tbl_shipping_billing_referenceNo).HasMaxLength(30);

                entity.Property(e => e.tbl_shipping_billing_shippingCost).HasPrecision(10, 2);

                entity.Property(e => e.tbl_shipping_billing_status).HasMaxLength(30);

                entity.Property(e => e.tbl_shipping_billing_trackingNo).HasMaxLength(30);

                entity.HasOne(d => d.shipment)
                    .WithMany(p => p.billings)
                    .HasForeignKey(d => d.tbl_shipment_id)
                    .HasConstraintName("FK_tbl_shipping_billing_tbl_shipment_tbl_shipment_id");
            });

            modelBuilder.Entity<tbl_ticket>(entity =>
            {
                entity.HasKey(e => e.tbl_tickets_id)
                    .HasName("PRIMARY");

                entity.Property(e => e.tbl_tickets_id).HasColumnType("int(11)");

                entity.Property(e => e.tbl_tickets_comments).HasMaxLength(45);

                entity.Property(e => e.tbl_tickets_owner).HasMaxLength(45);

                entity.Property(e => e.tbl_tickets_priority).HasColumnType("int(11)");

                entity.Property(e => e.tbl_tickets_status).HasMaxLength(25);

                entity.Property(e => e.tbl_tickets_timestamp).HasColumnType("datetime");

                entity.Property(e => e.tbl_tickets_type).HasMaxLength(45);
            });

            modelBuilder.Entity<tbl_tracking_3pl>(entity =>
            {
                entity.HasKey(e => e.tbl_tracking_id)
                    .HasName("PRIMARY");

                entity.ToTable("tbl_tracking_3pl");

                entity.Property(e => e.tbl_tracking_id).HasColumnType("int(11)");

                entity.Property(e => e.tbl_tracking_createDate).HasMaxLength(6);

                entity.Property(e => e.tbl_tracking_shipmentID).HasColumnType("int(11)");
            });

            modelBuilder.Entity<tbl_tracking_amazon>(entity =>
            {
                entity.HasKey(e => e.tbl_tracking_id)
                    .HasName("PRIMARY");

                entity.ToTable("tbl_tracking_amazon");

                entity.Property(e => e.tbl_tracking_id).HasColumnType("int(11)");

                entity.Property(e => e.tbl_tracking_createDate).HasMaxLength(6);

                entity.Property(e => e.tbl_tracking_shipmentID).HasColumnType("int(11)");
            });

            modelBuilder.Entity<tbl_tracking_austway>(entity =>
            {
                entity.HasKey(e => e.tbl_tracking_id)
                    .HasName("PRIMARY");

                entity.ToTable("tbl_tracking_austway");

                entity.Property(e => e.tbl_tracking_id).HasColumnType("int(11)");

                entity.Property(e => e.tbl_tracking_createDate).HasMaxLength(6);

                entity.Property(e => e.tbl_tracking_shipmentID).HasColumnType("int(11)");
            });

            modelBuilder.Entity<tbl_tracking_border>(entity =>
            {
                entity.HasKey(e => e.tbl_tracking_id)
                    .HasName("PRIMARY");

                entity.ToTable("tbl_tracking_border");

                entity.Property(e => e.tbl_tracking_id).HasColumnType("int(11)");

                entity.Property(e => e.tbl_tracking_createDate).HasColumnType("datetime");

                entity.Property(e => e.tbl_tracking_prefix)
                    .HasMaxLength(5)
                    .HasDefaultValueSql("'VCN'");

                entity.Property(e => e.tbl_tracking_shipmentID).HasColumnType("int(5)");
            });

            modelBuilder.Entity<tbl_tracking_nz>(entity =>
            {
                entity.HasKey(e => e.tbl_tracking_id)
                    .HasName("PRIMARY");

                entity.ToTable("tbl_tracking_nz");

                entity.Property(e => e.tbl_tracking_id).HasColumnType("int(11)");

                entity.Property(e => e.tbl_tracking_createDate).HasMaxLength(6);

                entity.Property(e => e.tbl_tracking_shipmentID).HasColumnType("int(11)");
            });

            modelBuilder.Entity<tbl_tracking_tnt>(entity =>
            {
                entity.HasKey(e => e.tbl_tracking_tnt_id)
                    .HasName("PRIMARY");

                entity.ToTable("tbl_tracking_tnt");

                entity.Property(e => e.tbl_tracking_tnt_id).HasColumnType("int(11)");

                entity.Property(e => e.tbl_tracking_tnt_createDate).HasColumnType("datetime");

                entity.Property(e => e.tbl_tracking_tnt_prefix)
                    .HasMaxLength(5)
                    .HasDefaultValueSql("'VCN'");

                entity.Property(e => e.tbl_tracking_tnt_shipmentID).HasColumnType("int(5)");
            });

            modelBuilder.Entity<tbl_voyage>(entity =>
            {
                entity.HasKey(e => e.idtbl_voyage)
                    .HasName("PRIMARY");

                entity.ToTable("tbl_voyage");

                entity.Property(e => e.idtbl_voyage).HasColumnType("int(11)");

                entity.Property(e => e.tbl_voyage_ata).HasMaxLength(6);

                entity.Property(e => e.tbl_voyage_atd).HasMaxLength(6);

                entity.Property(e => e.tbl_voyage_carrierCode).HasMaxLength(30);

                entity.Property(e => e.tbl_voyage_code).HasMaxLength(30);

                entity.Property(e => e.tbl_voyage_destinationPort).HasMaxLength(30);

                entity.Property(e => e.tbl_voyage_dischargePort).HasMaxLength(30);

                entity.Property(e => e.tbl_voyage_eta).HasMaxLength(6);

                entity.Property(e => e.tbl_voyage_etaDischarge).HasMaxLength(6);

                entity.Property(e => e.tbl_voyage_etd).HasMaxLength(6);

                entity.Property(e => e.tbl_voyage_loadPort).HasMaxLength(30);

                entity.Property(e => e.tbl_voyage_number).HasMaxLength(30);

                entity.Property(e => e.tbl_voyage_status).HasMaxLength(30);

                entity.Property(e => e.tbl_voyage_type).HasMaxLength(30);

                entity.Property(e => e.tbl_voyage_vesselNumber).HasMaxLength(50);
            });

            modelBuilder.Entity<tbl_xml_template>().HasNoKey();

            modelBuilder.Entity<tbl_shipment_search_response>().HasNoKey().ToView(null);

            modelBuilder.Entity<ShipmentDetailsResponse>().HasNoKey().ToView(null);

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
