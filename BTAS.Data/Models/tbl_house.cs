﻿using System;
using System.Collections.Generic;

#nullable disable

namespace BTAS.Data.Models
{
    public partial class tbl_house
    {
        public tbl_house()
        {
            documents = new HashSet<tbl_document>();
            houseItems = new HashSet<tbl_house_item>();
            receptacles = new HashSet<tbl_receptacle>();
            notes = new HashSet<tbl_note>();
            milestoneLinks = new HashSet<tbl_milestone_link>();
        }

        public int idtbl_house { get; set; }
        public string tbl_house_code { get; set; }
        public string tbl_house_billNumber { get; set; }
        public string tbl_house_type { get; set; }
        public string tbl_house_status { get; set; }
        public string tbl_house_delivery { get; set; }
        //public string tbl_house_incotermCode { get; set; }
        public string tbl_house_airJobReference { get; set; }
        public int? tbl_house_qty { get; set; }
        public decimal? tbl_house_weight { get; set; }
        public string tbl_house_weightUnit { get; set; }
        public decimal? tbl_house_length { get; set; }
        public decimal? tbl_house_width { get; set; }
        public decimal? tbl_house_height { get; set; }
        public decimal? tbl_house_volume { get; set; }
        public string tbl_house_volumeUnit { get; set; }
        public string tbl_house_originAirport { get; set; }
        public string tbl_house_destinationAirport { get; set; }
        public decimal? tbl_house_value { get; set; }
        public string tbl_house_description { get; set; }
        public string tbl_house_native_description { get; set; }
        public bool? tbl_house_FTA { get; set; }
        public string tbl_house_shipperCode { get; set; }
        public string tbl_house_coloaderCode { get; set; }
        public string tbl_house_serviceCode { get; set; }
        public string tbl_house_latestTracking { get; set; }
        public DateTime? tbl_house_createdDate { get; set; }
        public DateTime? tbl_house_deliveryDate { get; set; }
        public string tbl_house_deliveryInstructions { get; set; }
        public DateTime? tbl_house_clearanceDate { get; set; }
        public bool? tbl_house_coo { get; set; }
        public bool? tbl_house_tailLiftO { get; set; }
        public bool? tbl_house_tailLiftD { get; set; }
        public bool? tbl_house_DG { get; set; }
        public string tbl_house_UN { get; set; }
        public string tbl_house_packaging { get; set; }
        public string tbl_house_class { get; set; }
        public string tbl_house_currency { get; set; }

        public int? tbl_incoterm_id { get; set; }
        public string IncotermCode { get; set; }
        public virtual tbl_incoterm incoterm { get; set; }

        public int? tbl_voyage_id { get; set; }
        public string VoyageCode { get; set; }
        public virtual tbl_voyage voyage { get; set; }
       
        public int? tbl_master_id { get; set; }
        public string MasterCode { get; set; }
        public virtual tbl_master master { get; set; }

        public int? tbl_container_id { get; set; }
        public string ContainerCode { get; set; }
        public virtual tbl_container container { get; set; }

        public int? tbl_consignee_id { get; set; }
        public string ConsigneeCode { get; set; }
        public virtual tbl_client_header consignee { get; set; }

        public int? tbl_consignor_id { get; set; }
        public string ConsignorCode { get; set; }
        public virtual tbl_client_header consignor { get; set; }

        public int? tbl_pickupClient_id { get; set; }
        public string PickupClientCode { get; set; }
        public virtual tbl_client_header pickupClientDetail { get; set; }

        public int? tbl_deliveryClient_id { get; set; }
        public string DeliveryClientCode { get; set; }
        public virtual tbl_client_header deliveryClientDetail { get; set; }

        public virtual ICollection<tbl_document> documents { get; set; }
        public virtual ICollection<tbl_house_item> houseItems { get; set; }
        public virtual ICollection<tbl_receptacle> receptacles { get; set; }
        public virtual ICollection<tbl_note> notes { get; set; }
        public virtual ICollection<tbl_milestone_link> milestoneLinks { get; set; }
    }
}
