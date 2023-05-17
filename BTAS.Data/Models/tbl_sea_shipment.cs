using System;
using System.Collections.Generic;

#nullable disable

namespace BTAS.Data.Models
{
    public partial class tbl_sea_shipment
    {
        public int tbl_sea_shipment_id { get; set; }
        public string tbl_sea_shipment_mowb { get; set; }
        public string tbl_sea_shipment_howb { get; set; }
        public string tbl_sea_shipment_shippingLine { get; set; }
        public string tbl_sea_shipment_incotermCode { get; set; }
        public string tbl_sea_shipment_seaJobReference { get; set; }
        public string tbl_sea_shipment_shipperID { get; set; }
        public int? tbl_sea_shipment_pieces { get; set; }
        public decimal? tbl_sea_shipment_weight { get; set; }
        public decimal? tbl_sea_shipment_volume { get; set; }
        public DateTime? tbl_sea_shipment_etd { get; set; }
        public DateTime? tbl_sea_shipment_eta { get; set; }
        public DateTime? tbl_sea_shipment_atd { get; set; }
        public DateTime? tbl_sea_shipment_ata { get; set; }
        public string tbl_sea_shipment_originPort { get; set; }
        public string tbl_sea_shipment_destinationPort { get; set; }
        public string tbl_sea_shipment_transit1 { get; set; }
        public string tbl_sea_shipment_transit2 { get; set; }
        public string tbl_sea_shipment_transit3 { get; set; }
        public decimal? tbl_sea_shipment_value { get; set; }
        public string tbl_sea_shipment_description { get; set; }
        public sbyte? tbl_sea_shipment_FTA { get; set; }
        public sbyte? tbl_sea_shipment_COO { get; set; }
        public string tbl_sea_shipment_senderRef { get; set; }
        public string tbl_sea_shipment_coloaderCode { get; set; }
        public string tbl_sea_shipment_latestTracking { get; set; }
        public DateTime? tbl_sea_shipment_timestamp { get; set; }
        public string tbl_sea_shipment_status { get; set; }
        public string tbl_sea_shipment_service { get; set; }
        public string tbl_sea_shipment_notes { get; set; }
        public string tbl_sea_shipment_type { get; set; }
        public DateTime? tbl_sea_shipment_deliverydate { get; set; }
        public DateTime? tbl_sea_shipment_clearancedate { get; set; }
        public sbyte? tbl_sea_shipment_tailLiftO { get; set; }
        public sbyte? tbl_sea_shipment_tailLiftD { get; set; }
        public sbyte? tbl_sea_shipment_DG { get; set; }
        public decimal? tbl_sea_shipment_UN { get; set; }
        public string tbl_sea_shipment_packaging { get; set; }
        public string tbl_sea_shipment_class { get; set; }
        public string tbl_sea_shipment_currency { get; set; }
        public string tbl_sea_shipment_senderName { get; set; }
        public string tbl_sea_shipment_senderAddress1 { get; set; }
        public string tbl_sea_shipment_senderAddress2 { get; set; }
        public string tbl_sea_shipment_senderEmail { get; set; }
        public string tbl_sea_shipment_senderPhone { get; set; }
        public string tbl_sea_shipment_senderBusiness { get; set; }
        public string tbl_sea_shipment_senderSuburb { get; set; }
        public string tbl_sea_shipment_senderCity { get; set; }
        public string tbl_sea_shipment_senderPostcode { get; set; }
        public string tbl_sea_shipment_senderState { get; set; }
        public string tbl_sea_shipment_senderCountry { get; set; }
        public string tbl_sea_shipment_receiverBusiness { get; set; }
        public string tbl_sea_shipment_receiverName { get; set; }
        public string tbl_sea_shipment_receiverAddress1 { get; set; }
        public string tbl_sea_shipment_receiverAddress2 { get; set; }
        public string tbl_sea_shipment_receiverEmail { get; set; }
        public string tbl_sea_shipment_receiverPhone { get; set; }
        public string tbl_sea_shipment_receiverSuburb { get; set; }
        public string tbl_sea_shipment_receiverPostcode { get; set; }
        public string tbl_sea_shipment_receiverCity { get; set; }
        public string tbl_sea_shipment_receiverState { get; set; }
        public string tbl_sea_shipment_receiverCountry { get; set; }
    }
}
