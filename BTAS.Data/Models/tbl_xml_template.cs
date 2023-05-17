using System.ComponentModel.DataAnnotations.Schema;

namespace BTAS.Data.Models
{
    [NotMapped]
    public class tbl_xml_template
    {
        public string ConsignmentNumber { get; set; }
        public string ConsignmentDate { get; set; }
        public string SenderName { get; set; }
        public string SenderContact { get; set; }
        public string SenderPhone { get; set; }
        public string SenderEmail { get; set; }
        public string SenderStreetAddress { get; set; }
        public string SenderStreetAddress1 { get; set; }
        public string SenderSuburb { get; set; }
        public string SenderState { get; set; }
        public string SenderPostcode { get; set; }
        public string Pickup { get; set; }
        public string Delivery { get; set; }
        public string DangerousGoods { get; set; }
        public string ReceiverReference { get; set; }
        public string ReceiverName { get; set; }
        public string ReceiverContact { get; set; }
        public string ReceiverPhone { get; set; }
        public string ReceiverEmail { get; set; }
        public string ReceiverStreetAddress { get; set; }
        public string ReceiverStreetAddress1 { get; set; }
        public string ReceiverSuburb { get; set; }
        public string ReceiverState { get; set; }
        public string ReceiverPostcode { get; set; }
        public string TotalWeight { get; set; }
        public string AccountCode { get; set; }
        public string CarrierService { get; set; }
        public string Comments { get; set; }
        public string ItemReference { get; set; }
        public string NumberOfUnits { get; set; }
        public string LogisticUnit { get; set; }
        public string Weight { get; set; }
        public string Length { get; set; }
        public string Width { get; set; }
        public string Height { get; set; }
        public string Cubic { get; set; }
        public string Barcode { get; set; }
    }
}
