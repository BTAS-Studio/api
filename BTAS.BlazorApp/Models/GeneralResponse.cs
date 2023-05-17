namespace BTAS.BlazorApp.Models
{
    public class GeneralResponse
    {
        public bool success { get; set; } = true;
        public int response { get; set; } = 200;
        public string referenceNumber { get; set; }
        public string responseDescription { get; set; } = "success";
        public ShipmentData shipmentData { get; set; }
        public LabelData labelData { get; set; }
    }

    public class ShipmentData
    {
        public object shipmentResponse { get; set; }
    }

    public class LabelData
    {
        public object labelResponse{ get; set; }
    }
}
