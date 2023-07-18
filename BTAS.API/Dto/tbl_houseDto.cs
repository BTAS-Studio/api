﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace BTAS.API.Dto
{
	public class tbl_houseDto
	{
        [JsonProperty("Id")]
        [JsonIgnore]
        public int idtbl_house { get; set; }

        [JsonProperty("Code")]
        [StringLength(50)]
        [Description("House Code")]
        public string tbl_house_code { get; set; }

        [JsonProperty("BillNumber")]
        [StringLength(50)]
        [Description("HOUSE Bill Number")]
        public string tbl_house_billNumber { get; set; }

        [StringLength(50)]
        [JsonProperty("Type")]
        public string tbl_house_type { get; set; }

        [StringLength(50)]
        [JsonProperty("Status")]
        [Description("HOUSE status")]
        [RegularExpression("OPEN|POSTED")]
        public string tbl_house_status { get; set; }

        [StringLength(50)]
        [JsonProperty("DeliveryAddressNumber")]
        [Description("Delivery address number")]
        public string tbl_house_delivery { get; set; }

        [StringLength(50)]
        [JsonProperty("AirJobReference")]
        [Description("HOUSE job reference number")]
        public string tbl_house_airJobReference { get; set; }

        [JsonProperty("Quantity")]
        [Description("Total quantity")]
        public int? tbl_house_qty { get; set; }

        [JsonProperty("Weight")]
        [Description("Total weight")]
        public decimal? tbl_house_weight { get; set; }

        [JsonProperty("WeightUnit")]
        [StringLength(50)]
        [Description("Weight Unit")]
        public string tbl_house_weightUnit { get; set; }

        [JsonProperty("Length")]
        [Description("Total length")]
        public decimal? tbl_house_length { get; set; }

        [JsonProperty("Width")]
        [Description("Total width")]
        public decimal? tbl_house_width { get; set; }

        [JsonProperty("Height")]
        [Description("Total height")]
        public decimal? tbl_house_height { get; set; }

        [JsonProperty("Volume")]
        [Description("Total volume")]
        public decimal? tbl_house_volume { get; set; }

        [JsonProperty("VolumeUnit")]
        [StringLength(50)]
        [Description("Volume Unit")]
        public string tbl_house_volumeUnit { get; set; }

        [StringLength(50)]
        [JsonProperty("OriginAirport")]
        [Description("Origin airport")]
        public string tbl_house_originAirport { get; set; }

        [StringLength(50)]
        [JsonProperty("DestinationAirport")]
        [Description("Destination airport")]
        public string tbl_house_destinationAirport { get; set; }

        [JsonProperty("Value")]
        [Description("Total value")]
        public decimal? tbl_house_value { get; set; }

        [StringLength(150)]
        [JsonProperty("Description")]
        [Description("HOUSE description")]
        public string tbl_house_description { get; set; }

        [StringLength(150)]
        [JsonProperty("NativeDescription")]
        [Description("HOUSE native description")]
        public string tbl_house_native_description { get; set; }

        [JsonProperty("FTA")]
        public bool? tbl_house_FTA { get; set; }

        [StringLength(50)]
        [JsonProperty("ShipperCode")]
        [Description("Shipper Code")]
        public string tbl_house_shipperCode { get; set; }

        [StringLength(50)]
        [JsonProperty("ColoaderCode")]
        [Description("Coloader code")]
        public string tbl_house_coloaderCode { get; set; }

        [StringLength(50)]
        [JsonProperty("ServiceCode")]
        [Description("Service code")]
        [RegularExpression("no.carrier|APG.EPARCEL.DOM.AU|FW.DOM.COURIER.AU|UBI.CN2UKE2E.ROM|BOR.EXP.PARCEL.NSW|AUST.3PL.EDI.AU|AUST.AMA.EDI.AU|AUST.TRK.EDI.AU|NZ.INT.COURIER.ECON|NZ.INT.COURIER.ONIGHT|AUST.ALD.EDI.AU")]
        public string tbl_house_serviceCode { get; set; }

        [StringLength(50)]
        [JsonProperty("LatestTracking")]
        [Description("Latest tracking")]
        public string tbl_house_latestTracking { get; set; }

        [JsonProperty("CreatedDate")]
        public DateTime? tbl_house_createdDate { get; set; }

        [JsonProperty("DeliveryDate")]
        [Description("Delivery date")]
        public DateTime? tbl_house_deliveryDate { get; set; }

        [StringLength(150)]
        [JsonProperty("DeliveryInstructions")]
        [Description("Delivery additional instructions")]
        public string tbl_house_deliveryInstructions { get; set; }

   
        [JsonProperty("ClearanceDate")]
        [Description("Date cleared")]
        public DateTime? tbl_house_clearanceDate { get; set; }

        [JsonProperty("COO")]
        public bool? tbl_house_coo { get; set; }

        [JsonProperty("TailLiftOrigin")]
        public bool? tbl_house_tailLiftO { get; set; }

        [JsonProperty("TailLiftDestination")]
        public bool? tbl_house_tailLiftD { get; set; }

        [JsonProperty("DangerousGoods")]
        public bool? tbl_house_DG { get; set; }

        [JsonProperty("UN")]
        public string tbl_house_UN { get; set; }

        [StringLength(50)]
        [JsonProperty("Packaging")]
        public string tbl_house_packaging { get; set; }

        [StringLength(50)]
        [JsonProperty("Class")]
        [Description("HOUSE classifications")]
        public string tbl_house_class { get; set; }
        [StringLength(50)]
        [JsonProperty("Currency")]
        public string tbl_house_currency { get; set; }

        [JsonProperty("MasterId")]
        [JsonIgnore]
        public int? tbl_master_id { get; set; }
        [JsonProperty("MasterCode")]
        [StringLength(50)]
        [Optional]
        [Description("Linked MASTER Code")]
        public string MasterCode { get; set; }
        public virtual tbl_masterDto master { get; set; }

        [JsonProperty("ContainerId")]
        [JsonIgnore]
        public int? tbl_container_id { get; set; }
        [JsonProperty("ContainerCode")]
        [StringLength(50)]
        [Optional]
        [Description("Linked container code")]
        public string ContainerCode { get; set; }
        public virtual tbl_containerDto container { get; set; }

        //Added by HS on 13/06/2023
        [JsonProperty("VoyageId")]
        [JsonIgnore]
        public int? tbl_voyage_id { get; set; }
        [JsonProperty("VoyageCode")]
        [StringLength(50)]
        [Optional]
        [Description("Linked voyage code")]
        public string VoyageCode { get; set; }
        public virtual tbl_voyageDto voyage { get; set; }

        [JsonProperty("ConsigneeId")]
        [JsonIgnore]
        public int? tbl_consignee_id { get; set; }
        [StringLength(50)]
        [JsonProperty("ConsigneeCode")]
        [Description("Consignee Code")]
        public string ConsigneeCode { get; set; }
        public virtual tbl_client_headerDto consignee { get; set; }

        [JsonProperty("ConsignorId")]
        [JsonIgnore]
        public int? tbl_consignor_id { get; set; }
        [StringLength(50)]
        [JsonProperty("ConsignorCode")]
        [Description("Consignor Code")]
        public string ConsignorCode { get; set; }
        public virtual tbl_client_headerDto consignor { get; set; }

        [JsonProperty("IncotermId")]
        [JsonIgnore]
        public int? tbl_incoterm_id { get; set; }
        [StringLength(50)]
        [JsonProperty("IncotermCode")]
        [Description("Linked incoterm code")]
        public string IncotermCode { get; set; }
        public virtual tbl_incotermDto incoterm { get; set; }

        [JsonProperty("PickupClientId")]
        [JsonIgnore]
        public int? tbl_pickupClient_id { get; set; }
        [JsonProperty("PickupClientCode")]
        [StringLength(50)]
        public string PickupClientCode { get; set; }
        public virtual tbl_client_headerDto pickupClientDetail { get; set; }
        
        [JsonProperty("DeliveryClientId")]
        [JsonIgnore]
        public int? tbl_deliveryClient_id { get; set; }
        [JsonProperty("DeliveryClientCode")]
        [StringLength(50)]
        public string DeliveryClientCode { get; set; }
        public virtual tbl_client_headerDto deliveryClientDetail { get; set; }


        public virtual ICollection<tbl_documentDto> documents { get; set; } = new Collection<tbl_documentDto>();
        public virtual ICollection<tbl_house_itemDto> houseItems { get; set; } = new Collection<tbl_house_itemDto>();
        public virtual ICollection<tbl_receptacleDto> receptacles { get; set; } = new Collection<tbl_receptacleDto>();
        public virtual ICollection<tbl_noteDto> notes { get; set; } = new Collection<tbl_noteDto>();
        public virtual ICollection<tbl_milestone_linkDto> milestoneLinks { get; set; } = new Collection<tbl_milestone_linkDto>();


    }
}
