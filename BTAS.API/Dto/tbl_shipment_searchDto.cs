namespace BTAS.API.Dto
{
    public class tbl_shipment_searchDto
    {
        public string shipper { get; set; }
        public string shipperPrefix { get; set; }
        public string shipperId { get; set; }
        public string jobNumber { get; set; }
        public string trackingNumber { get; set; }
        public string jobReference { get; set; }
        public string serviceName { get; set; }
        public string deliveryName { get; set; }
        public string deliveryPhone { get; set; }
        public string deliveryEmail { get; set; }
        public string deliveryCompany { get; set; }
        public string manifestId { get; set; }
        public string manifestNumber { get; set; }
    }
}
